using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface ITipoResiduoService
    {
        Task<List<TipoResiduo>> GetAll();
        Task<TipoResiduo> Get(int tipoResiduoId);
        Task<TipoResiduo> CreateTipoResiduo(string nombre, string descripcion);
        Task<TipoResiduo> UpdateTipoResiduo(int tipoResiduoId, string nombre, string descripcion);
        Task DeleteTipoResiduoAsync(int tipoResiduoId);
    }

    public class TipoResiduoService : ITipoResiduoService
    {
        private readonly ITipoResiduoRepository _tipoResiduoRepository;

        public TipoResiduoService(ITipoResiduoRepository tipoResiduoRepository)
        {
            _tipoResiduoRepository = tipoResiduoRepository;
        }

        public async Task<TipoResiduo> CreateTipoResiduo(string nombre, string descripcion)
        {
            return await _tipoResiduoRepository.CreateTipoResiduo(nombre, descripcion);
        }

        public async Task<List<TipoResiduo>> GetAll()
        {
            return await _tipoResiduoRepository.GetAll();
        }

        public async Task<TipoResiduo> Get(int tipoResiduoId)
        {
            return await _tipoResiduoRepository.GetById(tipoResiduoId);
        }

        public async Task<TipoResiduo> UpdateTipoResiduo(int tipoResiduoId, string nombre, string descripcion)
        {
            TipoResiduo existingTipoResiduo = await _tipoResiduoRepository.GetById(tipoResiduoId);
            if (existingTipoResiduo != null)
            {
                existingTipoResiduo.Nombre = nombre;
                existingTipoResiduo.Descripcion = descripcion;

                return await _tipoResiduoRepository.UpdateTipoResiduo(existingTipoResiduo);
            }
            return null;
        }

        public async Task DeleteTipoResiduoAsync(int tipoResiduoId)
        {
            TipoResiduo existingTipoResiduo = await _tipoResiduoRepository.GetById(tipoResiduoId);
            if (existingTipoResiduo != null)
            {
                await _tipoResiduoRepository.DeleteTipoResiduoAsync(existingTipoResiduo);
            }
        }
    }
}
