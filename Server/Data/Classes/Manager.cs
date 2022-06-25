namespace Server.Data.Classes;
using Server.Data.Interfaces;
using System.Diagnostics;

public class Manager {

    public int MaxIdOfToken;
    Player[] players;
    IBoard board;
    IDistributeTokens distributeTokens;
    IFinishGame finishGame;
    IWinGame winnersGame;
    INextPlayer nextPlayer;

    public Manager( IEnumerable<Player> players, IBoard board, 
                    IDistributeTokens distributeTokens, IFinishGame finishGame, 
                    IWinGame winnersGame, INextPlayer nextPlayer ) {

        this.board = board;
        this.distributeTokens = distributeTokens;
        this.finishGame = finishGame;
        this.winnersGame = winnersGame;
        this.nextPlayer = nextPlayer;
        
        List<Player> ply = new List<Player>();
        foreach( var pl in players ) ply.Add(pl);
        this.players = ply.ToArray();
    }

    public IEnumerable<Player> StartGame( int MaxIdOfToken, int countTokens ) {
        List<Token> bTokens = this.board.BuildTokens( MaxIdOfToken );
        this.players = this.distributeTokens.DistributeTokens(bTokens, this.players.ToArray(), countTokens);
        return this.players;
    }
    // Realiza una jugada y devuelve informacion de la jugada
    public PlayInfo GamePlay() { 
        
        int idxCurrentPlayer = this.nextPlayer.NextPlayer( this.players );
        bool ToPlay = this.players[idxCurrentPlayer].PlayToken( this.board );
        
        if( ToPlay ) finishGame.Pass( false );
        else finishGame.Pass( true );
        
        PlayInfo CurrInfo = new PlayInfo() {
            Players = Game.PlayersForJson(this.players),
            CurrentPlayer = idxCurrentPlayer,
            points = this.players[ idxCurrentPlayer ].points,
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