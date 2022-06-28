namespace Server.Data;
using Server.Data.Interfaces;
using Server.Data.Classes;
public class Data {
    public Player[] Players = new Player[] {
        new RandomPlayer(),
        new BotaGordaPlayer(),
        new IntelligentPlayer(),
    };
    public IBoard[] Boards = new IBoard[] {
        new UnidimensionalBoard(),
        new MultidimensionalBorad(),
    };
    public IDistributeTokens[] DistributeTokens = new IDistributeTokens[] {
        new RandomDistribution(),
        new AllforOneDistribution(),
    };
    public IFinishGame[] FinishGames = new IFinishGame[] {
        new AllPassFinish(),
        new APassFinish()
    };
    public IWinGame[] WinGames = new IWinGame[] {
        new FewPoints(),
        new ALotPoints()
    };
    public INextPlayer[] NextPlayers = new INextPlayer[] {
        new OrderTurn(),
        new RandomTurn(),
        new InvertedTurn(),
        new NextPlayerLongana(),
    };
}

public static class Game {
    public static Manager? manager;
    public static List<VertexToken> TokenForJson( IEnumerable<Token> tokens ) {
        List<VertexToken> TokensJson = new List<VertexToken>();
        foreach( var t in tokens ) {
            TokensJson.Add( new VertexToken(){ Left = t.left.Item1, Right = t.right.Item1 } );
        }
        return TokensJson;
    }
    public static List<ResPlayer> PlayersForJson( IEnumerable<Player> players ) {
        List<ResPlayer> result = new List<ResPlayer>();
        foreach( var p in players ) {   
            List<VertexToken> hand = Game.TokenForJson( p.Hand );
            result.Add(new ResPlayer() {
                Id = p.IDPlayer.Item1,
                Name = p.IDPlayer.Item2,
                Points = p.points,
                HandTokens = hand.ToArray()
            });
        }
        return result;
    }

    public static List<List<VertexToken>> TokensInBoardJson ( Token[,] Tokens ) {
        List<List<VertexToken?>> TokensJson = new List<List<VertexToken>>()!;
        
        for( int i = 0; i < Tokens.GetLength(0); i ++ ) {
            TokensJson.Add( new List<VertexToken>()! );
            for( int j = 0; j < Tokens.GetLength(1); j ++ ) {
                if( Tokens[i, j] == null )
                    TokensJson.Last().Add(null);
                else
                TokensJson[ TokensJson.Count - 1 ].Add( new VertexToken(){ Left = Tokens[i, j].left.Item1, Right = Tokens[i, j].right.Item1 } );
            }
        }

        return TokensJson!;
    }
}




public class ResPlayer {
    public int? Id {get; set;}
    public string? Name {get; set;}
    public int? Points {get; set;}
    public VertexToken[]? HandTokens {get; set;}
}

public class VertexToken {
    public int? Left {get; set;}
    public int? Right {get; set;}
}
