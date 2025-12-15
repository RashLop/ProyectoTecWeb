using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.DTO
{
    public class ForgotPasswordDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]

        public string Email { get; set; } = string.Empty;
       
        [Required, MinLength(8)]

        public string NewPassword { get; set; } = string.Empty;
    }
}
