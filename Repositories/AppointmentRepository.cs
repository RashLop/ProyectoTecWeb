using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Data;
using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _ctx;

        public AppointmentRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            await _ctx.appointments.AddAsync(appointment);
            return appointment;
        }

        public async Task<Appointment?> GetOneAsync(Guid id)
        {
            return await _ctx.appointments.FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _ctx.appointments
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Time)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDoctorAsync(Guid doctorId)
        {
            return await _ctx.appointments
                .Where(a => a.DoctorId == doctorId)
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Time)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatientAsync(Guid patientId)
        {
            return await _ctx.appointments
                .Where(a => a.PatientId == patientId)
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Time)
                .ToListAsync();
        }

        public async Task<Appointment> UpdateAsync(Appointment appointment)
        {
            _ctx.appointments.Update(appointment);
            return await Task.FromResult(appointment);
        }

        public async Task<bool> DeleteAsync(Appointment appointment)
        {
            _ctx.appointments.Remove(appointment);
            return await Task.FromResult(true);
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> ExistsSameTime(Guid doctorId, Guid patientId, DateTime date, TimeSpan time)
        {
            return await _ctx.appointments.AnyAsync(a =>
                a.Date == date &&
                a.Time == time &&
                (a.DoctorId == doctorId || a.PatientId == patientId)
            );

        }
    }
}