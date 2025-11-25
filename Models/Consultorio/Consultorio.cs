using System.Runtime.InteropServices;

namespace ProyectoTecWeb.Model
{
    public class Consultorio
    {
        public required Guid ConsultorioId {get; init; }
        public string ConsultorioName {get; set; } =string.Empty; 
        public string Address {get; set; } = string.Empty;
        public string Equipment {get; set; } =string.Empty; 
    }
}