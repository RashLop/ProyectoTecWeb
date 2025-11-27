using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;
namespace ProyectoTecWeb.Services
{
    public interface IHistoryService
    {
        Task<History?> GetOne(Guid id);

        Task<IEnumerable<HistoryResponse>> GetAllHistories();
        Task<History> CreateHistory(CreateHistoryDto dto);
        Task<History> Update(Guid id, UpdateHistoryDto dto);
        Task Delete(Guid id);
    }
}
