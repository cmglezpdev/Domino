namespace Server.Data.Interfaces;
using Server.Data.Classes;
using Server.Data.Delegates;

public interface IManager {
    void AssignDependencies( IEnumerable<Player> players, IBoard board, 
                    IDistributeTokens distributeTokens, IFinishGame finishGame, 
                    IWinGame winnersGame, INextPlayer nextPlayer, Refery refery,  
                    SearchPlayerIndex Search );
    void StartGame( int MaxIdOfToken, int countTokens, ITokenValue CalculateValue, IMatch matcher );
    PlayInfo GamePlay();
}