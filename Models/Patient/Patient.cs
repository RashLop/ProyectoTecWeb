using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Models.Patient
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public User? user { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}