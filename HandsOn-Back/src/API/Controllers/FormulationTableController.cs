using Application.InputModels.FormulationTableInputModels;
using Application.Services.FormulationTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/formulationTables")]
    public class FormulationTablesController(IFormulationTablesServices formulationTablesServices) : ControllerBase
    {
        private readonly IFormulationTablesServices _formulationTablesServices = formulationTablesServices;

        /// <summary>
        /// Get all formulation tables
        /// </summary>
        /// <returns>Formulation Table collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var formulationTables = await _formulationTablesServices.GetAllAsync(User);
            return Ok(formulationTables);
        }

        /// <summary>
        /// Get formulation table by id
        /// </summary>
        /// <param name="id">Formulation Table id</param>
        /// <returns>Formulation Table</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var formulationTable = await _formulationTablesServices.GetByIdAsync(id);
            return Ok(formulationTable);
        }

        /// <summary>
        /// Get formulation table by culture
        /// </summary>
        /// <param name="cultureId">Culture Id</param>
        /// <returns>Formulation Table</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("by-culture/{cultureId}")]
        public async Task<IActionResult> GetByCulture(Guid cultureId)
        {
            var formulationTable = await _formulationTablesServices.GetByCultureAsync(cultureId, User);
            return Ok(formulationTable);
        }

        /// <summary>
        /// Register a new formulation table
        /// </summary>
        /// <param name="inputModel">Formulation Table input model</param>
        /// <returns>Formulation Table</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterFormulationTableInputModel inputModel)
        {
            var formulationTable = await _formulationTablesServices.RegisterAsync(inputModel, User);
            return CreatedAtAction(nameof(Get), new { id = formulationTable.Id }, formulationTable);
        }

        /// <summary>
        /// Update a formulation table
        /// </summary>
        /// <param name="id">Formulation Table id</param>
        /// <param name="inputModel">Formulation Table input model</param>
        /// <returns>Formulation Table</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateFormulationTableInputModel inputModel)
        {
            var formlationTable = await _formulationTablesServices.UpdateAsync(id, inputModel, User);
            return Ok(formlationTable);
        }

        /// <summary>
        /// Delete a Formulation Table
        /// </summary>
        /// <param name="id">Formulation Table id</param>
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
            await _formulationTablesServices.DeleteAsync(id, User);
            return NoContent();
        }
    }
}