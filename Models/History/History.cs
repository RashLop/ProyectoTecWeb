namespace ProyectoTecWeb.Models
{
    public class History
    {
        public Guid HistoryID { get; set; }

        required public string BloodType { get; set; }
        public ICollection<string>? Diagnoses { get; set; }
        public ICollection<string>? Medication { get; set; }
        public ICollection<string>? Allergies { get; set; }

        public Patient? patient { get; set; }
        public Guid PatientId { get; set; }


    }
}
