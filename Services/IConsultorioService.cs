using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;

namespace ProyectoTecWeb.Services
{
        public interface IConsultorioService
    {
        Task<Consultorio> GetOneConsultorio(Guid id); 
        Task<IEnumerable<ConsultorioResponse>> GetAllConsultorios(); 

        Task<Consultorio> CreateConsultorio(CreateConsultorioDto dto); 

        Task<Consultorio> UpdateConsultorio(UpdateConsultorioDto dto, Guid id); 

        Task Delete (Guid id); 

    }
}