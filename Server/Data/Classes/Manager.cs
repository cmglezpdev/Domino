namespace Server.Data.Classes;
using Server.Data.Interfaces;
using System.Diagnostics;

public class Manager {
    static public int MaxIdOfToken;
    static public int[] PassedOfPlayers = new int[0];
    static public int[] CountTokenByPlayers = new int[0];
    
    Player[] players;
    IBoard board;
    IDistributeTokens distributeTokens;
    IFinishGame finishGame;
    IWinGame winnersGame;
    INextPlayer nextPlayer;
    Refery refery;

    public Manager( IEnumerable<Player> players, IBoard board, 
                    IDistributeTokens distributeTokens, IFinishGame finishGame, 
                    IWinGame winnersGame, INextPlayer nextPlayer ) {

        this.board = board;
        this.distributeTokens = distributeTokens;
        this.finishGame = finishGame;
        this.winnersGame = winnersGame;
        this.nextPlayer = nextPlayer;
        this.refery = new Refery(board);
        
        List<Player> ply = new List<Player>();
        foreach( var pl in players ) ply.Add(pl);
        this.players = ply.ToArray();

        // Actualizar el tamanno de las propiedades staticas
        Manager.PassedOfPlayers = new int[this.players.Length]; 
        Manager.CountTokenByPlayers = new int[this.players.Length];
    }

    public IEnumerable<Player> StartGame( int MaxIdOfToken, int countTokens, TokenValue CalculateValue, IMatch matcher ) {
        Manager.MaxIdOfToken = MaxIdOfToken;
        this.board.SetMatcher(matcher);
        List<Token> bTokens = this.board.BuildTokens( MaxIdOfToken, CalculateValue );
        List<Token>[] htokens = this.distributeTokens.DistributeTokens(bTokens,this.players.Length, countTokens);
        this.refery.MakeTokens(htokens, this.players);
        return this.players;
    }
    
    // Realiza una jugada y devuelve informacion de la jugada
    public PlayInfo GamePlay() { 

        // TODO: EN vez de devolver el indice, devolver el ID
        int idxCurrentPlayer = this.nextPlayer.NextPlayer( this.refery.PlayerInformation );
        bool played = this.refery.Play(this.players[idxCurrentPlayer].IDPlayer.Item1);
        
        // Actualizar las propiedades staticas
        Manager.CountTokenByPlayers[ idxCurrentPlayer ] -= ( played ? 1 : 0 );
        Manager.CountTokenByPlayers[ idxCurrentPlayer ] = Math.Max(0, Manager.CountTokenByPlayers[ idxCurrentPlayer ] );
        
        Manager.PassedOfPlayers[ idxCurrentPlayer ] += ( played ? 0 : 1 );

        PlayInfo CurrInfo = new PlayInfo() {
            Players = Game.PlayersForJson( this.refery.PlayerInformation, this.refery ),
            CurrentPlayer = idxCurrentPlayer,
            points = this.refery.Points(idxCurrentPlayer),
            Passed = !played,
            TokensInBoard = Game.TokensInBoardJson( this.board.TokensInBoard ),
            FinishGame = this.finishGame.FinishGame( this.board, this.refery.PlayerInformation ),
            Winners = Game.PlayersForJson( this.winnersGame.GetWinnersGame(this.board, this.refery.PlayerInformation).ToArray<PlayerInfo>(), this.refery ),
        };

        return CurrInfo;
    }
}

public class PlayInfo {
    public IEnumerable<ResPlayer>? Players {get; set;}
    public int? CurrentPlayer {get; set;} // Indice de jugador en la lista de jugadores
    public int? points {get; set;} // cantidad actual de puntos de jugador
    public bool? Passed {get; set;} // Si el jugador se paso o no
    public IEnumerable< IEnumerable<VertexToken> >? TokensInBoard {get; set;} // Las fichas que estan en el tablero despues de la jugada
    public bool? FinishGame {get; set;} // True si se termino el juego
    public IEnumerable<ResPlayer>? Winners{get; set;} // Lista de ganadores en la ronda actual
}
public class PlayerInfo {
    public int? Count {get; private set;}
    public int? Points {get; private set;}
    public (int, string) IDPlayer {get; private set;}

    public PlayerInfo(int countTokens, int Points, int ID, string name) {
        this.Count = countTokens;
        this.Points = Points;
        this.IDPlayer = (ID, name);
    }
}
