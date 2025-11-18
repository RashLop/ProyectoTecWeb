using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Data;
using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repository
{
    public class DoctorRepository (AppDbContext ctx) : IDoctorRepository
    {
        private readonly AppDbContext _ctx = ctx; 

        public Task<Doctor?> GetDoctor(Guid id) => _ctx.doctors.FirstOrDefaultAsync(x => x.DoctorId == id); 
        public async Task AddAsync(Doctor doctor)
        {
            await _ctx.doctors.AddAsync(doctor); 
        } 
        public async Task UpadteAsync(Doctor doctor)
        {
            _ctx.doctors.Update(doctor);
        } 
        public async Task DeleteAsync(Doctor doctor)
        {
            
            _ctx.doctors.Remove(doctor); 
        }

        public async Task<IEnumerable<Doctor?>> GetAllDoctorsAsync()=> await _ctx.doctors.ToListAsync();  

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync(); 
        }

        
    }
}