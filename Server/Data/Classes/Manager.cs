namespace Server.Data.Classes;
using Server.Data.Interfaces;
using System.Diagnostics;

public class Manager {

    IPlayer[] players;
    IBoard board;
    IDistributeTokens distributeTokens;
    IFinishGame finishGame;
    IWinGame winnersGame;
    INextPlayer nextPlayer;

    public Manager( int countPlayers, IEnumerable<IPlayer> players, IBoard board, IDistributeTokens distributeTokens, IFinishGame finishGame, IWinGame winnersGame, INextPlayer nextPlayer ) {
        this.board = board;
        this.distributeTokens = distributeTokens;
        this.finishGame = finishGame;
        this.winnersGame = winnersGame;
        this.nextPlayer = nextPlayer;
        
        List<IPlayer> ply = new List<IPlayer>();
        foreach( var pl in players ) ply.Add(pl);
        this.players = ply.ToArray();
    }

    public IEnumerable<IPlayer> StartGame( int MaxIdOfToken ) {
        IToken[] bTokens = this.board.BuildTokens( MaxIdOfToken );
        this.players = this.distributeTokens.DistributeTokens(bTokens, this.players.ToArray());
        return this.players;
    }
    // Realiza una jugada y devuelve informacion de la jugada
    public PlayInfo GamePlay() { 
        
        int idxCurrentPlayer = this.nextPlayer.NextPlayer( this.players );
        bool ToPlay = this.players[idxCurrentPlayer].PlayToken( this.board );
        
        if( ToPlay ) finishGame.Pass( false );
        else finishGame.Pass( true );
        
        PlayInfo CurrInfo = new PlayInfo() {
            IndexPlayer = idxCurrentPlayer,
            Passed = ToPlay,
            TokensInBoard = this.board.TokensInBoard,
            FinishGame = this.finishGame.FinishGame( this.board, this.players ),
            Winners = this.winnersGame.GetWinnersGame(this.board, this.players)
        };

        return CurrInfo;
    }
}

public class PlayInfo {
    public int? IndexPlayer {get; set;} // Indice de jugador en la lista de jugadores
    public bool? Passed {get; set;} // Si el jugador se paso o no
    public IEnumerable<IToken>? TokensInBoard {get; set;} // Las fichas que estan en el tablero despues de la jugada
    public bool? FinishGame {get; set;} // True si se termino el juego
    public IEnumerable<IPlayer>? Winners{get; set;} // Lista de ganadores en la ronda actual
}