using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;

namespace ProyectoTecWeb.Services
{
    public interface IPatientService
    {
        Task<PatientResponse> GetOnePatient(Guid id);
        Task<IEnumerable<PatientResponse>> GetAllPatients();

        Task<Patient> CreatePatient(CreatePatientDto dto);

        Task<Patient> UpdatePatient(UpdatePatientDto dto, Guid id);

        Task Delete(Guid id);
    }
}
