using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repositories
{
    public interface IPatientRepository
    {

        Task<Patient?> GetPatient(Guid id);
        Task AddAsync(Patient patient);
        Task<Patient?> UpdateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        Task SaveChangesAsync();
    }
}
