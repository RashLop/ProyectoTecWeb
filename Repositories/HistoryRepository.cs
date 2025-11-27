using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Data;
using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repositories
{
    public class HistoriesRepository : IHistoriesRepository
    {
        private readonly AppDbContext _ctx;

        public HistoriesRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<History> AddAsync(History history)
        {
            await _ctx.histories.AddAsync(history);
            return history;
        }

        public async Task<bool> DeleteAsync(History history)
        {
            _ctx.histories.Remove(history);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<History>> GetAllAsync()
        {
            return await _ctx.histories
                .OrderBy(a => a.PatientId)
                .ThenBy(a => a.BloodType)
                .ToListAsync();
        }

        public async Task<History?> GetOneAsync(Guid id)=>await _ctx.histories.FirstOrDefaultAsync(x=>x.HistoryID==id);
        

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task<History> UpdateAsync(History history)
        {
            _ctx.histories.Update(history);
            return await Task.FromResult(history);
        }
    }
}
