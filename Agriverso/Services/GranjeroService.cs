using Agriverso.Model;
using Agriverso.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agriverso.Services
{
    public interface IGranjeroService
    {
        Task<List<Granjero>> GetAll();
        Task<Granjero> Get(int granjeroId);
        Task<Granjero> CreateGranjero(string nombre, string apellido, string email, string contraseña);
        Task<Granjero> UpdateGranjero(int granjeroId, string nombre = null, string apellido = null, string email = null, string contraseña = null);
        Task DeleteGranjeroAsync(int granjeroId);
    }

    public class GranjeroService : IGranjeroService
    {
        private readonly IGranjeroRepository _granjeroRepository;

        public GranjeroService(IGranjeroRepository granjeroRepository)
        {
            _granjeroRepository = granjeroRepository;
        }

        public async Task<Granjero> CreateGranjero(string nombre, string apellido, string email, string contraseña)
        {
            return await _granjeroRepository.CreateGranjero(nombre, apellido, email, contraseña);
        }

        public async Task<List<Granjero>> GetAll()
        {
            return await _granjeroRepository.GetAll();
        }

        public async Task<Granjero> Get(int granjeroId)
        {
            return await _granjeroRepository.GetById(granjeroId);
        }

        public async Task<Granjero> UpdateGranjero(int granjeroId, string nombre = null, string apellido = null, string email = null, string contraseña = null)
        {
            Granjero existingGranjero = await _granjeroRepository.GetById(granjeroId);
            if (existingGranjero != null)
            {
                if (!string.IsNullOrEmpty(nombre))
                {
                    existingGranjero.Nombre = nombre;
                }

                if (!string.IsNullOrEmpty(apellido))
                {
                    existingGranjero.Apellido = apellido;
                }

                if (!string.IsNullOrEmpty(email))
                {
                    existingGranjero.Email = email;
                }

                if (!string.IsNullOrEmpty(contraseña))
                {
                    existingGranjero.Contraseña = contraseña;
                }

                return await _granjeroRepository.UpdateGranjero(existingGranjero);
            }
            return null;
        }

        public async Task DeleteGranjeroAsync(int granjeroId)
        {
            Granjero existingGranjero = await _granjeroRepository.GetById(granjeroId);
            if (existingGranjero != null)
            {
                await _granjeroRepository.DeleteGranjeroAsync(existingGranjero);
            }
        }
    }
}
