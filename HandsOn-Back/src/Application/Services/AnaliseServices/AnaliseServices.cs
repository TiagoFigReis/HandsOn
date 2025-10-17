using Core.Repositories;
using Application.InputModels.InputModelsAnalise;
using Application.ViewModels;
using Application.Exceptions;
using Application.Validators;
using Core.Entities;
using Core.Enums;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Infrastructure.Utils;
using Infrastructure.Utils.InterpretingFile;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Application.Services
{
    public class AnaliseServices : IAnaliseServices
    {
        private readonly IAnaliseRepository _analiseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PdfInterpretationService _pdfInterpretationService;

        public AnaliseServices(
            IAnaliseRepository analiseRepository,
            IHttpContextAccessor http,
            PdfInterpretationService pdfInterpretationService)
        {
            _analiseRepository = analiseRepository;
            _httpContextAccessor = http;
            _pdfInterpretationService = pdfInterpretationService;
        }

        public async Task<AnaliseViewModel?> GetByIdAsync(Guid Id, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var analise = await _analiseRepository.GetByIdAsync(Id, userId) ?? throw new NotFoundException("Análise not found");
            return AnaliseViewModel.FromEntity(analise);
        }

        public async Task<IActionResult> GetFiles(Guid id, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var analise = await _analiseRepository.GetByIdAsync(id, userId);
            if (analise == null) throw new NotFoundException("Análise not found");
            var directoryPath = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
                "Infrastructure", "Files", userId.ToString()
            );
            return FileService.GetFile(id, directoryPath);
        }

        public async Task<IEnumerable<AnaliseViewModel>?> GetAllAsync(ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var analise = await _analiseRepository.GetAllAsync(userId) ?? throw new NotFoundException("Análise not found");
            return analise.Select(AnaliseViewModel.FromEntity);
        }

        public async Task<AnaliseViewModel> Add(ClaimsPrincipal actionUser, AnaliseInputModel inputModel)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            InputModelValidator.Validate(inputModel);

            var analise = new Analise
            {
                Tipo = TipoExtension.ToSource(inputModel.Tipo),
                Lab = inputModel.Lab,
                Proprietario = inputModel.Proprietario,
                Propriedade = inputModel.Propriedade,
                DataAnalise = inputModel.DataAnalise,
                UserId = userId
            };

            if (inputModel.Analise != null)
            {
                var dados = await _pdfInterpretationService.InterpretAndTransformPdfAsync(inputModel.Analise, analise.Tipo);
                if (dados != null)
                {
                    analise.DadosAnalise = dados;
                }
            }

            await FileService.SaveFileAsync(inputModel.Analise!, analise.Id, userId, _httpContextAccessor.HttpContext!);
            await _analiseRepository.Add(analise);
            return AnaliseViewModel.FromEntity(analise);
        }

        public async Task<AnaliseViewModel> Update(ClaimsPrincipal actionUser, Guid Id, AnaliseInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var analise = await _analiseRepository.GetByIdAsync(Id, userId) ?? throw new NotFoundException("Análise not found");
            PlotsData? dadosAnalise = null;

            if (!string.IsNullOrEmpty(inputModel.DadosAnalise))
            {
                dadosAnalise = JsonSerializer.Deserialize<PlotsData>(inputModel.DadosAnalise, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            if (dadosAnalise?.Plots.Count > 0)
            {
                analise.Update(
                    inputModel.Tipo,
                    inputModel.Lab,
                    inputModel.Proprietario,
                    inputModel.Propriedade,
                    inputModel.DataAnalise,
                    userId
                );
                analise.DadosAnalise = dadosAnalise;
            }
            else
            {
                var directoryPath = Path.Combine(
                    Directory.GetParent(Directory.GetCurrentDirectory())!.FullName,
                    "Infrastructure", "Files", userId.ToString()
                );
                var originalFile = FileService.GetFile(analise.Id, directoryPath);
                bool arquivosIguais = false;
                if (originalFile is FileStreamResult fsResult)
                {
                    arquivosIguais = FileService.ArquivosSaoIguais(fsResult.FileStream, inputModel.Analise!);
                    fsResult.FileStream.Dispose();
                }

                if (!arquivosIguais)
                {
                    await FileService.DeleteFileAsync(analise.Id, userId);
                    await FileService.SaveFileAsync(inputModel.Analise!, analise.Id, userId, _httpContextAccessor.HttpContext!);
                }

                analise.Update(
                    inputModel.Tipo,
                    inputModel.Lab,
                    inputModel.Proprietario,
                    inputModel.Propriedade,
                    inputModel.DataAnalise,
                    userId
                );

                if (!arquivosIguais)
                {
                    var dados = await _pdfInterpretationService.InterpretAndTransformPdfAsync(inputModel.Analise!, analise.Tipo);
                    if (dados != null)
                    {
                        analise.DadosAnalise = dados;
                    }
                }
            }

            await _analiseRepository.Update(analise);
            return AnaliseViewModel.FromEntity(analise);
        }

        public async Task<AnaliseViewModel> Delete(ClaimsPrincipal actionUser, Guid Id)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var analise = await _analiseRepository.GetByIdAsync(Id, userId) ?? throw new NotFoundException("Análise not found");
            await FileService.DeleteFileAsync(analise.Id, userId);
            await _analiseRepository.Delete(analise);
            return AnaliseViewModel.FromEntity(analise);
        }
    }
}

