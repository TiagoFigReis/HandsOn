using Application.InputModels.CultureInputModels;
using Application.Services.Cultures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/cultures")]
    public class CulturesController(ICulturesServices culturesServices) : ControllerBase
    {
        private readonly ICulturesServices _culturesServices = culturesServices;

        /// <summary>
        /// Get all cultures
        /// </summary>
        /// <returns>Culture collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cultures = await _culturesServices.GetAllAsync();
            return Ok(cultures);
        }

        /// <summary>
        /// Get all cultures that still don't have a nutrient table assigned to
        /// </summary>
        /// <returns>Culture collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        
        [HttpGet("no-nutrient-tables")]
        public async Task<IActionResult> GetWithoutNutrientTable()
        {
            var cultures = await _culturesServices.GetAllWithoutNutrientTableAsync();
            return Ok(cultures);
        }

        /// <summary>
        /// Get all cultures that still don't have a fertilizer table assigned to
        /// </summary>
        /// <returns>Culture collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>

        [HttpGet("no-fertilizer-tables")]
        public async Task<IActionResult> GetWithoutFertilizerTable()
        {
            var cultures = await _culturesServices.GetAllWithoutFertilizerTableAsync();
            return Ok(cultures);
        }

        /// <summary>
        /// Get culture by id
        /// </summary>
        /// <param name="id">Culture id</param>
        /// <returns>Culture</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var culture = await _culturesServices.GetByIdAsync(id);
            return Ok(culture);
        }

        /// <summary>
        /// Get culture by name
        /// </summary>
        /// <param name="name">Culture id</param>
        /// <returns>Culture</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var culture = await _culturesServices.GetByNameAsync(name);
            return Ok(culture);
        }

        /// <summary>
        /// Register a new Culture
        /// </summary>
        /// <param name="inputModel">Culture input model</param>
        /// <returns>Culture</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        
        [HttpPost]
        public async Task<IActionResult> Post(RegisterCultureInputModel inputModel)
        {
            var culture = await _culturesServices.RegisterAsync(inputModel);
            return CreatedAtAction(nameof(Get), new { id = culture.Id }, culture);
        }

        /// <summary>
        /// Update a Culture
        /// </summary>
        /// <param name="id">Culture id</param>
        /// <param name="inputModel">Culture input model</param>
        /// <returns>Culture</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks></remarks>
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateCultureInputModel inputModel)
        {
            var culture = await _culturesServices.UpdateAsync(id, inputModel);
            return Ok(culture);
        }

        /// <summary>
        /// Delete a Culture
        /// </summary>
        /// <param name="id">Culture id</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks></remarks>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _culturesServices.DeleteAsync(id);
            return NoContent();
        }
    }
}