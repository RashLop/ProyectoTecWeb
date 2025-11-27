using ProyectoTecWeb.Models.Patient;
using ProyectoTecWeb.Models.Patient.Dtos;
using ProyectoTecWeb.Repositories;

namespace ProyectoTecWeb.Services
{
    public class PatientService : IPatientService 
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)=> _patientRepository = patientRepository;

        public async Task<PatientResponse> GetOnePatient(Guid id)
        {
            var pat = await _patientRepository.GetPatient(id);
            if (pat == null) throw new ArgumentException("Patient not in database");
            var response = new PatientResponse
            {
                PatientId = pat.PatientId,
                Name = pat.Name,
                Phone = pat.Phone
            };
            return response;
        }
        public async Task<IEnumerable<PatientResponse>> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            var response = patients.Select(patient => new PatientResponse
            {
                PatientId = patient.PatientId,
                Name = patient.Name,
                Phone = patient.Phone
            }
            );
            return response;
        }

        public  async Task<Patient> CreatePatient(CreatePatientDto dto)
        {
            var newP = new Patient
            {
                PatientId = Guid.NewGuid(),
                UserId = dto.UserId,
                Name = dto.Name,
                Phone = dto.Phone
            }; 
            await _patientRepository.AddAsync(newP);
            await _patientRepository.SaveChangesAsync();
            return newP;
            
        }

        public async Task<Patient> UpdatePatient(UpdatePatientDto dto, Guid id)
        {
            var pat = await _patientRepository.GetPatient(id);
            if (pat == null) throw new ArgumentException("Patient not in Database");
            pat.Name = dto.Name;
            pat.Phone = dto.Phone;
            await _patientRepository.UpdateAsync(pat);
            return pat;
        }

        public async Task Delete(Guid id)
        {

            var byebye = await _patientRepository.GetPatient(id);
            if (byebye == null) throw new ArgumentException("Patient not in Database");
            await _patientRepository.DeleteAsync(byebye);
        }
    }
}
