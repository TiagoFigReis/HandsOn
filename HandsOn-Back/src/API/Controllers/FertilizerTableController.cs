using Application.InputModels.FertilizerTableInputModels;
using Application.Services.FertilizerTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/fertilizerTables")]
    public class FertilizerTablesController(IFertilizerTablesServices fertilizerTablesServices) : ControllerBase
    {
        private readonly IFertilizerTablesServices _fertilizerTablesServices = fertilizerTablesServices;

        /// <summary>
        /// Get all fertilizer tables
        /// </summary>
        /// <returns>Fertilizer Table collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var fertilizerTables = await _fertilizerTablesServices.GetAllAsync(User);
            return Ok(fertilizerTables);
        }

        /// <summary>
        /// Get fertilizer table by id
        /// </summary>
        /// <param name="id">Fertilizer Table id</param>
        /// <returns>Fertilizer Table</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fertilizerTable = await _fertilizerTablesServices.GetByIdAsync(id);
            return Ok(fertilizerTable);
        }

        /// <summary>
        /// Get fertilizer table by culture
        /// </summary>
        /// <param name="cultureId">Culture Id</param>
        /// <returns>Fertilizer Table</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorize(Roles = "Admin")d</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("by-culture/{cultureId}")]
        public async Task<IActionResult> GetByCulture(Guid cultureId)
        {
            var fertilizerTable = await _fertilizerTablesServices.GetByCultureAsync(cultureId, User);
            return Ok(fertilizerTable);
        }

        /// <summary>
        /// Register a new fertilizer table
        /// </summary>
        /// <param name="inputModel">Fertilizer Table input model</param>
        /// <returns>Fertilizer Table</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterFertilizerTableInputModel inputModel)
        {
            var fertilizerTable = await _fertilizerTablesServices.RegisterAsync(inputModel, User);
            return CreatedAtAction(nameof(Get), new { id = fertilizerTable.Id }, fertilizerTable);
        }

        /// <summary>
        /// Update a fertilizer table
        /// </summary>
        /// <param name="id">Fertilizer Table id</param>
        /// <param name="inputModel">Fertilizer Table input model</param>
        /// <returns>Fertilizer Table</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateFertilizerTableInputModel inputModel)
        {
            var fertilizerTable = await _fertilizerTablesServices.UpdateAsync(id, inputModel, User);
            return Ok(fertilizerTable);
        }

        /// <summary>
        /// Delete a fertilizer table
        /// </summary>
        /// <param name="id">Fertilizer Table id</param>
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
            await _fertilizerTablesServices.DeleteAsync(id, User);
            return NoContent();
        }
    }
}