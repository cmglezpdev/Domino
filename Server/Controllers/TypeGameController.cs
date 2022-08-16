using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Data;
using Server.Data.Classes;
using Server.Data.Interfaces;

namespace ServerApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TypeGameController : ControllerBase
{
    private IManager _manager;
    // Se inyecta la dependencia del manager como Singleton 
    public TypeGameController(IManager manager)
    {
        _manager = manager;
    }

 
    [HttpPost]
    // options son las opciones que selecciona el cliente, o sea, 
    //  los indices correspondientes al array de cada variacion
    public IActionResult  Post( TypeGame options )
    {
        // Cargar las variaciones del juego (recursos)
        var data = new Data(); 
        
        string[] namesPlayers = new string[]{ "Roberto", "Juan", "Carlos", "Daniel", "Jose", "Abel", "Mario", "Omar", "Felipe", "Agustin", "Fernando"};
        
        // Crear jugadores
        List<Player> players = new List<Player>();
        for(int i = 0; i < data.countPlayers[options.countPlayers]; i ++) {
            players.Add( data.Players[ options.player[i] ].Clone() ); 
            players.Last().IDPlayer = (i, namesPlayers[i]);

        }
        // Instanciando el refery
        Refery  refery = new Refery( data.Boards[ options.board ] );
        // Iniciar el estado del manager y empezar el juego
        _manager.AssignDependencies(
                players,
                data.Boards[ options.board ], 
                data.DistributeTokens[ options.distributeTokens ],
                data.FinishGames[ options.finishGame ],
                data.WinGames[ options.winGame ],
                data.NextPlayers[ options.nextPlayer ],
                refery
        );
        
        // Realiza la primera jugada del juego 
        _manager.StartGame( data.maxIdTokens[options.maxIdTokens], data.countTokens[options.countTokens], data.TokensValue[options.tokenValue], data.Matches[ options.matcher ] );
        //  Parsea la informacion de los jugadores y los retorna
        List<ResPlayer> result = Game.PlayersForJson( refery.PlayerInformation, refery );

        return Ok( result );
    }
}