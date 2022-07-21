using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Data;
using Server.Data.Classes;

namespace ServerApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class NextTurnController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // Realiza la siguiente jugada y retorna la información del de la misma
        PlayInfo info = Game.manager?.GamePlay()!;
        return Ok( info );
    }

}
