using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repositories
{
    public interface IHistoriesRepository
    {
        Task<History> AddAsync(History history);
        Task<History?> GetOneAsync(Guid id);
        Task<IEnumerable<History>> GetAllAsync();
        Task<History> UpdateAsync(History history);
        Task<bool> DeleteAsync(History history);
        Task SaveChangesAsync();
    }
}
