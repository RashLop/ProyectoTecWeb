using System.Data.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Repository;

namespace ProyectoTecWeb.Services
{
    public class DoctorService (IDoctorRepository db): IDoctorService
    {
        private readonly IDoctorRepository _db = db; 
        public async Task<Doctor?> GetOneDoctor(Guid id) =>  await _db.GetDoctor(id); 
        public async Task<IEnumerable<Doctor?>> GetAllDoctors()
        {
            return await _db.GetAllDoctorsAsync(); 
        }  

        public async Task<Doctor?> CreateDoctor(CreateDoctorDto dto)
        {
            var created = new Doctor
            {
                DoctorId = Guid.NewGuid(),
                UserId = dto.UserId,
                Phone = dto.Phone,
                Specialty = dto.Specialty,
            };
            await _db.AddAsync(created);
            return created; 
        }
    }
}