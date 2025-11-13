
using System.ComponentModel.DataAnnotations;

namespace ProyectoTecWeb.Models.DTO
{
    public record RegisterUserDto
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        ///[RegularExpression( "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$" , ErrorMessage = "Invalid email format." )] 
        public string? Email { get; init; }
        [Required, MaxLength(25), MinLength(8)]
        //[RegularExpression("^[aA-zZ]")]
        public string? Password { get; init;  }
    }
}