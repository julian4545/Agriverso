using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IPartidaRecolectorService
    {
        Task<List<PartidaRecolector>> GetAll();
        Task<PartidaRecolector> Get(int partidaRecolectorId);
        Task<PartidaRecolector> CreatePartidaRecolector(int recolectorId);
        Task<PartidaRecolector> UpdatePartidaRecolector(int partidaRecolectorId, int recolectorId);
        Task DeletePartidaRecolectorAsync(int partidaRecolectorId);
    }

    public class PartidaRecolectorService : IPartidaRecolectorService
    {
        private readonly IPartidaRecolectorRepository _partidaRecolectorRepository;

        public PartidaRecolectorService(IPartidaRecolectorRepository partidaRecolectorRepository)
        {
            _partidaRecolectorRepository = partidaRecolectorRepository;
        }

        public async Task<PartidaRecolector> CreatePartidaRecolector(int recolectorId)
        {
            return await _partidaRecolectorRepository.CreatePartidaRecolector(recolectorId);
        }

        public async Task<List<PartidaRecolector>> GetAll()
        {
            return await _partidaRecolectorRepository.GetAll();
        }

        public async Task<PartidaRecolector> Get(int partidaRecolectorId)
        {
            return await _partidaRecolectorRepository.GetById(partidaRecolectorId);
        }

        public async Task<PartidaRecolector> UpdatePartidaRecolector(int partidaRecolectorId, int recolectorId)
        {
            PartidaRecolector existingPartidaRecolector = await _partidaRecolectorRepository.GetById(partidaRecolectorId);
            if (existingPartidaRecolector != null)
            {
                existingPartidaRecolector.RecolectorId = recolectorId;

                return await _partidaRecolectorRepository.UpdatePartidaRecolector(existingPartidaRecolector);
            }
            return null;
        }

        public async Task DeletePartidaRecolectorAsync(int partidaRecolectorId)
        {
            PartidaRecolector existingPartidaRecolector = await _partidaRecolectorRepository.GetById(partidaRecolectorId);
            if (existingPartidaRecolector != null)
            {
                await _partidaRecolectorRepository.DeletePartidaRecolectorAsync(existingPartidaRecolector);
            }
        }
    }
}
