namespace ProyectoTecWeb.Models.Patient.Dtos
{
    public class PatientResponse
    {
        public Guid PatientId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
    }
}
