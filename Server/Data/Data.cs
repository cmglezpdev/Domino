namespace Server.Data;
using Server.Data.Interfaces;
using Server.Data.Classes;
public class Data {
    public IPlayer[] Players = new IPlayer[] {
        new RandomPlayer(),
    };
    public IDistributeTokens[] DistributeTokens = new IDistributeTokens[] {
        new RandomDistribution(),
    };
    public IFinishGame[] FinishGames = new IFinishGame[] {
        new Finish(),
    };
    public IWinGame[] WinGames = new IWinGame[] {
        new WinGame(),
    };
    public INextPlayer[] NextPlayers = new INextPlayer[] {
        new NextTurn(),
    };
}

public static class Game {
    public static Manager? manager;
    public static List<VertexToken> TokenForJson( IEnumerable<IToken> tokens ) {
        List<VertexToken> TokensJson = new List<VertexToken>();
        foreach( var t in tokens ) {
            TokensJson.Add( new VertexToken(){ Left = t.left.Item1, Right = t.right.Item1 } );
        }
        return TokensJson;
    }
    public static List<Res> PlayersForJson( IEnumerable<IPlayer> players ) {
        List<Res> result = new List<Res>();
        foreach( var p in players ) {   
            List<VertexToken> hand = Game.TokenForJson( p.Hand );
            result.Add(new Res() {
                Id = p.IDPlayer.Item1,
                Name = p.IDPlayer.Item2,
                HandTokens = hand.ToArray()
            });
        }
        return result;
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

