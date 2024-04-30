using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface ITipoResiduoRepository
    {
        Task<List<TipoResiduo>> GetAll();
        Task<TipoResiduo> GetById(int tipoResiduoId);
        Task<TipoResiduo> CreateTipoResiduo(string nombre, string descripcion);
        Task<TipoResiduo> UpdateTipoResiduo(TipoResiduo tipoResiduo);
        Task DeleteTipoResiduoAsync(TipoResiduo tipoResiduo);
    }

    public class TipoResiduoRepository : ITipoResiduoRepository
    {
        private readonly AgriversoDbContext _db;

        public TipoResiduoRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<TipoResiduo> CreateTipoResiduo(string nombre, string descripcion)
        {
            TipoResiduo newTipoResiduo = new TipoResiduo
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            _db.TipoResiduo.Add(newTipoResiduo);
            await _db.SaveChangesAsync();
            return newTipoResiduo;
        }

        public async Task<TipoResiduo> GetById(int tipoResiduoId)
        {
            return await _db.TipoResiduo.FirstOrDefaultAsync(t => t.TipoResiduoId == tipoResiduoId);
        }

        public async Task<List<TipoResiduo>> GetAll()
        {
            return await _db.TipoResiduo.ToListAsync();
        }

        public async Task<TipoResiduo> UpdateTipoResiduo(TipoResiduo tipoResiduo)
        {
            _db.TipoResiduo.Update(tipoResiduo);
            await _db.SaveChangesAsync();
            return tipoResiduo;
        }

        public async Task DeleteTipoResiduoAsync(TipoResiduo tipoResiduo)
        {
            _db.TipoResiduo.Remove(tipoResiduo);
            await _db.SaveChangesAsync();
        }
    }
}
