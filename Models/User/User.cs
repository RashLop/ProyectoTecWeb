namespace ProyectoTecWeb.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty;
        public int Phone { get; set; }

        ///
        public string Role { get; set; } = "User"; 
    }
}