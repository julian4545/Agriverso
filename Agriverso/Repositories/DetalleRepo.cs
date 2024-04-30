using Agriverso.dbcontext;
using Agriverso.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Repositories
{
    public interface IDetalleRecolectorRepo
    {
        Task<List<DetalleRecolector>> GetAll();
        Task<DetalleRecolector> Get(int detalleRecolectorId);
        Task<DetalleRecolector> CreateDetalleRecolector(int RecoleccionId, int residuoId, int cantidad);
        Task<DetalleRecolector> UpdateDetalleRecolector(DetalleRecolector detalleRecolector);
        Task<DetalleRecolector> DeleteDetalleRecolectorAsync(DetalleRecolector detalleRecolector);
    }

    public class DetalleRecolectorRepository : IDetalleRecolectorRepo
    {
        private readonly AgriversoDbContext _db;

        public DetalleRecolectorRepository(AgriversoDbContext db)
        {
            _db = db;
        }

        public async Task<DetalleRecolector> CreateDetalleRecolector(int RecoleccionId, int residuoId, int cantidad)
        {
            DetalleRecolector newDetalleRecolector = new DetalleRecolector
            {
                RecoleccionId = RecoleccionId,
                ResiduoId = residuoId,
                Cantidad = cantidad
            };
            _db.DetalleRecolector.Add(newDetalleRecolector);
            await _db.SaveChangesAsync();
            return newDetalleRecolector;
        }

        public async Task<DetalleRecolector> Get(int detalleRecolectorId)
        {
            return await _db.DetalleRecolector.FirstOrDefaultAsync(d => d.DetalleRecolectorId == detalleRecolectorId);
        }

        public async Task<List<DetalleRecolector>> GetAll()
        {
            return await _db.DetalleRecolector.ToListAsync();
        }

        public async Task<DetalleRecolector> UpdateDetalleRecolector(DetalleRecolector detalleRecolector)
        {
            _db.DetalleRecolector.Update(detalleRecolector);
            await _db.SaveChangesAsync();
            return detalleRecolector;
        }

        public async Task<DetalleRecolector> DeleteDetalleRecolectorAsync(DetalleRecolector detalleRecolector)
        {
            _db.DetalleRecolector.Remove(detalleRecolector);
            await _db.SaveChangesAsync();
            return detalleRecolector;
        }
    }
}
