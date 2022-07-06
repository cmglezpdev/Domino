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
    [HttpPost]
    public IActionResult  Post( TypeGame options )
    {
        // ejecutar el juego
        var data = new Data(); // Cargar tipos de juego
        
        string[] namesPlayers = new string[]{ "Roberto", "Juan", "Carlos", "Daniel", "Jose", "Abel", "Mario", "Omar", "Felipe", "Agustin", "Fernando"};
        
        // Crear jugadores
        List<Player> players = new List<Player>();
        for(int i = 0; i < options.countPlayer; i ++) {
            players.Add( data.Players[ options.player ].Clone() ); 
            players.Last().IDPlayer = (i, namesPlayers[i]);

        }
        Refery  refery = new Refery( data.Boards[ options.board ] );
        // Iniciar el estado del manager y empezar el juego
        Game.manager = new Manager( 
                players,
                data.Boards[ options.board ], 
                data.DistributeTokens[ options.distributeTokens ],
                data.FinishGames[ options.finishGame ],
                data.WinGames[ options.winGame ],
                data.NextPlayers[ options.nextPlayer ],
                refery
        );

        Game.manager.StartGame( options.maxIdTokens, options.countTokensByPlayer, data.TokensValue[options.tokenValue], data.Matches[ options.matcher ] );
        List<ResPlayer> result = Game.PlayersForJson( refery.PlayerInformation, refery );

        return Ok( result );
    }
}