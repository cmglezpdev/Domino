namespace Domino.Interfaces;

public interface INextPlayer {
    IPlayer NextPlayer( IEnumerable< IPlayer > players );
}