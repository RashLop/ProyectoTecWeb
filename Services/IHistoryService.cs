using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Models.History;
using ProyectoTecWeb.Models.History.Dtos;
namespace ProyectoTecWeb.Services
{
    public interface IHistoryService
    {
        Task<History?> GetOne(Guid id);
        Task<History> CreateHistory(CreateHistoryDto dto);
        Task<History> Update(Guid id, UpdateHistoryDto dto);
        Task Delete(Guid id);
    }
}
