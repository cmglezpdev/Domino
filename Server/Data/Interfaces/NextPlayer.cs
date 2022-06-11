namespace Server.Data.Interfaces;

public interface INextPlayer {
    int NextPlayer( IEnumerable< IPlayer > players );
}