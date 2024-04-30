using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IResiduoRepository
    {
        Task<List<Residuo>> GetAll();
        Task<Residuo> GetById(int residuoId);
        Task<Residuo> CreateResiduo(string nombre, string descripcion, int tipoResiduoId, int estadoId);
        Task<Residuo> UpdateResiduo(Residuo residuo);
        Task DeleteResiduoAsync(Residuo residuo);
    }

    public class ResiduoRepository : IResiduoRepository
    {
        private readonly AgriversoDbContext _db;

        public ResiduoRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<Residuo> CreateResiduo(string nombre, string descripcion, int tipoResiduoId, int estadoId)
        {
            Residuo newResiduo = new Residuo
            {
                Nombre = nombre,
                Descripcion = descripcion,
                TipoResiduoId = tipoResiduoId,
                EstadoId = estadoId
            };
            _db.Residuo.Add(newResiduo);
            await _db.SaveChangesAsync();
            return newResiduo;
        }

        public async Task<Residuo> GetById(int residuoId)
        {
            return await _db.Residuo.FirstOrDefaultAsync(r => r.ResiduoId == residuoId);
        }

        public async Task<List<Residuo>> GetAll()
        {
            return await _db.Residuo.ToListAsync();
        }

        public async Task<Residuo> UpdateResiduo(Residuo residuo)
        {
            _db.Residuo.Update(residuo);
            await _db.SaveChangesAsync();
            return residuo;
        }

        public async Task DeleteResiduoAsync(Residuo residuo)
        {
            _db.Residuo.Remove(residuo);
            await _db.SaveChangesAsync();
        }
    }
}
