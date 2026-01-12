using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class GendersController : ControllerBase
{
    // Banco em memória
    // private static List<Gender> gender = new List<Gender>();

    private readonly AppDbContext _context;

    public GendersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/gender
    [HttpGet("gender")]
    public async Task<IActionResult> Get()
    {
        var gender = await _context.Gender.ToListAsync();
        return Ok(gender);
    }

    // GET: api/gender/1
    [HttpGet("gender/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var gender = await _context.Gender.FindAsync(id);
        if (gender == null) return NotFound();
        return Ok(gender);
    }

    // POST: api/gender
    [HttpPost("gender")]
    public async Task<IActionResult> Post([FromBody] List<Gender> genders)
    {
        if (genders == null || !genders.Any())
            return BadRequest("Nenhum regex shortcut enviado");

        foreach (var gender in genders)
        {
            _context.Gender.Add(gender);
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = genders.Count });
    }


    // PUT: api/gender/1
    [HttpPut("gender/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Gender genderAtualizado)
    {
        var gender = await _context.Gender.FindAsync(id);
        if (gender == null) return NotFound();

        gender.Name = genderAtualizado.Name;
        gender.Code = genderAtualizado.Code;
        gender.GameGenders = genderAtualizado.GameGenders;
        gender.Timestamp = genderAtualizado.Timestamp;

        await _context.SaveChangesAsync();
        return Ok(gender);
    }

    // DELETE: api/gender/1
    [HttpDelete("gender/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var gender = await _context.Gender.FindAsync(id);
        if (gender == null) return NotFound();

        _context.Gender.Remove(gender);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
