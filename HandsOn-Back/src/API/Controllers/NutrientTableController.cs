using Application.InputModels.NutrientTableInputModels;
using Application.Services.NutrientTables;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/nutrientTables")]
    public class NutrientTablesController(INutrientTablesServices nutrientTableServices) : ControllerBase
    {
        private readonly INutrientTablesServices _nutrientTablesServices = nutrientTableServices;

        /// <summary>
        /// Get all nutrient tables
        /// </summary>
        /// <returns>Nutrient Table collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var nutrientTables = await _nutrientTablesServices.GetAllAsync(User);
            return Ok(nutrientTables);
        }

        /// <summary>
        /// Get nutrient table by id
        /// </summary>
        /// <param name="id">Nutrient Table id</param>
        /// <returns>Nutrient Table</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var nutrientTable = await _nutrientTablesServices.GetByIdAsync(id);
            return Ok(nutrientTable);
        }

        /// <summary>
        /// Get nutrient table by culture
        /// </summary>
        /// <param name="cultureId">Culture Id</param>
        /// <returns>Nutrient Table</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("by-culture/{cultureId}")]
        public async Task<IActionResult> GetByCulture(Guid cultureId)
        {
            var nutrientTable = await _nutrientTablesServices.GetByCultureAsync(cultureId, User);
            return Ok(nutrientTable);
        }

        /// <summary>
        /// Register a new nutrient table
        /// </summary>
        /// <param name="inputModel">Nutrient Table input model</param>
        /// <returns>Nutrient Table</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterNutrientTableInputModel inputModel)
        {
            var nutrientTable = await _nutrientTablesServices.RegisterAsync(inputModel, User);
            return CreatedAtAction(nameof(Get), new { id = nutrientTable.Id }, nutrientTable);
        }

        /// <summary>
        /// Update a nutrient table
        /// </summary>
        /// <param name="id">Nutrient Table id</param>
        /// <param name="inputModel">Nutrient Table input model</param>
        /// <returns>Nutrient Table</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateNutrientTableInputModel inputModel)
        {
            var nutrientTable = await _nutrientTablesServices.UpdateAsync(id, inputModel, User);
            return Ok(nutrientTable);
        }

        /// <summary>
        /// Delete a Nutrient Table
        /// </summary>
        /// <param name="id">Nutrient Table id</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks></remarks>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _nutrientTablesServices.DeleteAsync(id, User);
            return NoContent();
        }
    }
}