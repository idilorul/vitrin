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
}