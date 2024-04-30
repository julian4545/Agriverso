using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IPosicionRecolectorPartidaService
    {
        Task<List<PosicionRecolectorPartida>> GetAll();
        Task<PosicionRecolectorPartida> Get(int posicionRecolectorPartidaId);
        Task<PosicionRecolectorPartida> CreatePosicionRecolectorPartida(int partidaRecolectorId, double latitud, double longitud);
        Task<PosicionRecolectorPartida> UpdatePosicionRecolectorPartida(int posicionRecolectorPartidaId, double latitud, double longitud);
        Task DeletePosicionRecolectorPartidaAsync(int posicionRecolectorPartidaId);
    }

    public class PosicionRecolectorPartidaService : IPosicionRecolectorPartidaService
    {
        private readonly IPosicionRecolectorPartidaRepository _posicionRecolectorPartidaRepository;

        public PosicionRecolectorPartidaService(IPosicionRecolectorPartidaRepository posicionRecolectorPartidaRepository)
        {
            _posicionRecolectorPartidaRepository = posicionRecolectorPartidaRepository;
        }

        public async Task<PosicionRecolectorPartida> CreatePosicionRecolectorPartida(int partidaRecolectorId, double latitud, double longitud)
        {
            return await _posicionRecolectorPartidaRepository.CreatePosicionRecolectorPartida(partidaRecolectorId, latitud, longitud);
        }

        public async Task<List<PosicionRecolectorPartida>> GetAll()
        {
            return await _posicionRecolectorPartidaRepository.GetAll();
        }

        public async Task<PosicionRecolectorPartida> Get(int posicionRecolectorPartidaId)
        {
            return await _posicionRecolectorPartidaRepository.GetById(posicionRecolectorPartidaId);
        }

        public async Task<PosicionRecolectorPartida> UpdatePosicionRecolectorPartida(int posicionRecolectorPartidaId, double latitud, double longitud)
        {
            PosicionRecolectorPartida existingPosicionRecolectorPartida = await _posicionRecolectorPartidaRepository.GetById(posicionRecolectorPartidaId);
            if (existingPosicionRecolectorPartida != null)
            {
                existingPosicionRecolectorPartida.Latitud = latitud;
                existingPosicionRecolectorPartida.Longitud = longitud;

                return await _posicionRecolectorPartidaRepository.UpdatePosicionRecolectorPartida(existingPosicionRecolectorPartida);
            }
            return null;
        }

        public async Task DeletePosicionRecolectorPartidaAsync(int posicionRecolectorPartidaId)
        {
            PosicionRecolectorPartida existingPosicionRecolectorPartida = await _posicionRecolectorPartidaRepository.GetById(posicionRecolectorPartidaId);
            if (existingPosicionRecolectorPartida != null)
            {
                await _posicionRecolectorPartidaRepository.DeletePosicionRecolectorPartidaAsync(existingPosicionRecolectorPartida);
            }
        }
    }
}
