using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IGranjeroRepository
    {
        Task<List<Granjero>> GetAll();
        Task<Granjero> GetById(int granjeroId);
        Task<Granjero> CreateGranjero(string nombre, string apellido, string email, string contraseña);
        Task<Granjero> UpdateGranjero(Granjero granjero);
        Task DeleteGranjeroAsync(Granjero granjero);
    }

    public class GranjeroRepository : IGranjeroRepository
    {
        private readonly AgriversoDbContext _db;

        public GranjeroRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<Granjero> CreateGranjero(string nombre, string apellido, string email, string contraseña)
        {
            Granjero newGranjero = new Granjero
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = email,
                Contraseña = contraseña
            };
            _db.Granjero.Add(newGranjero);
            await _db.SaveChangesAsync();
            return newGranjero;
        }

        public async Task<Granjero> GetById(int granjeroId)
        {
            return await _db.Granjero.FirstOrDefaultAsync(g => g.GranjeroId == granjeroId);
        }

        public async Task<List<Granjero>> GetAll()
        {
            return await _db.Granjero.ToListAsync();
        }

        public async Task<Granjero> UpdateGranjero(Granjero granjero)
        {
            _db.Granjero.Update(granjero);
            await _db.SaveChangesAsync();
            return granjero;
        }

        public async Task DeleteGranjeroAsync(Granjero granjero)
        {
            _db.Granjero.Remove(granjero);
            await _db.SaveChangesAsync();
        }
    }
}
