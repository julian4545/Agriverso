using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IRecoleccionRepository
    {
        Task<List<Recoleccion>> GetAll();
        Task<Recoleccion> GetById(int recoleccionId);
        Task<Recoleccion> CreateRecoleccion(int recolectorId, DateTime fecha, string descripcion);
        Task<Recoleccion> UpdateRecoleccion(Recoleccion recoleccion);
        Task DeleteRecoleccionAsync(Recoleccion recoleccion);
    }

    public class RecoleccionRepository : IRecoleccionRepository
    {
        private readonly AgriversoDbContext _db;

        public RecoleccionRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<Recoleccion> CreateRecoleccion(int recolectorId, DateTime fecha, string descripcion)
        {
            Recoleccion newRecoleccion = new Recoleccion
            {
                RecolectorId = recolectorId,
                Fecha = fecha,
                Descripcion = descripcion
            };
            _db.Recoleccion.Add(newRecoleccion);
            await _db.SaveChangesAsync();
            return newRecoleccion;
        }

        public async Task<Recoleccion> GetById(int recoleccionId)
        {
            return await _db.Recoleccion.FirstOrDefaultAsync(r => r.RecoleccionId == recoleccionId);
        }

        public async Task<List<Recoleccion>> GetAll()
        {
            return await _db.Recoleccion.ToListAsync();
        }

        public async Task<Recoleccion> UpdateRecoleccion(Recoleccion recoleccion)
        {
            _db.Recoleccion.Update(recoleccion);
            await _db.SaveChangesAsync();
            return recoleccion;
        }

        public async Task DeleteRecoleccionAsync(Recoleccion recoleccion)
        {
            _db.Recoleccion.Remove(recoleccion);
            await _db.SaveChangesAsync();
        }
    }
}
