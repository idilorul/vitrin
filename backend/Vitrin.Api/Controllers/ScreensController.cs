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

        if (screen == null) {
            return NotFound(); }// 1) ekran bulunamadıysa 404 döndür
        return Ok(screen);// 2) bulunduysa ekranı döndür
    }
}