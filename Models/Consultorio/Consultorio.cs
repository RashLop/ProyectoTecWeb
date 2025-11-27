
namespace ProyectoTecWeb.Models
{
    public class Consultorio
{
    public required Guid ConsultorioId { get; init; }
    public string ConsultorioName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Equipment { get; set; } = string.Empty;

    public required Guid DoctorId { get; set; }      // FK
    public Doctor? Doctor { get; set; }      
}

}