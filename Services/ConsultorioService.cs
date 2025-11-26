using System.Data.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Repository;

namespace ProyectoTecWeb.Services
{
    public class ConsultorioService: IConsultorioService
    {
        private readonly IConsultorioRepository _repo; 
        public ConsultorioService(IConsultorioRepository repo) => _repo = repo; 

        public async Task<Consultorio> GetOneConsultorio(Guid id)
        {
            var doc = await _repo.GetConsultorio(id); 
            if(doc is null) throw new ArgumentException("Consultorio not found"); 
            return doc; 
        } 
        public async Task<IEnumerable<ConsultorioResponse>> GetAllConsultorios()
        {
            var items = await _repo.GetAllConsultoriosAsync(); 
            var response = items.Select(doc => new ConsultorioResponse
            {
                ConsultorioId = doc.ConsultorioId,
                ConsultorioName = doc.ConsultorioName,
                Address = doc.Address,
                Equipment = doc.Equipment
            }); 
            return response; 
        } 

        public async Task<Consultorio> CreateConsultorio(CreateConsultorioDto dto)
        {
            
            var created = new Consultorio
            {
                ConsultorioId = Guid.NewGuid(),
                DoctorId = dto.DoctorId,
                ConsultorioName = dto.ConsultorioName,
                Address = dto.Address,
                Equipment= dto.Equipment
            }; 
            await _repo.AddAsync(created); 
            await _repo.SaveChangesAsync(); 
            return created; 
        } 

        public async Task<Consultorio> UpdateConsultorio( UpdateConsultorioDto dto, Guid id)
        {
            var consultorio = await _repo.GetConsultorio(id);
            if(consultorio is null) throw new ArgumentException("Consultorio not found");  
            consultorio.ConsultorioName = dto.ConsultorioName;
            consultorio.Address = dto.Address; 
            consultorio.DoctorId = dto.DoctorId; 
            await _repo.UpadteAsync(consultorio); 
            return consultorio; 
        }

        public async Task Delete(Guid id)
        {
            var deleted = await _repo.GetConsultorio(id); 
            if(deleted is null) throw new ArgumentException("Consultorio not found"); 
            await _repo.DeleteAsync(deleted); 
        }
    }
}