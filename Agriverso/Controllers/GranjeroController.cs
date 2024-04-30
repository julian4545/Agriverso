using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GranjeroController : ControllerBase
    {
        private readonly IGranjeroService _granjeroService;

        public GranjeroController(IGranjeroService granjeroService)
        {
            _granjeroService = granjeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Granjero>>> GetAll()
        {
            var granjeros = await _granjeroService.GetAll();
            return Ok(granjeros);
        }

        [HttpGet("{granjeroId}")]
        public async Task<ActionResult<Granjero>> Get(int granjeroId)
        {
            var granjero = await _granjeroService.Get(granjeroId);
            if (granjero == null)
            {
                return NotFound();
            }
            return Ok(granjero);
        }

        [HttpPost]
        public async Task<ActionResult<Granjero>> Create(Granjero granjero)
        {
            var createdGranjero = await _granjeroService.CreateGranjero(granjero.Nombre, granjero.Apellido, granjero.Email, granjero.Contraseña);
            return CreatedAtAction(nameof(Get), new { granjeroId = createdGranjero.GranjeroId }, createdGranjero);
        }

        [HttpPut("{granjeroId}")]
        public async Task<ActionResult<Granjero>> Update(int granjeroId, Granjero granjero)
        {
            if (granjeroId != granjero.GranjeroId)
            {
                return BadRequest();
            }

            var existingGranjero = await _granjeroService.Get(granjeroId);
            if (existingGranjero == null)
            {
                return NotFound();
            }

            existingGranjero.Nombre = granjero.Nombre;
            existingGranjero.Apellido = granjero.Apellido;
            existingGranjero.Email = granjero.Email;
            existingGranjero.Contraseña = granjero.Contraseña;

            var updatedGranjero = await _granjeroService.UpdateGranjero(granjeroId, granjero.Nombre, granjero.Apellido, granjero.Email, granjero.Contraseña);
            return Ok(updatedGranjero);
        }

        [HttpDelete("{granjeroId}")]
        public async Task<ActionResult> Delete(int granjeroId)
        {
            await _granjeroService.DeleteGranjeroAsync(granjeroId);
            return NoContent();
        }
    }
}
