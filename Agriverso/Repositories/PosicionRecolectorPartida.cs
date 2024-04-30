using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IPosicionRecolectorPartidaRepository
    {
        Task<List<PosicionRecolectorPartida>> GetAll();
        Task<PosicionRecolectorPartida> GetById(int posicionRecolectorPartidaId);
        Task<PosicionRecolectorPartida> CreatePosicionRecolectorPartida(int partidaRecolectorId, double latitud, double longitud);
        Task<PosicionRecolectorPartida> UpdatePosicionRecolectorPartida(PosicionRecolectorPartida posicionRecolectorPartida);
        Task DeletePosicionRecolectorPartidaAsync(PosicionRecolectorPartida posicionRecolectorPartida);
    }

    public class PosicionRecolectorPartidaRepository : IPosicionRecolectorPartidaRepository
    {
        private readonly AgriversoDbContext _db;

        public PosicionRecolectorPartidaRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<PosicionRecolectorPartida> CreatePosicionRecolectorPartida(int partidaRecolectorId, double latitud, double longitud)
        {
            PosicionRecolectorPartida newPosicionRecolectorPartida = new PosicionRecolectorPartida
            {
                PartidaRecolectorId = partidaRecolectorId,
                Latitud = latitud,
                Longitud = longitud
            };
            _db.PosicionRecolectorPartida.Add(newPosicionRecolectorPartida);
            await _db.SaveChangesAsync();
            return newPosicionRecolectorPartida;
        }

        public async Task<PosicionRecolectorPartida> GetById(int posicionRecolectorPartidaId)
        {
            return await _db.PosicionRecolectorPartida.FirstOrDefaultAsync(p => p.PosicionRecolectorPartidaId == posicionRecolectorPartidaId);
        }

        public async Task<List<PosicionRecolectorPartida>> GetAll()
        {
            return await _db.PosicionRecolectorPartida.ToListAsync();
        }

        public async Task<PosicionRecolectorPartida> UpdatePosicionRecolectorPartida(PosicionRecolectorPartida posicionRecolectorPartida)
        {
            _db.PosicionRecolectorPartida.Update(posicionRecolectorPartida);
            await _db.SaveChangesAsync();
            return posicionRecolectorPartida;
        }

        public async Task DeletePosicionRecolectorPartidaAsync(PosicionRecolectorPartida posicionRecolectorPartida)
        {
            _db.PosicionRecolectorPartida.Remove(posicionRecolectorPartida);
            await _db.SaveChangesAsync();
        }
    }
}
