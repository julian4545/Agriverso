using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IEstadoRepository
    {
        Task<List<Estado>> GetAll();
        Task<Estado> GetById(int estadoId);
        Task<Estado> CreateEstado(string nombre, string descripcion);
        Task<Estado> UpdateEstado(Estado estado);
        Task DeleteEstadoAsync(int estadoId);
    }

    public class EstadoRepository : IEstadoRepository
    {
        private readonly AgriversoDbContext _db;

        public EstadoRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<Estado> CreateEstado(string Nombre, string Descripcion)
        {
            Estado newEstado = new Estado
            {
                Nombre = Nombre,
                Descripcion = Descripcion
            };
            _db.Estado.Add(newEstado);
            await _db.SaveChangesAsync();
            return newEstado;
        }

        public async Task<Estado> GetById(int estadoId)
        {
            return await _db.Estado.FirstOrDefaultAsync(e => e.EstadoId == estadoId);
        }

        public async Task<List<Estado>> GetAll()
        {
            return await _db.Estado.ToListAsync();
        }

        public async Task<Estado> UpdateEstado(Estado estado)
        {
            _db.Estado.Update(estado);
            await _db.SaveChangesAsync();
            return estado;
        }

        public async Task DeleteEstadoAsync(int estadoId)
        {
            var estado = await _db.Estado.FindAsync(estadoId);
            if (estado != null)
            {
                _db.Estado.Remove(estado);
                await _db.SaveChangesAsync();
            }
        }
    }
}
