using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.Patient.Dtos
{
    public class CreatePatientDto
    {

        public Guid UserId { get; set; } //fk user

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, MinLength(8), MaxLength(8)]
        public string Phone { get; set; } = string.Empty;

    }
}
