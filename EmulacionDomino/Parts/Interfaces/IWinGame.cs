namespace Domino.Interfaces;

public interface IWinGame {
    IEnumerable<IPlayer> GetWinnersGame( IBoard board, IEnumerable<IPlayer> players );

}