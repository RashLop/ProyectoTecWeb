using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;
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
                try{
                    var data = await _service.GetOne(id);
                    if (data is null) return NotFound();
                return Ok(data);
                }catch(ArgumentException ex)
                {
                    return NotFound(new {message=ex.Message, code =404}); 
                }catch (Exception){
                    return StatusCode(500, new {message = "Internal Server error", code=500}); 
                }
            }
            [Authorize]
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                try{
                    IEnumerable<HistoryResponse> items = await _service.GetAllHistories();
                    return Ok(items);
                }
                catch (Exception)
                {
                    return StatusCode(500, new { message = "Internal server error", code = 500 });
                }
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateHistoryDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState); 

            try
            {
                var created = await _service.CreateHistory(dto);
                return CreatedAtAction(nameof(GetOne),new { id = created.HistoryID },created); 
            }
            catch (Exception){
                return StatusCode(500, new { message = "Error creating medical history", code = 500 });
            }

        }

            [Authorize]
            [HttpPut("{id:guid}")]
            public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHistoryDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState); 

            try
            {
            var updated = await _service.Update(id, dto);
            return Ok(updated); // ✅ 200  (PUT = 200)
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message, code = 404 });
            }catch (Exception){
            return StatusCode(500, new { message = "Error updating medical history", code = 500 });
            }
        }

            [Authorize(Policy = "AdminOnly")]
            [HttpDelete("{id:guid}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                try{
                    await _service.Delete(id);
                    return NoContent();
                }catch (ArgumentException ex){
                    return NotFound(new { message = ex.Message, code = 404 });
                }
            }
        
    }
}
