using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IRecolectorService
    {
        Task<List<Recolector>> GetAll();
        Task<Recolector> Get(int recolectorId);
        Task<Recolector> CreateRecolector(int granjeroId, string nombre, string apellido);
        Task<Recolector> UpdateRecolector(int recolectorId, int granjeroId, string nombre, string apellido);
        Task DeleteRecolectorAsync(int recolectorId);
    }

    public class RecolectorService : IRecolectorService
    {
        private readonly IRecolectorRepository _recolectorRepository;

        public RecolectorService(IRecolectorRepository recolectorRepository)
        {
            _recolectorRepository = recolectorRepository;
        }

        public async Task<Recolector> CreateRecolector(int granjeroId, string nombre, string apellido)
        {
            return await _recolectorRepository.CreateRecolector(granjeroId, nombre, apellido);
        }

        public async Task<List<Recolector>> GetAll()
        {
            return await _recolectorRepository.GetAll();
        }

        public async Task<Recolector> Get(int recolectorId)
        {
            return await _recolectorRepository.GetById(recolectorId);
        }

        public async Task<Recolector> UpdateRecolector(int recolectorId, int granjeroId, string nombre, string apellido)
        {
            Recolector existingRecolector = await _recolectorRepository.GetById(recolectorId);
            if (existingRecolector != null)
            {
                existingRecolector.GranjeroId = granjeroId;
                existingRecolector.Nombre = nombre;
                existingRecolector.Apellido = apellido;

                return await _recolectorRepository.UpdateRecolector(existingRecolector);
            }
            return null;
        }

        public async Task DeleteRecolectorAsync(int recolectorId)
        {
            Recolector existingRecolector = await _recolectorRepository.GetById(recolectorId);
            if (existingRecolector != null)
            {
                await _recolectorRepository.DeleteRecolectorAsync(existingRecolector);
            }
        }
    }
}
