
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.Patient;

namespace ProyectoTecWeb.Repository
{
    public interface IAppointmentRepository
    {
        Task<Appointment> AddAsync(Appointment appointment);
        Task<Appointment?> GetOneAsync(Guid id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<IEnumerable<Appointment>> GetByDoctorAsync(Guid doctorId);
        Task<IEnumerable<Appointment>> GetByPatientAsync(Guid patientId);
        Task<Appointment> UpdateAsync(Appointment appointment);
        Task<bool> DeleteAsync(Appointment appointment);
        Task SaveChangesAsync();
    }
}
