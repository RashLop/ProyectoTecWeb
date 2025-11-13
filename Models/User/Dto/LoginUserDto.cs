using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.DTO
{
    public record LoginUserDto
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        string? Email { get; init; }
        [Required, MaxLength(25), MinLength(8)]
        string? Password { get; init; }
    }
}