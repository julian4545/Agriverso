using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PosicionRecolectorPartidaController : ControllerBase
    {
        private readonly IPosicionRecolectorPartidaService _posicionRecolectorPartidaService;

        public PosicionRecolectorPartidaController(IPosicionRecolectorPartidaService posicionRecolectorPartidaService)
        {
            _posicionRecolectorPartidaService = posicionRecolectorPartidaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PosicionRecolectorPartida>>> GetAll()
        {
            var posiciones = await _posicionRecolectorPartidaService.GetAll();
            return Ok(posiciones);
        }

        [HttpGet("{posicionRecolectorPartidaId}")]
        public async Task<ActionResult<PosicionRecolectorPartida>> Get(int posicionRecolectorPartidaId)
        {
            var posicion = await _posicionRecolectorPartidaService.Get(posicionRecolectorPartidaId);
            if (posicion == null)
            {
                return NotFound();
            }
            return Ok(posicion);
        }

        [HttpPost]
        public async Task<ActionResult<PosicionRecolectorPartida>> Create(PosicionRecolectorPartida posicionRecolectorPartida)
        {
            var createdPosicion = await _posicionRecolectorPartidaService.CreatePosicionRecolectorPartida(posicionRecolectorPartida.PartidaRecolectorId, posicionRecolectorPartida.Latitud, posicionRecolectorPartida.Longitud);
            return CreatedAtAction(nameof(Get), new { posicionRecolectorPartidaId = createdPosicion.PosicionRecolectorPartidaId }, createdPosicion);
        }

        [HttpPut("{posicionRecolectorPartidaId}")]
        public async Task<ActionResult<PosicionRecolectorPartida>> Update(int posicionRecolectorPartidaId, PosicionRecolectorPartida posicionRecolectorPartida)
        {
            if (posicionRecolectorPartidaId != posicionRecolectorPartida.PosicionRecolectorPartidaId)
            {
                return BadRequest();
            }

            var existingPosicion = await _posicionRecolectorPartidaService.Get(posicionRecolectorPartidaId);
            if (existingPosicion == null)
            {
                return NotFound();
            }

            existingPosicion.Latitud = posicionRecolectorPartida.Latitud;
            existingPosicion.Longitud = posicionRecolectorPartida.Longitud;

            var updatedPosicion = await _posicionRecolectorPartidaService.UpdatePosicionRecolectorPartida(posicionRecolectorPartidaId, posicionRecolectorPartida.Latitud, posicionRecolectorPartida.Longitud);
            return Ok(updatedPosicion);
        }

        [HttpDelete("{posicionRecolectorPartidaId}")]
        public async Task<ActionResult> Delete(int posicionRecolectorPartidaId)
        {
            await _posicionRecolectorPartidaService.DeletePosicionRecolectorPartidaAsync(posicionRecolectorPartidaId);
            return NoContent();
        }
    }
}
