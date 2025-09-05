using Application.InputModels.DataAnalysisInputModels;
using Application.Services.DataAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/dataAnalysis")]
    public class DataAnalysisController(IDataAnalysisServices dataAnalysisServices) : ControllerBase
    {
        private readonly IDataAnalysisServices _dataAnalysisServices = dataAnalysisServices;

        /// <summary>
        /// Analyse data
        /// </summary>
        /// <returns>Analysis of the plot nutrients</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost("analyseNutrients")]
        public async Task<IActionResult> AnalyseNurients([FromBody] AnalyseNutrientsInputModel inputModel)
        {
            var analysis = await _dataAnalysisServices.AnalyseNutrients(inputModel, User);
            return Ok(analysis);
        }

        /// <summary>
        /// Recomends fertilizers
        /// </summary>
        /// <returns>Fertilizers recomendation</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost("recommendFertilizers")]
        public async Task<IActionResult> RecommendFertilizers([FromBody] RecommendFertilizersInputModel inputModel)
        {
            var recomendation = await _dataAnalysisServices.RecommendFertilizers(inputModel, User);
            return Ok(recomendation);
        }
    }
}