using Microsoft.AspNetCore.Http.HttpResults;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;

namespace ProyectoTecWeb.Services
{
    public interface IDoctorService
    {
        Task<Doctor?> GetOneDoctor(Guid id); 
        Task<IEnumerable<Doctor?>> GetAllDoctors(); 

        Task<Doctor?> CreateDoctor(CreateDoctorDto dto); 
    }
}