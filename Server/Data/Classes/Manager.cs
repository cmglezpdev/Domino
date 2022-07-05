namespace Server.Data.Classes;
using Server.Data.Interfaces;
using System.Diagnostics;

public class Manager {
    static public int MaxIdOfToken;
    static public int[] PassedOfPlayers;
    static public int[] CountTokenByPlayers;
    
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
        for(int i = 0; i < this.players.Length; i ++)
            Manager.CountTokenByPlayers[i] = this.players[i].Count;
    

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

        int idxCurrentPlayer = this.nextPlayer.NextPlayer( this.players );
        System.Console.WriteLine(idxCurrentPlayer);
        bool ToPlay = this.refery.Play(this.players[idxCurrentPlayer]);
        refery.count();
        
        // Actualizar las propiedades staticas
        Manager.CountTokenByPlayers[ idxCurrentPlayer ] -= ( ToPlay ? 1 : 0 );
        Manager.CountTokenByPlayers[ idxCurrentPlayer ] = Math.Max(0, Manager.CountTokenByPlayers[ idxCurrentPlayer ] );
        
        Manager.PassedOfPlayers[ idxCurrentPlayer ] += ( ToPlay ? 0 : 1 );


        PlayInfo CurrInfo = new PlayInfo() {
            Players = Game.PlayersForJson(this.players),
            CurrentPlayer = idxCurrentPlayer,
            points = this.refery.points(idxCurrentPlayer),
            Passed = !ToPlay,
            TokensInBoard = Game.TokensInBoardJson( this.board.TokensInBoard ),
            FinishGame = this.finishGame.FinishGame( this.board, this.players ),
            Winners = Game.PlayersForJson( this.winnersGame.GetWinnersGame(this.board, this.players) )
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
