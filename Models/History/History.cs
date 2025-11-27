using ProyectoTecWeb.Models.Patient;
namespace ProyectoTecWeb.Models.History
{
    public class History
    {
        public Guid HistoryID { get; set; }

        required public string BloodType { get; set; }
        public ICollection<string>? Diagnoses { get; set; }
        public ICollection<string>? Medication { get; set; }
        public ICollection<string>? Allergies { get; set; }

        required public ProyectoTecWeb.Models.Patient.Patient patient { get; set; }


    }
}
