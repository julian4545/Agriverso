using Agriverso.Model;
using Agriverso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoResiduoController : ControllerBase
    {
        private readonly ITipoResiduoService _tipoResiduoService;

        public TipoResiduoController(ITipoResiduoService tipoResiduoService)
        {
            _tipoResiduoService = tipoResiduoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoResiduo>>> GetAll()
        {
            var tiposResiduo = await _tipoResiduoService.GetAll();
            return Ok(tiposResiduo);
        }

        [HttpGet("{tipoResiduoId}")]
        public async Task<ActionResult<TipoResiduo>> Get(int tipoResiduoId)
        {
            var tipoResiduo = await _tipoResiduoService.Get(tipoResiduoId);
            if (tipoResiduo == null)
            {
                return NotFound();
            }
            return Ok(tipoResiduo);
        }

        [HttpPost]
        public async Task<ActionResult<TipoResiduo>> Create(TipoResiduo tipoResiduo)
        {
            var createdTipoResiduo = await _tipoResiduoService.CreateTipoResiduo(tipoResiduo.Nombre, tipoResiduo.Descripcion);
            return CreatedAtAction(nameof(Get), new { tipoResiduoId = createdTipoResiduo.TipoResiduoId }, createdTipoResiduo);
        }

        [HttpPut("{tipoResiduoId}")]
        public async Task<ActionResult<TipoResiduo>> Update(int tipoResiduoId, TipoResiduo tipoResiduo)
        {
            if (tipoResiduoId != tipoResiduo.TipoResiduoId)
            {
                return BadRequest();
            }

            var existingTipoResiduo = await _tipoResiduoService.Get(tipoResiduoId);
            if (existingTipoResiduo == null)
            {
                return NotFound();
            }

            existingTipoResiduo.Nombre = tipoResiduo.Nombre;
            existingTipoResiduo.Descripcion = tipoResiduo.Descripcion;

            var updatedTipoResiduo = await _tipoResiduoService.UpdateTipoResiduo(tipoResiduoId, tipoResiduo.Nombre, tipoResiduo.Descripcion);
            return Ok(updatedTipoResiduo);
        }

        [HttpDelete("{tipoResiduoId}")]
        public async Task<ActionResult> Delete(int tipoResiduoId)
        {
            await _tipoResiduoService.DeleteTipoResiduoAsync(tipoResiduoId);
            return NoContent();
        }
    }
}
