using System.Data.Common;
using ProyectoTecWeb.Models;
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
    }
}