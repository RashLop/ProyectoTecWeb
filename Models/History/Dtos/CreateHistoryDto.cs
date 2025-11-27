using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.History.Dtos
{
    public class CreateHistoryDto
    {
        public Guid PatientId { get; set; }
        [Required, MaxLength(5)]
        public string BloodType { get; set; }=string.Empty;
    }
}
