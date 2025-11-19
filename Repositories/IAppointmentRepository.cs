using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetOneAsync(Guid id);

        Task<IEnumerable<Appointment>> GetByDoctorAsync(Guid doctorId);
        Task<IEnumerable<Appointment>> GetByPatientAsync(Guid patientId);

        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Appointment appointment);

        Task SaveChangesAsync();
    }
}
