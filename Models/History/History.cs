namespace ProyectoTecWeb.Models
{
    public class History
    {
        public Guid HistoryID { get; set; }
        public string BloodType { get; set; } = null!;
        public string Diagnoses { get; set; } = null!;
        public string Medication { get; set; } = null!;
        public string Allergies { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Patient? Patient { get; set; }
        public Guid PatientId { get; set; }


    }
}
