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
                var patient = await _pat.GetOnePatient(id);
                return Ok(patient);
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpPost]
            public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto dto)
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState);
                var created = await _pat.CreatePatient(dto);
                return CreatedAtAction(nameof(GetOnePatient), new { id = created.PatientId }, created);
            }
            [Authorize]
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                IEnumerable<PatientResponse> items = await _pat.GetAllPatients();
                return Ok(items);
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
                await _pat.Delete(id);
                return NoContent();
            }
    }
}

