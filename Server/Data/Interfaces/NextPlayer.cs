namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface INextPlayer {
    int NextPlayer( IEnumerable< Player > players );
}