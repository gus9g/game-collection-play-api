using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class CompatibilidadeNotebookGamerAtualController : ControllerBase
{
    // Banco em memória
    // private static List<CompatibilidadeNotebookGamerAtual> compatibilidadeNotebookGamerAtual = new List<CompatibilidadeNotebookGamerAtual>();

    private readonly AppDbContext _context;

    public CompatibilidadeNotebookGamerAtualController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/compatibilidadeNotebookGamerAtual
    [HttpGet("compatibilidadeNotebookGamerAtual")]
    public async Task<IActionResult> Get()
    {
        var compatibilidadeNotebookGamerAtual = await _context.CompatibilidadeNotebookGamerAtual.ToListAsync();
        return Ok(compatibilidadeNotebookGamerAtual);
    }

    // GET: api/compatibilidadeNotebookGamerAtual/1
    [HttpGet("compatibilidadeNotebookGamerAtual/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var compatibilidadeNotebookGamerAtual = await _context.CompatibilidadeNotebookGamerAtual.FindAsync(id);
        if (compatibilidadeNotebookGamerAtual == null) return NotFound();
        return Ok(compatibilidadeNotebookGamerAtual);
    }

    // POST: api/compatibilidadeNotebookGamerAtual
    [HttpPost("compatibilidadeNotebookGamerAtual")]
    public async Task<IActionResult> Post([FromBody] List<CompatibilidadeNotebookGamerAtual> compatibilidadeNotebookGamerAtuals)
    {
        if (compatibilidadeNotebookGamerAtuals == null || !compatibilidadeNotebookGamerAtuals.Any())
            return BadRequest("Nenhum regex shortcut enviado");

        foreach (var compatibilidadeNotebookGamerAtual in compatibilidadeNotebookGamerAtuals)
        {
            _context.CompatibilidadeNotebookGamerAtual.Add(compatibilidadeNotebookGamerAtual);
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = compatibilidadeNotebookGamerAtuals.Count });
    }


    // PUT: api/compatibilidadeNotebookGamerAtual/1
    [HttpPut("compatibilidadeNotebookGamerAtual/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CompatibilidadeNotebookGamerAtual compatibilidadeNotebookGamerAtualAtualizado)
    {
        var compatibilidadeNotebookGamerAtual = await _context.CompatibilidadeNotebookGamerAtual.FindAsync(id);
        if (compatibilidadeNotebookGamerAtual == null) return NotFound();

        compatibilidadeNotebookGamerAtual.Name = compatibilidadeNotebookGamerAtualAtualizado.Name;
        compatibilidadeNotebookGamerAtual.Code = compatibilidadeNotebookGamerAtualAtualizado.Code;
        compatibilidadeNotebookGamerAtual.Timestamp = compatibilidadeNotebookGamerAtualAtualizado.Timestamp;

        await _context.SaveChangesAsync();
        return Ok(compatibilidadeNotebookGamerAtual);
    }

    // DELETE: api/compatibilidadeNotebookGamerAtual/1
    [HttpDelete("compatibilidadeNotebookGamerAtual/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var compatibilidadeNotebookGamerAtual = await _context.CompatibilidadeNotebookGamerAtual.FindAsync(id);
        if (compatibilidadeNotebookGamerAtual == null) return NotFound();

        _context.CompatibilidadeNotebookGamerAtual.Remove(compatibilidadeNotebookGamerAtual);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
