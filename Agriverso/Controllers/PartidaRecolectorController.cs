using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidaRecolectorController : ControllerBase
    {
        private readonly IPartidaRecolectorService _partidaRecolectorService;

        public PartidaRecolectorController(IPartidaRecolectorService partidaRecolectorService)
        {
            _partidaRecolectorService = partidaRecolectorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PartidaRecolector>>> GetAll()
        {
            var partidas = await _partidaRecolectorService.GetAll();
            return Ok(partidas);
        }

        [HttpGet("{partidaRecolectorId}")]
        public async Task<ActionResult<PartidaRecolector>> Get(int partidaRecolectorId)
        {
            var partida = await _partidaRecolectorService.Get(partidaRecolectorId);
            if (partida == null)
            {
                return NotFound();
            }
            return Ok(partida);
        }

        [HttpPost]
        public async Task<ActionResult<PartidaRecolector>> Create(PartidaRecolector partidaRecolector)
        {
            var createdPartida = await _partidaRecolectorService.CreatePartidaRecolector(partidaRecolector.RecolectorId);
            return CreatedAtAction(nameof(Get), new { partidaRecolectorId = createdPartida.PartidaRecolectorId }, createdPartida);
        }

        [HttpPut("{partidaRecolectorId}")]
        public async Task<ActionResult<PartidaRecolector>> Update(int partidaRecolectorId, PartidaRecolector partidaRecolector)
        {
            if (partidaRecolectorId != partidaRecolector.PartidaRecolectorId)
            {
                return BadRequest();
            }

            var existingPartida = await _partidaRecolectorService.Get(partidaRecolectorId);
            if (existingPartida == null)
            {
                return NotFound();
            }

            existingPartida.RecolectorId = partidaRecolector.RecolectorId;

            var updatedPartida = await _partidaRecolectorService.UpdatePartidaRecolector(partidaRecolectorId, partidaRecolector.RecolectorId);
            return Ok(updatedPartida);
        }

        [HttpDelete("{partidaRecolectorId}")]
        public async Task<ActionResult> Delete(int partidaRecolectorId)
        {
            await _partidaRecolectorService.DeletePartidaRecolectorAsync(partidaRecolectorId);
            return NoContent();
        }
    }
}
