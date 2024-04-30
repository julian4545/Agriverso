using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IResiduoService
    {
        Task<List<Residuo>> GetAll();
        Task<Residuo> Get(int residuoId);
        Task<Residuo> CreateResiduo(string nombre, string descripcion, int tipoResiduoId, int estadoId);
        Task<Residuo> UpdateResiduo(int residuoId, string nombre, string descripcion, int tipoResiduoId, int estadoId);
        Task DeleteResiduoAsync(int residuoId);
    }

    public class ResiduoService : IResiduoService
    {
        private readonly IResiduoRepository _residuoRepository;

        public ResiduoService(IResiduoRepository residuoRepository)
        {
            _residuoRepository = residuoRepository;
        }

        public async Task<Residuo> CreateResiduo(string nombre, string descripcion, int tipoResiduoId, int estadoId)
        {
            return await _residuoRepository.CreateResiduo(nombre, descripcion, tipoResiduoId, estadoId);
        }

        public async Task<List<Residuo>> GetAll()
        {
            return await _residuoRepository.GetAll();
        }

        public async Task<Residuo> Get(int residuoId)
        {
            return await _residuoRepository.GetById(residuoId);
        }

        public async Task<Residuo> UpdateResiduo(int residuoId, string nombre, string descripcion, int tipoResiduoId, int estadoId)
        {
            Residuo existingResiduo = await _residuoRepository.GetById(residuoId);
            if (existingResiduo != null)
            {
                existingResiduo.Nombre = nombre;
                existingResiduo.Descripcion = descripcion;
                existingResiduo.TipoResiduoId = tipoResiduoId;
                existingResiduo.EstadoId = estadoId;

                return await _residuoRepository.UpdateResiduo(existingResiduo);
            }
            return null;
        }

        public async Task DeleteResiduoAsync(int residuoId)
        {
            Residuo existingResiduo = await _residuoRepository.GetById(residuoId);
            if (existingResiduo != null)
            {
                await _residuoRepository.DeleteResiduoAsync(existingResiduo);
            }
        }
    }
}
