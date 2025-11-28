using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Services;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ProyectoTecWeb.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class PatientController: ControllerBase
    {
        
            private readonly IPatientService _pat;

            public PatientController(IPatientService pat)
            {
                _pat = pat;
            }

            [Authorize]
            [HttpGet("{id:guid}")]
            public async Task<IActionResult> GetOnePatient(Guid id)
            {
                try{

                var patient = await _pat.GetOnePatient(id);
                return Ok(patient);
                }catch(ArgumentException ex)
                {
                    return NotFound(new {message=ex.Message, code =404}); 
                }catch (Exception){
                    return StatusCode(500, new {message = "Internal Server error", code=500}); 
                }
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpPost]
            public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto dto)
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState);
                
                try{
                    var created = await _pat.CreatePatient(dto);
                    return CreatedAtAction(nameof(GetOnePatient), new { id = created.PatientId }, created);
                }catch (Exception){
                    return StatusCode(500, new { message = "Error creating medical history", code = 500 });
                }

            }
            [Authorize]
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                try{
                    IEnumerable<PatientResponse> items = await _pat.GetAllPatients();
                    return Ok(items);
                }catch (Exception)
                {
                    return StatusCode(500, new { message = "Internal server error", code = 500 });
                }
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpPut("{id:guid}")]
            public async Task<IActionResult> Update([FromBody] UpdatePatientDto dto, Guid id)
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState);
                var Update = await _pat.UpdatePatient(dto, id);
                return CreatedAtAction(nameof(GetOnePatient), new { id = Update.PatientId }, Update);
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpDelete("{id:guid}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                try{
                    await _pat.Delete(id);
                    return NoContent();
                }catch (ArgumentException ex){
                    return NotFound(new { message = ex.Message, code = 404 });
                }
            }
    }
}

