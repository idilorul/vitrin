using Microsoft.AspNetCore.Mvc;
using Vitrin.Api.Data;
using Vitrin.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Vitrin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScreensController : ControllerBase
{
    private readonly VitrinDbContext _db;

    public ScreensController(VitrinDbContext db)
    {
        _db = db;
    }


    [HttpGet]
public async Task<ActionResult<List<Screen>>> GetAll()
{
    var screens = await _db.Screens.ToListAsync();
    return Ok(screens);
}

[HttpGet("{id}")]
public async Task<ActionResult<Screen>> GetById(int id)
{
    var screen = await _db.Screens.FirstOrDefaultAsync(s => s.Id == id);
    if (screen == null) return NotFound();
    return Ok(screen);
}
    [HttpPost]
    public async Task<ActionResult<Screen>> Create(Screen screen)
    {
        screen.CreatedAt = DateTime.UtcNow;
        _db.Screens.Add(screen);
        await _db.SaveChangesAsync();

        return Ok(screen);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Screen>> Update(int id, Screen updated)
    {
        var screen =await _db.Screens.FirstOrDefaultAsync(s => s.Id == id);

        if (screen == null)
        {
            return NotFound();
        }

        screen.Name = updated.Name;
        screen.Location = updated.Location;
        screen.IsOnline = updated.IsOnline;

       await _db.SaveChangesAsync();
        return Ok(screen);
    }

   [HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var screen = await _db.Screens.FirstOrDefaultAsync(s => s.Id == id);
    if (screen == null) return NotFound();
    _db.Screens.Remove(screen);
    await _db.SaveChangesAsync();
    return NoContent();
} 
}