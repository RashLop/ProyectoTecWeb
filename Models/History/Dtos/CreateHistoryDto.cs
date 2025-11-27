using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.DTO
{
    public class CreateHistoryDto
    {
        public Guid PatientId { get; set; }
        [Required, MaxLength(5), MinLength(4)]
        public string BloodType { get; set; }=string.Empty;
    }
}
