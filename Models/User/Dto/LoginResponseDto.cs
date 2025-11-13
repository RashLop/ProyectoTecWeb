namespace ProyectoTecWeb.Models.DTO
{
    public class LoginResponseDto
    {
        public required UserResponse user { get; set; }

        public required RefreshRequestDto Token { get; set;  }
        
    }


}