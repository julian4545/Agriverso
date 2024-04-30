using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleRecolectorController : ControllerBase
    {
        private readonly IDetalleRecolectorService _detalleRecolectorService;

        public DetalleRecolectorController(IDetalleRecolectorService detalleRecolectorService)
        {
            _detalleRecolectorService = detalleRecolectorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleRecolector>>> GetAll()
        {
            var detalles = await _detalleRecolectorService.GetAll();
            return Ok(detalles);
        }

        [HttpGet("{detalleRecolectorId}")]
        public async Task<ActionResult<DetalleRecolector>> Get(int detalleRecolectorId)
        {
            var detalle = await _detalleRecolectorService.Get(detalleRecolectorId);
            if (detalle == null)
            {
                return NotFound();
            }
            return Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleRecolector>> Create(DetalleRecolector detalleRecolector)
        {
            var createdDetalle = await _detalleRecolectorService.CreateDetalleRecolector(detalleRecolector.RecoleccionId, detalleRecolector.ResiduoId, detalleRecolector.Cantidad);
            return CreatedAtAction(nameof(Get), new { detalleRecolectorId = createdDetalle.DetalleRecolectorId }, createdDetalle);
        }

        [HttpPut("{detalleRecolectorId}")]
        public async Task<ActionResult<DetalleRecolector>> Update(int detalleRecolectorId, DetalleRecolector detalleRecolector)
        {
            if (detalleRecolectorId != detalleRecolector.DetalleRecolectorId)
            {
                return BadRequest();
            }

            var existingDetalle = await _detalleRecolectorService.Get(detalleRecolectorId);
            if (existingDetalle == null)
            {
                return NotFound();
            }

            existingDetalle.RecoleccionId = detalleRecolector.RecoleccionId;
            existingDetalle.ResiduoId = detalleRecolector.ResiduoId;
            existingDetalle.Cantidad = detalleRecolector.Cantidad;

            var updatedDetalle = await _detalleRecolectorService.UpdateDetalleRecolector(detalleRecolectorId, detalleRecolector.RecoleccionId, detalleRecolector.ResiduoId, detalleRecolector.Cantidad);
            return Ok(updatedDetalle);
        }

        [HttpDelete("{detalleRecolectorId}")]
        public async Task<ActionResult> Delete(int detalleRecolectorId)
        {
            await _detalleRecolectorService.DeleteDetalleRecolectorAsync(detalleRecolectorId);
            return NoContent();
        }
    }
}
