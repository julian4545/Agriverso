
using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IDetalleRecolectorService
    {
        Task<List<DetalleRecolector>> GetAll();
        Task<DetalleRecolector> Get(int detalleRecolectorId);
        Task<DetalleRecolector> CreateDetalleRecolector(int RecoleccionId, int ResiduoId, int Cantidad);
        Task<DetalleRecolector> UpdateDetalleRecolector(int detalleRecolectorId, int RecoleccionId, int ResiduoId, int Cantidad);
        Task<DetalleRecolector> DeleteDetalleRecolectorAsync(int detalleRecolectorId);
    }

    public class DetalleRecolectorService : IDetalleRecolectorService
    {
        private readonly IDetalleRecolectorRepo _detalleRecolectorRepository;

        public DetalleRecolectorService(IDetalleRecolectorRepo detalleRecolectorRepository)
        {
            _detalleRecolectorRepository = detalleRecolectorRepository;
        }

        public async Task<DetalleRecolector> CreateDetalleRecolector(int RecoleccionId, int ResiduoId, int Cantidad)
        {
            return await _detalleRecolectorRepository.CreateDetalleRecolector(RecoleccionId, ResiduoId, Cantidad);
        }

        public async Task<List<DetalleRecolector>> GetAll()
        {
            return await _detalleRecolectorRepository.GetAll();
        }

        public async Task<DetalleRecolector> Get(int detalleRecolectorId)
        {
            return await _detalleRecolectorRepository.Get(detalleRecolectorId);
        }

        public async Task<DetalleRecolector> UpdateDetalleRecolector(int detalleRecolectorId, int RecoleccionId, int ResiduoId, int Cantidad)
        {
            DetalleRecolector existingDetalleRecolector = await _detalleRecolectorRepository.Get(detalleRecolectorId);
            if (existingDetalleRecolector != null)
            {
                existingDetalleRecolector.RecoleccionId = RecoleccionId;
                existingDetalleRecolector.ResiduoId = ResiduoId;
                existingDetalleRecolector.Cantidad = Cantidad;

                return await _detalleRecolectorRepository.UpdateDetalleRecolector(existingDetalleRecolector);
            }
            return null;
        }

        public async Task<DetalleRecolector> DeleteDetalleRecolectorAsync(int detalleRecolectorId)
        {
            DetalleRecolector existingDetalleRecolector = await _detalleRecolectorRepository.Get(detalleRecolectorId);
            if (existingDetalleRecolector != null)
            {
                return await _detalleRecolectorRepository.DeleteDetalleRecolectorAsync(existingDetalleRecolector);
            }
            return null;
        }
    }
}
