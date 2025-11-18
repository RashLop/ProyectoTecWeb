using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Services
{
    public interface IDoctorService
    {
        Task<Doctor?> GetOneDoctor(Guid id); 
        Task<IEnumerable<Doctor?>> GetAllDoctors(); 
    }
}