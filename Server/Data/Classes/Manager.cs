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

    public void StartGame( int MaxIdOfToken ) {
        IToken[] bTokens = this.board.BuildTokens( MaxIdOfToken );
        this.players = this.distributeTokens.DistributeTokens(bTokens, this.players.ToArray());

        var winners = GamePlay();

        // System.Console.WriteLine();
        // System.Console.WriteLine();
        // System.Console.WriteLine();
        foreach( var x in winners )
            System.Console.WriteLine($"JUGADOR: {x.IDPlayer.Item1} : {x.points}");
    }
    // Lista de ganadores
    IEnumerable< IPlayer > GamePlay() {
        
        while( true ) {
            int idxCurrentPlayer = this.nextPlayer.NextPlayer( this.players );
            bool ToPlay = this.players[idxCurrentPlayer].PlayToken( this.board );
            
            if( ToPlay ) finishGame.Pass( false );
            else finishGame.Pass( true );
            
            if( this.finishGame.FinishGame( this.board, this.players ) ) {            
                return this.winnersGame.GetWinnersGame(this.board, this.players);
            }
        }

    }
}