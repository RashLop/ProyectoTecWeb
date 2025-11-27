using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Models.History;
using ProyectoTecWeb.Models.History.Dtos;
namespace ProyectoTecWeb.Services
{
    public interface IHistoryService
    {
        Task<HistoryResponse?> GetOne(Guid id);
        Task<IEnumerable<HistoryResponse>> GetAll();
        Task<HistoryResponse> CreateAppointment(CreateHistoryDto dto);
        Task<HistoryResponse?> Update(Guid id, UpdateHistoryDto dto);
        Task Delete(Guid id);
    }
}
