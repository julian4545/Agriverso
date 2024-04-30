using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IPartidaRecolectorRepository
    {
        Task<List<PartidaRecolector>> GetAll();
        Task<PartidaRecolector> GetById(int partidaRecolectorId);
        Task<PartidaRecolector> CreatePartidaRecolector(int recolectorId);
        Task<PartidaRecolector> UpdatePartidaRecolector(PartidaRecolector partidaRecolector);
        Task DeletePartidaRecolectorAsync(PartidaRecolector partidaRecolector);
    }

    public class PartidaRecolectorRepository : IPartidaRecolectorRepository
    {
        private readonly AgriversoDbContext _db;

        public PartidaRecolectorRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<PartidaRecolector> CreatePartidaRecolector(int recolectorId)
        {
            PartidaRecolector newPartidaRecolector = new PartidaRecolector
            {
                RecolectorId = recolectorId
            };
            _db.PartidaRecolector.Add(newPartidaRecolector);
            await _db.SaveChangesAsync();
            return newPartidaRecolector;
        }

        public async Task<PartidaRecolector> GetById(int partidaRecolectorId)
        {
            return await _db.PartidaRecolector.FirstOrDefaultAsync(p => p.PartidaRecolectorId == partidaRecolectorId);
        }

        public async Task<List<PartidaRecolector>> GetAll()
        {
            return await _db.PartidaRecolector.ToListAsync();
        }

        public async Task<PartidaRecolector> UpdatePartidaRecolector(PartidaRecolector partidaRecolector)
        {
            _db.PartidaRecolector.Update(partidaRecolector);
            await _db.SaveChangesAsync();
            return partidaRecolector;
        }

        public async Task DeletePartidaRecolectorAsync(PartidaRecolector partidaRecolector)
        {
            _db.PartidaRecolector.Remove(partidaRecolector);
            await _db.SaveChangesAsync();
        }
    }
}
