using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace ServerApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LoaderController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        InterfaceOfOptions IGOpt = new InterfaceOfOptions();

        return Ok( IGOpt.GetGeneralOptions() );
    }

}