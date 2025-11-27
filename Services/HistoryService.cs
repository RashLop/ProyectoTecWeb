using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Models.History;
using ProyectoTecWeb.Models.History.Dtos;
using ProyectoTecWeb.Repositories;
using ProyectoTecWeb.Repository;
namespace ProyectoTecWeb.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _repo;

        public HistoryService(IHistoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<History> CreateHistory(CreateHistoryDto dto)
        {
            var history = new History {
                HistoryID = Guid.NewGuid(),
                BloodType = dto.BloodType,
                PatientId = dto.PatientId
            };
            await _repo.AddAsync(history);
            await _repo.SaveChangesAsync();
            return history;
        }

        public async Task Delete(Guid id)
        {
            var byebye = await _repo.GetOneAsync(id);
            if (byebye == null) throw new ArgumentException("Medical History not Found");
            await _repo.DeleteAsync(byebye);
            await _repo.SaveChangesAsync();
        }

        public async Task<History?> GetOne(Guid id)
        {
            var his = await _repo.GetOneAsync(id);
            if (his == null) throw new ArgumentException("Medical History not Found");
            return his;
        }

        public async Task<History> Update(Guid id, UpdateHistoryDto dto)
        {
            var updated = await _repo.GetOneAsync(id);
            if (updated == null) throw new ArgumentException("Medical History not Found");
            await _repo.UpdateAsync(updated);
            return updated;
        }
    }
}
