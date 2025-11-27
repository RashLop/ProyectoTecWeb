using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.DTO{
    public class UpdateHistoryDto
    {
        [Required, MaxLength(5), MinLength(4)]
        public string BloodType { get; set; } = string.Empty;
    }
}
