using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class CompatibilidadePcGamerAtualController : ControllerBase
{
    // Banco em memória
    // private static List<CompatibilidadePcGamerAtual> compatibilidadePcGamerAtual = new List<CompatibilidadePcGamerAtual>();

    private readonly AppDbContext _context;

    public CompatibilidadePcGamerAtualController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/compatibilidadePcGamerAtual
    [HttpGet("compatibilidadePcGamerAtual")]
    public async Task<IActionResult> Get()
    {
        var compatibilidadePcGamerAtual = await _context.CompatibilidadePcGamerAtual.ToListAsync();
        return Ok(compatibilidadePcGamerAtual);
    }

    // GET: api/compatibilidadePcGamerAtual/1
    [HttpGet("compatibilidadePcGamerAtual/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var compatibilidadePcGamerAtual = await _context.CompatibilidadePcGamerAtual.FindAsync(id);
        if (compatibilidadePcGamerAtual == null) return NotFound();
        return Ok(compatibilidadePcGamerAtual);
    }

    // POST: api/compatibilidadePcGamerAtual
    [HttpPost("compatibilidadePcGamerAtual")]
    public async Task<IActionResult> Post([FromBody] List<CompatibilidadePcGamerAtual> compatibilidadePcGamerAtuals)
    {
        if (compatibilidadePcGamerAtuals == null || !compatibilidadePcGamerAtuals.Any())
            return BadRequest("Nenhum regex shortcut enviado");

        foreach (var compatibilidadePcGamerAtual in compatibilidadePcGamerAtuals)
        {
            _context.CompatibilidadePcGamerAtual.Add(compatibilidadePcGamerAtual);
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = compatibilidadePcGamerAtuals.Count });
    }


    // PUT: api/compatibilidadePcGamerAtual/1
    [HttpPut("compatibilidadePcGamerAtual/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CompatibilidadePcGamerAtual compatibilidadePcGamerAtualAtualizado)
    {
        var compatibilidadePcGamerAtual = await _context.CompatibilidadePcGamerAtual.FindAsync(id);
        if (compatibilidadePcGamerAtual == null) return NotFound();

        compatibilidadePcGamerAtual.Name = compatibilidadePcGamerAtualAtualizado.Name;
        compatibilidadePcGamerAtual.Code = compatibilidadePcGamerAtualAtualizado.Code;
        compatibilidadePcGamerAtual.Timestamp = compatibilidadePcGamerAtualAtualizado.Timestamp;

        await _context.SaveChangesAsync();
        return Ok(compatibilidadePcGamerAtual);
    }

    // DELETE: api/compatibilidadePcGamerAtual/1
    [HttpDelete("compatibilidadePcGamerAtual/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var compatibilidadePcGamerAtual = await _context.CompatibilidadePcGamerAtual.FindAsync(id);
        if (compatibilidadePcGamerAtual == null) return NotFound();

        _context.CompatibilidadePcGamerAtual.Remove(compatibilidadePcGamerAtual);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
