using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
using GameCollectionPlayApi.Dtos;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class GamePlanningController : ControllerBase
{
    // Banco em memória
    // private static List<GamePlanning> gamePlanningCollectionPlays = new List<GamePlanning>();

    private readonly AppDbContext _context;

    public GamePlanningController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/gamePlanning
    [HttpGet("gamePlanning")]
    public async Task<IActionResult> Get()
    {
        var gamePlannings = await _context.GamePlanning
            .Include(g => g.StatusGamePlanning)
            .Select(g => new GamePlanningReadDto
            {
                GameId = g.GameId,
                FellPlayRating = g.FellPlayRating,
                StartDate = g.StartDate,
                EndDate = g.EndDate,
                GameplayRating = g.GameplayRating,
                StatusGamePlanning = new StatusGamePlanningDto
                {
                    Id = g.StatusGamePlanning.Id,
                    Name = g.StatusGamePlanning.Name
                }
            })
            .ToListAsync();

        return Ok(gamePlannings);
    }

    // GET: api/gamePlanning/1
    [HttpGet("gamePlanning/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var gamePlanning = await _context.GamePlanning
            .Include(g => g.StatusGamePlanning)
            .Where(g => g.GameId == id)
            .Select(g => new GamePlanningReadDto
            {
                GameId = g.GameId,
                FellPlayRating = g.FellPlayRating,
                StartDate = g.StartDate,
                EndDate = g.EndDate,
                GameplayRating = g.GameplayRating,
                StatusGamePlanning = new StatusGamePlanningDto
                {
                    Id = g.StatusGamePlanning.Id,
                    Name = g.StatusGamePlanning.Name
                }
            })
            .FirstOrDefaultAsync();

        if (gamePlanning == null) return NotFound();
        return Ok(gamePlanning);
    }

    [HttpPost("gamePlanning")]
    public async Task<IActionResult> Post([FromBody] List<GamePlanningCreateDto> dtos)
    {
        if (dtos == null || !dtos.Any())
            return BadRequest("Nenhum jogo enviado");

        foreach (var dto in dtos)
        {
            // Valida Status
            var statusExists = await _context.Status.AnyAsync(s => s.Id == dto.StatusGamePlanningId);
            if (!statusExists)
                return BadRequest($"Status inválido: {dto.StatusGamePlanningId}");

            var gamePlanning = new GamePlanning
            {
                GameId = dto.GameId,
                FellPlayRating = dto.FellPlayRating,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                GameplayRating = dto.GameplayRating,
                StatusGamePlanningId = dto.StatusGamePlanningId,
                
            };

            _context.GamePlanning.Add(gamePlanning); // ✅ AGORA É ENTITY
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = dtos.Count });
    }


    [HttpPut("gamePlanning/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GamePlanningCreateDto dto)
    {
        var gamePlanningCollection = await _context.GamePlanning
            .FirstOrDefaultAsync(g => g.GameId == id);

        if (gamePlanningCollection == null)
            return NotFound();

        // Campos simples
        gamePlanningCollection.GameId = dto.GameId;
        gamePlanningCollection.FellPlayRating = dto.FellPlayRating;
        gamePlanningCollection.StartDate = dto.StartDate;
        gamePlanningCollection.EndDate = dto.EndDate;
        gamePlanningCollection.GameplayRating = dto.GameplayRating;
        gamePlanningCollection.StatusGamePlanningId = dto.StatusGamePlanningId;

        await _context.SaveChangesAsync();
        return Ok(gamePlanningCollection);
    }


    // DELETE: api/gamePlanning/1
    [HttpDelete("gamePlanning/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var gamePlanningCollection = await _context.GamePlanning.FindAsync(id);
        if (gamePlanningCollection == null) return NotFound();

        _context.GamePlanning.Remove(gamePlanningCollection);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
