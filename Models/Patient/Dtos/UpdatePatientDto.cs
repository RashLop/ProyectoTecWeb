using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.Patient.Dtos
{
    public class UpdatePatientDto
    {
        [Required, StringLength(100)]
        public required string Name { get; init; }
        [Required, MinLength(8), MaxLength(8)]

        public required string Phone { get; init; } 
    }
}
