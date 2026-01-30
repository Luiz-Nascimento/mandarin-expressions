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

    [HttpGet("random")]
    public async Task<IActionResult> GetRandom([FromQuery] Level level)
    {
        try
        {
            var result = await _service.GetRandomByLevelAsync(level);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No expressions found for the given level");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ExpressionRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetRandom), new { level = result.Level }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}