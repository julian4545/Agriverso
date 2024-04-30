using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecolectorController : ControllerBase
    {
        private readonly IRecolectorService _recolectorService;

        public RecolectorController(IRecolectorService recolectorService)
        {
            _recolectorService = recolectorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recolector>>> GetAll()
        {
            var recolectores = await _recolectorService.GetAll();
            return Ok(recolectores);
        }

        [HttpGet("{recolectorId}")]
        public async Task<ActionResult<Recolector>> Get(int recolectorId)
        {
            var recolector = await _recolectorService.Get(recolectorId);
            if (recolector == null)
            {
                return NotFound();
            }
            return Ok(recolector);
        }

        [HttpPost]
        public async Task<ActionResult<Recolector>> Create(Recolector recolector)
        {
            var createdRecolector = await _recolectorService.CreateRecolector(recolector.GranjeroId, recolector.Nombre, recolector.Apellido);
            return CreatedAtAction(nameof(Get), new { recolectorId = createdRecolector.RecolectorId }, createdRecolector);
        }

        [HttpPut("{recolectorId}")]
        public async Task<ActionResult<Recolector>> Update(int recolectorId, Recolector recolector)
        {
            if (recolectorId != recolector.RecolectorId)
            {
                return BadRequest();
            }

            var existingRecolector = await _recolectorService.Get(recolectorId);
            if (existingRecolector == null)
            {
                return NotFound();
            }

            existingRecolector.GranjeroId = recolector.GranjeroId;
            existingRecolector.Nombre = recolector.Nombre;
            existingRecolector.Apellido = recolector.Apellido;

            var updatedRecolector = await _recolectorService.UpdateRecolector(recolectorId, recolector.GranjeroId, recolector.Nombre, recolector.Apellido);
            return Ok(updatedRecolector);
        }

        [HttpDelete("{recolectorId}")]
        public async Task<ActionResult> Delete(int recolectorId)
        {
            await _recolectorService.DeleteRecolectorAsync(recolectorId);
            return NoContent();
        }
    }
}
