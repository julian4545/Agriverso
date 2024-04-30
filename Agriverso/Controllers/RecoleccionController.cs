using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecoleccionController : ControllerBase
    {
        private readonly IRecoleccionService _recoleccionService;

        public RecoleccionController(IRecoleccionService recoleccionService)
        {
            _recoleccionService = recoleccionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recoleccion>>> GetAll()
        {
            var recolecciones = await _recoleccionService.GetAll();
            return Ok(recolecciones);
        }

        [HttpGet("{recoleccionId}")]
        public async Task<ActionResult<Recoleccion>> Get(int recollectionId)
        {
            var recoleccion = await _recoleccionService.Get(recoleccionId);
            if (recoleccion == null)
            {
                return NotFound();
            }
            return Ok(recoleccion);
        }

        [HttpPost]
        public async Task<ActionResult<Recoleccion>> Create(Recoleccion recoleccion)
        {
            var createdRecoleccion = await _recoleccionService.CreateRecoleccion(recoleccion.RecolectorId, recoleccion.Fecha, recoleccion.Descripcion);
            return CreatedAtAction(nameof(Get), new { recoleccionId = createdRecoleccion.RecoleccionId }, createdRecoleccion);
        }

        [HttpPut("{recoleccionId}")]
        public async Task<ActionResult<Recoleccion>> Update(int recoleccionId, Recoleccion recoleccion)
        {
            if (recoleccionId != recoleccion.RecoleccionId)
            {
                return BadRequest();
            }

            var existingRecoleccion = await _recoleccionService.Get(recoleccionId);
            if (existingRecoleccion == null)
            {
                return NotFound();
            }

            existingRecoleccion.RecolectorId = recoleccion.RecolectorId;
            existingRecoleccion.Fecha = recoleccion.Fecha;
            existingRecoleccion.Descripcion = recoleccion.Descripcion;

            var updatedRecoleccion = await _recoleccionService.UpdateRecoleccion(recoleccionId, recoleccion.RecolectorId, recoleccion.Fecha, recoleccion.Descripcion);
            return Ok(updatedRecoleccion);
        }

        [HttpDelete("{recoleccionId}")]
        public async Task<ActionResult> Delete(int recoleccionId)
        {
            await _recoleccionService.DeleteRecoleccionAsync(recoleccionId);
            return NoContent();
        }
    }
}
