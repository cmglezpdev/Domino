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
        // Intancia la clase que contiene las oipciones ha seleccionar por el cliente
        InterfaceOfOptions IGOpt = new InterfaceOfOptions();

        return Ok( IGOpt.GetGeneralOptions() );
    }

}
