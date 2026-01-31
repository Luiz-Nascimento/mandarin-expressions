using MandarinExpressionsAPI.Domain;
using MandarinExpressionsAPI.DTOs;
using MandarinExpressionsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandarinExpressionsAPI.Controllers;

[ApiController]
[Route("/expressions")]
public class ExpressionController : ControllerBase
{
    private readonly IExpressionService _service;

    public ExpressionController(IExpressionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExpressionResponseDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ExpressionResponseDto>> GetByIdAsync(Guid id)
    {
        var produto = await _service.GetByIdAsync(id);
        return Ok(produto);
    }

    [HttpGet("random")]
    public async Task<ActionResult<ExpressionResponseDto>> GetRandom([FromQuery] Level level)
    {
        var result = await _service.GetRandomByLevelAsync(level);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ExpressionResponseDto>> Create([FromBody] ExpressionRequestDto request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetRandom), new { level = result.Level }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}