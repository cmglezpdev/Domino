namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * La lista de jugadores de forma consecutiva 0,1,2,...,n
public class OrderTurn : INextPlayer {
    int cursor = -1;

    public INextPlayer Clone() {
        OrderTurn clone = new OrderTurn();
        clone.cursor = cursor;
        return clone;
    }

    public int NextPlayer( PlayerInfo[] players ) {
        this.cursor = ( this.cursor + 1 ) % players.Count();
        return players[this.cursor].IDPlayer.Item1;
    }
}