using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Data;
using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repository
{
    public class ConsultorioRepository: IConsultorioRepository
    {
        private readonly AppDbContext _ctx;
        public ConsultorioRepository(AppDbContext ctx)
        {
            _ctx = ctx; 
        }
        public Task<Consultorio?> GetConsultorio(Guid id) => _ctx.consultorios.FirstOrDefaultAsync(x => x.ConsultorioId == id); 
        public async Task AddAsync(Consultorio consultorio)
        {
            await _ctx.consultorios.AddAsync(consultorio); 
        } 
        public async Task UpadteAsync(Consultorio consultorio)
        {
            _ctx.consultorios.Update(consultorio);
            await _ctx.SaveChangesAsync(); 
        } 
        public async Task DeleteAsync(Consultorio consultorio)
        {
            
            _ctx.consultorios.Remove(consultorio); 
            await _ctx.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Consultorio>> GetAllConsultoriosAsync()=> await _ctx.consultorios.ToListAsync();  

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync(); 
        }
    }
}