using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.DTO
{
    public class HistoryResponse
    {
        public Guid HistoryId { get; set; }

        public Guid PatientId { get; set; }

        public string BloodType { get; set; } = string.Empty;

        public string Diagnoses { get; set; } = string.Empty;

        public string Medication { get; set; } = string.Empty;

        public string Allergies { get; set; } = string.Empty;

    }
}
