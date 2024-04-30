using Agriverso.Model;
using Agriverso.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IRecoleccionService
    {
        Task<List<Recoleccion>> GetAll();
        Task<Recoleccion> Get(int recoleccionId);
        Task<Recoleccion> CreateRecoleccion(int recolectorId, DateTime fecha, string descripcion);
        Task<Recoleccion> UpdateRecoleccion(int recoleccionId, int recolectorId, DateTime fecha, string descripcion);
        Task DeleteRecoleccionAsync(int recoleccionId);
    }

    public class RecoleccionService : IRecoleccionService
    {
        private readonly IRecoleccionRepository _recoleccionRepository;

        public RecoleccionService(IRecoleccionRepository recoleccionRepository)
        {
            _recoleccionRepository = recoleccionRepository;
        }

        public async Task<Recoleccion> CreateRecoleccion(int recolectorId, DateTime fecha, string descripcion)
        {
            return await _recoleccionRepository.CreateRecoleccion(recolectorId, fecha, descripcion);
        }

        public async Task<List<Recoleccion>> GetAll()
        {
            return await _recoleccionRepository.GetAll();
        }

        public async Task<Recoleccion> Get(int recoleccionId)
        {
            return await _recoleccionRepository.GetById(recoleccionId);
        }

        public async Task<Recoleccion> UpdateRecoleccion(int recoleccionId, int recolectorId, DateTime fecha, string descripcion)
        {
            Recoleccion existingRecoleccion = await _recoleccionRepository.GetById(recoleccionId);
            if (existingRecoleccion != null)
            {
                existingRecoleccion.RecolectorId = recolectorId;
                existingRecoleccion.Fecha = fecha;
                existingRecoleccion.Descripcion = descripcion;

                return await _recoleccionRepository.UpdateRecoleccion(existingRecoleccion);
            }
            return null;
        }

        public async Task DeleteRecoleccionAsync(int recoleccionId)
        {
            Recoleccion existingRecoleccion = await _recoleccionRepository.GetById(recoleccionId);
            if (existingRecoleccion != null)
            {
                await _recoleccionRepository.DeleteRecoleccionAsync(existingRecoleccion);
            }
        }
    }
}
