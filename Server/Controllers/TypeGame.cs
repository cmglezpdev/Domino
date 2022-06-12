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
        List<Res> result = new List<Res>();
        foreach( var p in ply ) {

            List<VertexToken> hand = new List<VertexToken>();
            foreach( var t in p.Hand ) {
                hand.Add( new VertexToken(){ Left = t.left.Item1, Right = t.right.Item1 } );
            }


            result.Add(new Res() {
                Id = p.IDPlayer.Item1,
                Name = p.IDPlayer.Item2,
                HandTokens = hand.ToArray()
            });
        }

        return Ok( result );
    }
}

public class Res {
    public int? Id {get; set;}
    public string? Name {get; set;}
    public VertexToken[]? HandTokens {get; set;}
}

public class VertexToken {
    public int Left {get; set;}
    public int Right {get; set;}
}