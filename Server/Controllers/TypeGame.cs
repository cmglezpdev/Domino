using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using Server.Data;
using Server.Data.Classes;
using Server.Data.Interfaces;

namespace ServerApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TypeGameController : ControllerBase
{
    [HttpPost]
    public void  Post( TypeGame options )
    {
        // ejecutar el juego
        var data = new Data(); // Cargar tipos de juego
        // Crear jugadores
        List<IPlayer> players = new List<IPlayer>();
        players.Add( new RandomPlayer() ); players[0].IDPlayer = (0, "Marcos");
        players.Add( new RandomPlayer() ); players[0].IDPlayer = (0, "Juanito");
        players.Add( new RandomPlayer() ); players[0].IDPlayer = (0, "Pedrito");
        players.Add( new RandomPlayer() ); players[0].IDPlayer = (0, "Lucas");

        var manager = new Manager( 
                4,
                players,
                new Board(), 
                data.DistributeTokens[ options.distributeTokens ],
                data.FinishGames[ options.finishGame ],
                data.WinGames[ options.winGame ],
                data.NextPlayers[ options.nextPlayer ]
        );

        manager.StartGame( 9 );
    }

}
