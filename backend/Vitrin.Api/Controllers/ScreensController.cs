using Microsoft.AspNetCore.Mvc;
using Vitrin.Api.Models;

namespace Vitrin.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScreensController : ControllerBase
{
    private static readonly List<Screen> _screens = new()
    {
        new Screen { Id = 1, Name = "Lobi Ekranı", Location = "Giriş Katı", IsOnline = true, CreatedAt = DateTime.UtcNow },
        new Screen { Id = 2, Name = "Kafeterya Ekranı", Location = "2. Kat", IsOnline = false, CreatedAt = DateTime.UtcNow },
        new Screen { Id = 3, Name = "Toplantı Odası Ekranı", Location = "1. Kat", IsOnline = true, CreatedAt = DateTime.UtcNow },
    };

    [HttpGet]
    public ActionResult<List<Screen>> GetAll()
    {
        return Ok(_screens);
    }

    [HttpGet("{id}")]
    public ActionResult<Screen> GetById(int id)
    {
        var screen = _screens.FirstOrDefault(s => s.Id == id);

        if (screen == null)
        {
            return NotFound();
        }
        return Ok(screen);
    }
    [HttpPost]
    public ActionResult<Screen> Create(Screen screen)
    {   
        screen.Id = _screens.Max(s => s.Id) + 1;
        screen.CreatedAt = DateTime.UtcNow;
        _screens.Add(screen);

        return Ok(screen);
    }

    [HttpPut("{id}")]
    public ActionResult<Screen> Update(int id, Screen updated)
    {
        var screen = _screens.FirstOrDefault(s => s.Id == id);

        if (screen == null)
        {
            return NotFound();
        }

        screen.Name = updated.Name;
        screen.Location = updated.Location;
        screen.IsOnline = updated.IsOnline;

        return Ok(screen);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var screen = _screens.FirstOrDefault(s => s.Id == id);

        if (screen == null)
        {
            return NotFound();
        }

        _screens.Remove(screen);

        return NoContent();
    }
}
