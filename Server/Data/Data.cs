namespace Server.Data;
using Server.Data.Interfaces;
using Server.Data.Classes;
public class Data {

    // Datos correspondientes a la cantidad de jugadores posibles a seleccionar
    public int[] countPlayers = new int[] {
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10
    };
    // Datos correspondientes al maximo numero que se le podra poner a una ficha
    public int[] maxIdTokens = new int[] {
        3,
        4,
        5,
        6,
        7,
        8,
        9,
    };
    // Cantidad de fichas que se seleccionará por jugador
    public int[] countTokens = new int[] {
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
    };
    // varaiciones de los jugadores
    public Player[] Players = new Player[] {
        new RandomPlayer(),
        new BotaGordaPlayer(),
        new HeuristicPlayer(),
    };
    // Variaciones del tablero
    public IBoard[] Boards = new IBoard[] {
        new UnidimensionalBoard(),
        new MultidimensionalBorad(),
    };
    // Variaciones de como se calcula el valor de una ficha
    public TokenValue[] TokensValue = new TokenValue[] {
        new SumOfFaces(),
        new SubOfFaces(),
        new RareProperties(),
    };
    // Variaciones de como se pueden colocar dos fichas en el tablero
    public IMatch[] Matches = new IMatch[] {
        new EqualFace(),
        new RareEquivalence(),
    };
    // Variaciones de como se distribuye las fichas entre los jugadores
    public IDistributeTokens[] DistributeTokens = new IDistributeTokens[] {
        new RandomDistribution(),
        new AllforOneDistribution(),
    };
    // Variaciones de como se finaliza el juego 
    public IFinishGame[] FinishGames = new IFinishGame[] {
        new AllPassFinish(),
        new APassFinish()
    };
    // variaciones de como se gana el juego
    public IWinGame[] WinGames = new IWinGame[] {
        new FewPoints(),
        new ALotPoints()
    };
    // Variaciones de como se selecciona el proximo jugador
    public INextPlayer[] NextPlayers = new INextPlayer[] {
        new OrderTurn(),
        new RandomTurn(),
        new InvertedTurn(),
        new NextPlayerLongana(),
    };
}

public static class Game {
    public static Manager? manager;
    // "Convertir" una lista de fichas a formato json
    public static List<VertexToken> TokenForJson( IEnumerable<Token> tokens ) {
        List<VertexToken> TokensJson = new List<VertexToken>();
        foreach( var t in tokens ) {
            TokensJson.Add( new VertexToken(){ Left = t[0].Value, Right = t[1].Value } );
        }
        return TokensJson;
    }
    // "Convertir" una lista de jugadores con su informacion a formato json
    public static List<ResPlayer> PlayersForJson( PlayerInfo[] players, Refery refery ) {
        List<ResPlayer> result = new List<ResPlayer>();
        int countPlayers = players.Length;

        for( int i = 0; i < countPlayers; i ++ ) {   
            var p = players[i];
            List<VertexToken> hand = Game.TokenForJson( refery.Hand(i) );
            result.Add(new ResPlayer() {
                Id = p.IDPlayer.Item1,
                Name = p.IDPlayer.Item2,
                Points = p.Points,
                HandTokens = hand.ToArray()
            });
        }
        return result;
    }

    // "Convertir" la informacion del tablero a formato json 
    public static List<List<VertexToken>> TokensInBoardJson ( (Token, string)[,] Tokens ) {
        
        List<List<VertexToken?>> TokensJson = new List<List<VertexToken>>()!;

        for( int i = 0; i < Tokens.GetLength(0); i ++ ) {
            TokensJson.Add( new List<VertexToken>()! );
            for( int j = 0; j < Tokens.GetLength(1); j ++ ) {
                (Token t, string d) = Tokens[i,j];
                if(t == null )
                    TokensJson.Last().Add(null);
                else
                TokensJson[ TokensJson.Count - 1 ].Add( new VertexToken(){ Left = t[0].Value, Right = t[1].Value, Direction = d } );
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
    public string? Direction {get; set;}
}
