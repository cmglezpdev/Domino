namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class ALotPoints : IWinGame {
    public IEnumerable<Player> GetWinnersGame( IBoard board, IEnumerable<Player> players ) {
        List< Player > winners = new List<Player>();
        foreach( var ply in players ) winners.Add(ply);

        winners.Sort((a, b) => ( a.points > b.points ) ? -1 : (a.points > b.points) ? 1 : 0 );

        return winners;
    }
}