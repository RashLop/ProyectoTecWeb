using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.History.Dtos
{
    public class HistoryResponse
    {
        public Guid PatientId { get; set; }
        [Required, MaxLength(5), MinLength(4)]
        public string BloodType { get; set; } = string.Empty;


    }
}
