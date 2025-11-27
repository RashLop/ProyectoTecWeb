using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Models.Patient;
using ProyectoTecWeb.Models.Patient.Dtos;

namespace ProyectoTecWeb.Services
{
    public interface IPatientService
    {
        Task<PatientResponse> GetOnePatient(Guid id);
        Task<IEnumerable<PatientResponse>> GetAllDoctors();

        Task<Patient> CreateDoctor(CreatePatientDto dto);

        Task<Patient> UpdateDoctor(UpdatePatientDto dto, Guid id);

        Task Delete(Guid id);
    }
}
