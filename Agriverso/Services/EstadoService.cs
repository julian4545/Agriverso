using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IEstadoService
    {
        Task<List<Estado>> GetAll();
        Task<Estado> Get(int estadoId);
        Task<Estado> CreateEstado(string nombre, string descripcion);
        Task<Estado> UpdateEstado(int estadoId, string nombre, string descripcion);
        Task DeleteEstadoAsync(int estadoId);
    }

    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public async Task<Estado> CreateEstado(string nombre, string descripcion)
        {
            return await _estadoRepository.CreateEstado(nombre, descripcion);
        }

        public async Task<List<Estado>> GetAll()
        {
            return await _estadoRepository.GetAll();
        }

        public async Task<Estado> Get(int estadoId)
        {
            return await _estadoRepository.GetById(estadoId);
        }

        public async Task<Estado> UpdateEstado(int estadoId, string nombre, string descripcion)
        {
            Estado existingEstado = await _estadoRepository.GetById(estadoId);
            if (existingEstado != null)
            {
                if (!string.IsNullOrEmpty(nombre))
                {
                    existingEstado.Nombre = nombre;
                }

                if (!string.IsNullOrEmpty(descripcion))
                {
                    existingEstado.Descripcion = descripcion;
                }

                return await _estadoRepository.UpdateEstado(existingEstado);
            }
            return null;
        }

        public async Task DeleteEstadoAsync(int estadoId)
        {
            Estado existingEstado = await _estadoRepository.GetById(estadoId);
            if (existingEstado != null)
            {
              //  await _estadoRepository.DeleteEstadoAsync(existingEstado);
            }
        }
    }
}
