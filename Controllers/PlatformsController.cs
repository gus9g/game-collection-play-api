using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class PlatformsController : ControllerBase
{
    // Banco em memória
    // private static List<Platform> platform = new List<Platform>();

    private readonly AppDbContext _context;

    public PlatformsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/platform
    [HttpGet("platform")]
    public async Task<IActionResult> Get()
    {
        var platform = await _context.Platform.ToListAsync();
        return Ok(platform);
    }

    // GET: api/platform/1
    [HttpGet("platform/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var platform = await _context.Platform.FindAsync(id);
        if (platform == null) return NotFound();
        return Ok(platform);
    }

    // POST: api/platform
    [HttpPost("platform")]
    public async Task<IActionResult> Post([FromBody] List<Platform> platforms)
    {
        if (platforms == null || !platforms.Any())
            return BadRequest("Nenhum regex shortcut enviado");

        foreach (var platform in platforms)
        {
            _context.Platform.Add(platform);
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = platforms.Count });
    }


    // PUT: api/platform/1
    [HttpPut("platform/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Platform platformAtualizado)
    {
        var platform = await _context.Platform.FindAsync(id);
        if (platform == null) return NotFound();

        platform.Name = platformAtualizado.Name;
        platform.Code = platformAtualizado.Code;
        platform.GamePlatforms = platformAtualizado.GamePlatforms;
        platform.Timestamp = platformAtualizado.Timestamp;

        await _context.SaveChangesAsync();
        return Ok(platform);
    }

    // DELETE: api/platform/1
    [HttpDelete("platform/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var platform = await _context.Platform.FindAsync(id);
        if (platform == null) return NotFound();

        _context.Platform.Remove(platform);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
