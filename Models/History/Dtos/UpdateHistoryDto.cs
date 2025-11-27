using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.DTO{
    public class UpdateHistoryDto
    {
        [Required]
        public string Diagnoses { get; set; } = string.Empty;

        [Required]
        public string Medication { get; set; } = string.Empty;

        [Required]
        public string Allergies { get; set; } = string.Empty;
    }
}
