using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repository
{
    public interface IConsultorioRepository
    {
        Task<Consultorio?> GetConsultorio(Guid id); 
        Task AddAsync(Consultorio Consultorio); 
        Task UpadteAsync(Consultorio Consultorio); 
        Task DeleteAsync(Consultorio Consultorio); 
        Task<IEnumerable<Consultorio>> GetAllConsultoriosAsync(); 

        Task SaveChangesAsync(); 
    }
}