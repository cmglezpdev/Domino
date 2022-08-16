using Microsoft.AspNetCore.Mvc;
using Server.Data.Classes;
using Server.Data.Interfaces;

namespace ServerApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class NextTurnController : ControllerBase
{
    private IManager _manager;

    public NextTurnController(IManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult Get()
    {
        // Realiza la siguiente jugada y retorna la información del de la misma
        PlayInfo info = _manager.GamePlay()!;
        return Ok( info );
    }

}
