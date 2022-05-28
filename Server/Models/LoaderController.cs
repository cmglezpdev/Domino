using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;

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

    // [HttpGet("{id}")]
    // public IActionResult Get(int id)
    // {
    //     RPClientes rpCli = new RPClientes();

    //     var cliRet = rpCli.ObtenerCliente(id);

    //     if (cliRet == null)
    //     {
    //         var nf = NotFound("El cliente " + id.ToString() + " no existe.");
    //         return nf;
    //     }

    //     return Ok(cliRet);
    // }

    // [HttpPost("agregar")]
    // public IActionResult AgregarCliente(Cliente nuevoCliente)
    // {
    //     RPClientes rpCli = new RPClientes();
    //     rpCli.Agregar(nuevoCliente);
    //     return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
    // }
}
