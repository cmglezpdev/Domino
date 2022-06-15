namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class RandomTurn : INextPlayer {
    public int NextPlayer( IEnumerable< IPlayer > players ) {
        Random random = new Random();
        return random.Next(0 , players.Count() - 1);
    }
}