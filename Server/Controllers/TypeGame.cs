using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;

namespace ServerApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TypeGameController : ControllerBase
{
    [HttpPost]
    public void  Post( TypeGame options )
    {
       System.Console.WriteLine(options.player);
       System.Console.WriteLine(options.finishGame);
       System.Console.WriteLine(options.winGame);
       System.Console.WriteLine(options.nextPlayer);
       System.Console.WriteLine(options.distributeTokens);
    }

}
