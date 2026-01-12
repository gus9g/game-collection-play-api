using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;
using GameCollectionPlayApi.Data;
using GameCollectionPlayApi.Dtos;
namespace GameCollectionPlayApi.Controllers;

[ApiController]
[Route("api")]
public class GameController : ControllerBase
{
    // Banco em memória
    // private static List<Game> gameCollectionPlays = new List<Game>();

    private readonly AppDbContext _context;

    public GameController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/gameCollection
    [HttpGet("gameCollection")]
    public async Task<IActionResult> Get()
    {
        var games = await _context.Game
            .Include(g => g.Status)
            .Include(g => g.GamePlatforms)
                .ThenInclude(gp => gp.Platform)
            .Include(g => g.GameGenders)
                .ThenInclude(gg => gg.Gender)
            .Select(g => new GameReadDto
            {
                Id = g.Id,
                Name = g.Name,
                Cover = g.Cover,
                PersonalRating = g.PersonalRating,
                Status = new StatusDto
                {
                    Id = g.Status.Id,
                    Name = g.Status.Name
                },
                Platforms = g.GamePlatforms
                    .Select(gp => new PlatformDto
                    {
                        Id = gp.Platform.Id,
                        Name = gp.Platform.Name
                    }).ToList(),
                Genders = g.GameGenders
                    .Select(gg => new GenderDto
                    {
                        Id = gg.Gender.Id,
                        Name = gg.Gender.Name
                    }).ToList()
            })
            .ToListAsync();

        return Ok(games);
    }

    // GET: api/gameCollection/1
    [HttpGet("gameCollection/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var game = await _context.Game
            .Include(g => g.Status)
            .Include(g => g.GamePlatforms)
                .ThenInclude(gp => gp.Platform)
            .Include(g => g.GameGenders)
                .ThenInclude(gg => gg.Gender)
            .Where(g => g.Id == id)
            .Select(g => new GameReadDto
            {
                Id = g.Id,
                Name = g.Name,
                Cover = g.Cover,
                PersonalRating = g.PersonalRating,
                Status = new StatusDto
                {
                    Id = g.Status.Id,
                    Name = g.Status.Name
                },
                Platforms = g.GamePlatforms
                    .Select(gp => new PlatformDto
                    {
                        Id = gp.Platform.Id,
                        Name = gp.Platform.Name
                    }).ToList(),
                Genders = g.GameGenders
                    .Select(gg => new GenderDto
                    {
                        Id = gg.Gender.Id,
                        Name = gg.Gender.Name
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        if (game == null) return NotFound();
        return Ok(game);
    }

    [HttpPost("gameCollectionPlays")]
    public async Task<IActionResult> Post([FromBody] List<GameCreateDto> dtos)
    {
        if (dtos == null || !dtos.Any())
            return BadRequest("Nenhum jogo enviado");

        foreach (var dto in dtos)
        {
            // Valida Status
            var statusExists = await _context.Status.AnyAsync(s => s.Id == dto.StatusId);
            if (!statusExists)
                return BadRequest($"Status inválido: {dto.StatusId}");

            var game = new Game
            {
                Name = dto.Name,
                Cover = dto.Cover,
                PersonalRating = dto.PersonalRating,
                StatusId = dto.StatusId
            };

            // Platforms (N:N)
            foreach (var platformId in dto.PlatformIds)
            {
                game.GamePlatforms.Add(new GamePlatform
                {
                    PlatformId = platformId
                });
            }

            // Genders (N:N)
            foreach (var genderId in dto.GenderIds)
            {
                game.GameGenders.Add(new GameGender
                {
                    GenderId = genderId
                });
            }

            _context.Game.Add(game); // ✅ AGORA É ENTITY
        }

        await _context.SaveChangesAsync();

        return Ok(new { count = dtos.Count });
    }


    [HttpPut("gameCollection/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GameCreateDto dto)
    {
        var gameCollection = await _context.Game
            .Include(g => g.GamePlatforms)
            .Include(g => g.GameGenders)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (gameCollection == null)
            return NotFound();

        // Campos simples
        gameCollection.Name = dto.Name;
        gameCollection.Cover = dto.Cover;
        gameCollection.PersonalRating = dto.PersonalRating;
        gameCollection.StatusId = dto.StatusId;

        // Atualiza Platforms (N:N)
        gameCollection.GamePlatforms.Clear();
        foreach (var platformId in dto.PlatformIds)
        {
            gameCollection.GamePlatforms.Add(new GamePlatform
            {
                GameId = id,
                PlatformId = platformId
            });
        }

        // Atualiza Genders (N:N)
        gameCollection.GameGenders.Clear();
        foreach (var genderId in dto.GenderIds)
        {
            gameCollection.GameGenders.Add(new GameGender
            {
                GameId = id,
                GenderId = genderId
            });
        }

        await _context.SaveChangesAsync();
        return Ok(gameCollection);
    }


    // DELETE: api/gameCollection/1
    [HttpDelete("gameCollection/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var gameCollection = await _context.Game.FindAsync(id);
        if (gameCollection == null) return NotFound();

        _context.Game.Remove(gameCollection);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
