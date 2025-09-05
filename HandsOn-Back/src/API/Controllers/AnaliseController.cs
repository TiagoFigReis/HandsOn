using Application.Exceptions;
using Application.InputModels.InputModelsAnalise;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace API.Controllers
{
    [ApiController]
    [Route("api/analise")]
    public class AnaliseController(IAnaliseServices analiseServices) : ControllerBase
    {
        private readonly IAnaliseServices _analiseServices = analiseServices;

        /// <summary>
        /// Get all analises
        /// </summary>
        /// <returns>Analises collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var analises = await _analiseServices.GetAllAsync(User);
            return Ok(analises);
        }

        /// <summary>
        /// Get one analise by id
        /// </summary>
        /// <param name="id">Analise id</param>
        /// <returns>Analise</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var analise = await _analiseServices.GetByIdAsync(id, User);
            return Ok(analise);
        }

        [Authorize]
        [HttpGet("files/{id}")]
        public Task<IActionResult> GetFiles(Guid id)
        {
            return _analiseServices.GetFiles(id, User);
        }

        /// <summary>
        /// Add analise
        /// </summary>
        /// <param name="inputModel">Analise InputModel</param>
        /// <returns>Analise</returns>
        /// <response code="201">Created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AnaliseInputModel inputModel)
        {
            var analise = await _analiseServices.Add(User, inputModel);
            return CreatedAtAction(nameof(GetId), new { id = analise.Id }, analise);
        }

        /// <summary>
        /// Updates a analise
        /// </summary>
        /// <param name="id">Analise Id</param>
        /// <param name="inputModel">Analise InputModel</param>
        /// <returns>Analise</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] AnaliseInputModel inputModel)
        {
            var analise = await _analiseServices.Update(User, id, inputModel);
            return Ok(analise);
        }

        /// <summary>
        /// Delete a analise
        /// </summary>
        /// <param name="id">Analise id</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _analiseServices.Delete(User, id);
            return NoContent();
        }
    }
}