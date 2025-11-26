namespace ProyectoTecWeb.Models.Patient
{
    public class Appointment
    {
        public Guid AppointmentId { get; set; }

        // Foreign keys
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }

        // Datos de la cita
        public DateTime Date { get; set; }      // Solo la fecha
        public TimeSpan Time { get; set; }      // Solo la hora

        public string Reason { get; set; } = string.Empty;

        /// <summary>
        /// 0 = Pending
        /// 1 = Confirmed
        /// 2 = Cancelled
        /// </summary>
        public int Status { get; set; } = 0;

        public string? Notes { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }

    }
}

