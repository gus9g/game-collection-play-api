using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class StatusController : ControllerBase
{
    // Banco em memória
    // private static List<Status> status = new List<Status>();

    private readonly AppDbContext _context;

    public StatusController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/status
    [HttpGet("status")]
    public async Task<IActionResult> Get()
    {
        var status = await _context.Status.ToListAsync();
        return Ok(status);
    }

    // GET: api/status/1
    [HttpGet("status/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var status = await _context.Status.FindAsync(id);
        if (status == null) return NotFound();
        return Ok(status);
    }

    // POST: api/status
    [HttpPost("status")]
    public async Task<IActionResult> Post([FromBody] List<Status> statuss)
    {
        if (statuss == null || !statuss.Any())
            return BadRequest("Nenhum regex shortcut enviado");

        foreach (var status in statuss)
        {
            _context.Status.Add(status);
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = statuss.Count });
    }


    // PUT: api/status/1
    [HttpPut("status/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Status statusAtualizado)
    {
        var status = await _context.Status.FindAsync(id);
        if (status == null) return NotFound();

        status.Name = statusAtualizado.Name;
        status.Code = statusAtualizado.Code;
        status.Games = statusAtualizado.Games;
        status.Timestamp = statusAtualizado.Timestamp;

        await _context.SaveChangesAsync();
        return Ok(status);
    }

    // DELETE: api/status/1
    [HttpDelete("status/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var status = await _context.Status.FindAsync(id);
        if (status == null) return NotFound();

        _context.Status.Remove(status);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
