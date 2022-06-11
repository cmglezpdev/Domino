namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class NextTurn : INextPlayer {
    int cursor = 0;
    public int NextPlayer( IEnumerable< IPlayer > players ) {
        this.cursor = ( this.cursor + 1 ) % players.Count();
        return this.cursor;
    }
}