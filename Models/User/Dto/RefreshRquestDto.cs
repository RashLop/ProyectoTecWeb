namespace ProyectoTecWeb.Models.DTO
{
    public class RefreshRequestDto {
        public required string AcessToken { get; set;  }
        public required string RefreshToken { get; set; }
        
        public required string TokenType { get; set; }
        
        public int? ExpireIn { get; set;  }
    }
}