namespace Domino.Classes;
using Domino.Interfaces;

public class Manager {

    IEnumerable<IPlayer> players;
    IBoard board;
    IDistributeTokens distributeTokens;
    IFinishGame finishGame;
    IWinGame winnersGame;
    INextPlayer nextPlayer;

    public Manager( int countPlayers, IBoard board, IDistributeTokens distributeTokens, IFinishGame finishGame, IWinGame winnersGame, INextPlayer nextPlayer ) {
        this.players = new IPlayer[countPlayers];
        this.board = board;
        this.distributeTokens = distributeTokens;
        this.finishGame = finishGame;
        this.winnersGame = winnersGame;
        this.nextPlayer = nextPlayer;
    }

    void StartGame( int MaxIdOfToken ) {
        IEnumerable< IToken > bTokens = this.board.BuildTokens( MaxIdOfToken );
        this.players = this.distributeTokens.DistributeTokens(bTokens, this.players);
    
        GamePlay();
    }

    IEnumerable< IPlayer > GamePlay() {

        while( true ) {
            IPlayer current = this.nextPlayer.NextPlayer( this.players );
            current.PlayToken( this.board,this.finishGame );
            
            if( this.finishGame.FinishGame( this.board, this.players ) ) {
                return this.winnersGame.GetWinnersGame(this.board, this.players);
            }
        }
    }
}