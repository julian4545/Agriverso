using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estado>>> GetAll()
        {
            var estados = await _estadoService.GetAll();
            return Ok(estados);
        }

        [HttpGet("{estadoId}")]
        public async Task<ActionResult<Estado>> Get(int estadoId)
        {
            var estado = await _estadoService.Get(estadoId);
            if (estado == null)
            {
                return NotFound();
            }
            return Ok(estado);
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> Create(Estado estado)
        {
            var createdEstado = await _estadoService.CreateEstado(estado.Nombre, estado.Descripcion);
            return CreatedAtAction(nameof(Get), new { estadoId = createdEstado.EstadoId }, createdEstado);
        }

        [HttpPut("{estadoId}")]
        public async Task<ActionResult<Estado>> Update(int estadoId, Estado estado)
        {
            if (estadoId != estado.EstadoId)
            {
                return BadRequest();
            }

            var existingEstado = await _estadoService.Get(estadoId);
            if (existingEstado == null)
            {
                return NotFound();
            }

            existingEstado.Nombre = estado.Nombre;
            existingEstado.Descripcion = estado.Descripcion;

            var updatedEstado = await _estadoService.UpdateEstado(estadoId, estado.Nombre, estado.Descripcion);
            return Ok(updatedEstado);
        }

        [HttpDelete("{estadoId}")]
        public async Task<ActionResult> Delete(int estadoId)
        {
            await _estadoService.DeleteEstadoAsync(estadoId);
            return NoContent();
        }
    }
}
