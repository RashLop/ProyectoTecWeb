using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Models.History.Dtos;
using ProyectoTecWeb.Services;

namespace ProyectoTecWeb.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HistoryController:ControllerBase
    {
        
        
            private readonly IHistoryService _service;

            public HistoryController(IHistoryService service)
            {
                _service = service;
            }

            [Authorize]
            [HttpGet("{id:guid}")]
            public async Task<IActionResult> GetOne(Guid id)
            {
                var data = await _service.GetOne(id);
                if (data is null) return NotFound();
                return Ok(data);
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateHistoryDto dto)
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState);

                var created = await _service.CreateHistory(dto);
                return CreatedAtAction(nameof(GetOne), new { id = created.HistoryID }, created);
            }

            [Authorize]
            [HttpPut("{id:guid}")]
            public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHistoryDto dto)
            {
                var updated = await _service.Update(id, dto);
                if (updated is null) return NotFound();

                return CreatedAtAction(nameof(GetOne), new { id = updated.HistoryID }, updated);
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpDelete("{id:guid}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                await _service.Delete(id);
                return NoContent();
            }
        
    }
}
