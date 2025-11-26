using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Data;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.Patient;
namespace ProyectoTecWeb.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _ctx;
        public PatientRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<Patient?> GetPatient(Guid id) => _ctx.patients.FirstOrDefaultAsync(x => x.PatientId == id);
        public async Task AddAsync(Patient patient) 
        {
            await _ctx.patients.AddAsync(patient); 
        }

        public async Task<Patient?> UpdateAsync(Patient patient) 
        {
            _ctx.patients.Update(patient);
            await _ctx.SaveChangesAsync();
            return  patient;
        }
        public async Task DeleteAsync(Patient patient)
        {

            _ctx.patients.Remove(patient);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync() => await _ctx.patients.ToListAsync();

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }


    }
}
