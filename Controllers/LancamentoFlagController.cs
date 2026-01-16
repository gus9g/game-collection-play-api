using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class LancamentoFlagController : ControllerBase
{
    // Banco em memória
    // private static List<LancamentoFlag> lancamentoFlag = new List<LancamentoFlag>();

    private readonly AppDbContext _context;

    public LancamentoFlagController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/lancamentoFlag
    [HttpGet("lancamentoFlag")]
    public async Task<IActionResult> Get()
    {
        var lancamentoFlag = await _context.LancamentoFlag.ToListAsync();
        return Ok(lancamentoFlag);
    }

    // GET: api/lancamentoFlag/1
    [HttpGet("lancamentoFlag/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var lancamentoFlag = await _context.LancamentoFlag.FindAsync(id);
        if (lancamentoFlag == null) return NotFound();
        return Ok(lancamentoFlag);
    }

    // POST: api/lancamentoFlag
    [HttpPost("lancamentoFlag")]
    public async Task<IActionResult> Post([FromBody] List<LancamentoFlag> lancamentoFlags)
    {
        if (lancamentoFlags == null || !lancamentoFlags.Any())
            return BadRequest("Nenhum regex shortcut enviado");

        foreach (var lancamentoFlag in lancamentoFlags)
        {
            _context.LancamentoFlag.Add(lancamentoFlag);
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = lancamentoFlags.Count });
    }


    // PUT: api/lancamentoFlag/1
    [HttpPut("lancamentoFlag/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] LancamentoFlag lancamentoFlagAtualizado)
    {
        var lancamentoFlag = await _context.LancamentoFlag.FindAsync(id);
        if (lancamentoFlag == null) return NotFound();

        lancamentoFlag.Name = lancamentoFlagAtualizado.Name;
        lancamentoFlag.Code = lancamentoFlagAtualizado.Code;
        lancamentoFlag.Timestamp = lancamentoFlagAtualizado.Timestamp;

        await _context.SaveChangesAsync();
        return Ok(lancamentoFlag);
    }

    // DELETE: api/lancamentoFlag/1
    [HttpDelete("lancamentoFlag/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var lancamentoFlag = await _context.LancamentoFlag.FindAsync(id);
        if (lancamentoFlag == null) return NotFound();

        _context.LancamentoFlag.Remove(lancamentoFlag);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
