using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResiduoController : ControllerBase
    {
        private readonly IResiduoService _residuoService;

        public ResiduoController(IResiduoService residuoService)
        {
            _residuoService = residuoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Residuo>>> GetAll()
        {
            var residuos = await _residuoService.GetAll();
            return Ok(residuos);
        }

        [HttpGet("{residuoId}")]
        public async Task<ActionResult<Residuo>> Get(int residuoId)
        {
            var residuo = await _residuoService.Get(residuoId);
            if (residuo == null)
            {
                return NotFound();
            }
            return Ok(residuo);
        }

        [HttpPost]
        public async Task<ActionResult<Residuo>> Create(Residuo residuo)
        {
            var createdResiduo = await _residuoService.CreateResiduo(residuo.Nombre, residuo.Descripcion, residuo.TipoResiduoId, residuo.EstadoId);
            return CreatedAtAction(nameof(Get), new { residuoId = createdResiduo.ResiduoId }, createdResiduo);
        }

        [HttpPut("{residuoId}")]
        public async Task<ActionResult<Residuo>> Update(int residuoId, Residuo residuo)
        {
            if (residuoId != residuo.ResiduoId)
            {
                return BadRequest();
            }

            var existingResiduo = await _residuoService.Get(residuoId);
            if (existingResiduo == null)
            {
                return NotFound();
            }

            existingResiduo.Nombre = residuo.Nombre;
            existingResiduo.Descripcion = residuo.Descripcion;
            existingResiduo.TipoResiduoId = residuo.TipoResiduoId;
            existingResiduo.EstadoId = residuo.EstadoId;

            var updatedResiduo = await _residuoService.UpdateResiduo(residuoId, residuo.Nombre, residuo.Descripcion, residuo.TipoResiduoId, residuo.EstadoId);
            return Ok(updatedResiduo);
        }

        [HttpDelete("{residuoId}")]
        public async Task<ActionResult> Delete(int residuoId)
        {
            await _residuoService.DeleteResiduoAsync(residuoId);
            return NoContent();
        }
    }
}
