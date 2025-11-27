using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Services;

namespace ProyectoTecWeb.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ConsultorioController : ControllerBase
    {
        private readonly IConsultorioService _doc; 

        public ConsultorioController(IConsultorioService doc)
        {
            _doc = doc; 
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOneConsultorio(Guid id)
        {
            var consultorio = await _doc.GetOneConsultorio(id); 
            return Ok(consultorio); 
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> CreateConsultorio([FromBody] CreateConsultorioDto dto)
        { if(!ModelState.IsValid) return ValidationProblem(ModelState); 
            var created = await _doc.CreateConsultorio(dto); 
            return CreatedAtAction(nameof(GetOneConsultorio), new {id = created.ConsultorioId}, created); 
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ConsultorioResponse> items =await _doc.GetAllConsultorios(); 
            return Ok(items); 
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateConsultorioDto dto, Guid id)
        {
            if(!ModelState.IsValid) return ValidationProblem(ModelState); 
            var Update = await _doc.UpdateConsultorio(dto, id); 
            return CreatedAtAction(nameof(GetOneConsultorio), new {id = Update.ConsultorioId}, Update); 
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _doc.Delete(id); 
            return NoContent(); 
        }
    }
    
}