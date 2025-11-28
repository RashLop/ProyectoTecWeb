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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doc; 

        public DoctorController(IDoctorService doc)
        {
            _doc = doc; 
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOneDoctor(Guid id)
        {
            try
            {
                var doctor = await _doc.GetOneDoctor(id);
                return Ok(doctor); // ✅ 200
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message, code = 404 });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal server error", code = 500 });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState); 

            try
            {
                var created = await _doc.CreateDoctor(dto);
                return CreatedAtAction(nameof(GetOneDoctor),new { id = created.DoctorId },created); 
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message, code = 400 });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error creating doctor", code = 500 });
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<DoctorResponse> items = await _doc.GetAllDoctors();
                return Ok(items); 
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal server error", code = 500 });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateDoctorDto dto, Guid id)
        {
            try{
                if(!ModelState.IsValid) return ValidationProblem(ModelState); 
                var Update = await _doc.UpdateDoctor(dto, id); 
                return CreatedAtAction(nameof(GetOneDoctor), new {id = Update.DoctorId}, Update); 
            }catch(ArgumentException ex)
            {
                return NotFound(new {message=ex.Message, code= 404}); 
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try{
                await _doc.Delete(id); 
                return NoContent();
            }catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message, code = 404 });
            }
        }
    }
    
}