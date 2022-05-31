namespace Domino.Interfaces;

public interface INextPlayer {
    IPlayer NextPlayer( IBoard board, IEnumerable< IPlayer > players );
}