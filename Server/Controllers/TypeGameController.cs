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
        // Crear jugadores
        List<IPlayer> players = new List<IPlayer>();
        players.Add( new RandomPlayer() ); players[0].IDPlayer = (0, "Marcos");
        players.Add( new RandomPlayer() ); players[1].IDPlayer = (1, "Juanito");
        players.Add( new RandomPlayer() ); players[2].IDPlayer = (2, "Pedrito");
        players.Add( new RandomPlayer() ); players[3].IDPlayer = (3, "Lucas");

        // Iniciar el estado del manager y empezar el juego
        Game.manager = new Manager( 
                4,
                players,
                new Board(), 
                data.DistributeTokens[ options.distributeTokens ],
                data.FinishGames[ options.finishGame ],
                data.WinGames[ options.winGame ],
                data.NextPlayers[ options.nextPlayer ]
        );
        
        // Lista de players con las fichas asignadas
        IEnumerable<IPlayer> ply = Game.manager.StartGame( 9 );
        List<Res> result = Game.PlayersForJson( players );

        return Ok( result );
    }
}