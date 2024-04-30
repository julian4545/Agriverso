using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IRecolectorRepository
    {
        Task<List<Recolector>> GetAll();
        Task<Recolector> GetById(int recolectorId);
        Task<Recolector> CreateRecolector(int granjeroId, string nombre, string apellido);
        Task<Recolector> UpdateRecolector(Recolector recolector);
        Task DeleteRecolectorAsync(Recolector recolector);
    }

    public class RecolectorRepository : IRecolectorRepository
    {
        private readonly AgriversoDbContext _db;

        public RecolectorRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<Recolector> CreateRecolector(int granjeroId, string nombre, string apellido)
        {
            Recolector newRecolector = new Recolector
            {
                GranjeroId = granjeroId,
                Nombre = nombre,
                Apellido = apellido
            };
            _db.Recolector.Add(newRecolector);
            await _db.SaveChangesAsync();
            return newRecolector;
        }

        public async Task<Recolector> GetById(int recolectorId)
        {
            return await _db.Recolector.FirstOrDefaultAsync(r => r.RecolectorId == recolectorId);
        }

        public async Task<List<Recolector>> GetAll()
        {
            return await _db.Recolector.ToListAsync();
        }

        public async Task<Recolector> UpdateRecolector(Recolector recolector)
        {
            _db.Recolector.Update(recolector);
            await _db.SaveChangesAsync();
            return recolector;
        }

        public async Task DeleteRecolectorAsync(Recolector recolector)
        {
            _db.Recolector.Remove(recolector);
            await _db.SaveChangesAsync();
        }
    }
}
