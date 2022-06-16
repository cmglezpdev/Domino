namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class ALotPoints : IWinGame {
    public IEnumerable<IPlayer> GetWinnersGame( IBoard board, IEnumerable<IPlayer> players ) {
        List< IPlayer > winners = new List<IPlayer>();
        foreach( var ply in players ) winners.Add(ply);

        winners.Sort((a, b) => ( a.points > b.points ) ? -1 : (a.points > b.points) ? 1 : 0 );

        return winners;
    }
}