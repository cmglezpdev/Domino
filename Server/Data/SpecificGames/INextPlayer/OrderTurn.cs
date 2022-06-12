namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * La lista de jugadores de forma consecutiva 0,1,2,...,n
public class OrderTurn : INextPlayer {
    int cursor = -1;
    public int NextPlayer( IEnumerable< IPlayer > players ) {
        this.cursor = ( this.cursor + 1 ) % players.Count();
        return this.cursor;
    }
}