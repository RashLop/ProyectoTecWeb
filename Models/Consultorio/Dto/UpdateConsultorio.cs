namespace ProyectoTecWeb.Models.DTO{
    public class UpdateConsultorioDto
    {
        public required Guid DoctorId {get; init; }

        public string ConsultorioName {get; set; } =string.Empty; 
        public string Address {get; set; } = string.Empty;
        public string Equipment {get; set; } =string.Empty;
    }
}