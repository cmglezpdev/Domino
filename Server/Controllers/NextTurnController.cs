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
        PlayInfo info = Game.manager?.GamePlay()!;
        return Ok( info );
    }

}
