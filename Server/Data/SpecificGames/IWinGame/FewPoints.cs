namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class FewPoints : IWinGame {
    public IEnumerable<PlayerInfo> GetWinnersGame( IBoard board, IEnumerable<PlayerInfo> players ) {
        List< PlayerInfo > winners = new List<PlayerInfo>();
        foreach( var ply in players ) winners.Add(ply);

        winners.Sort((a, b) => ( a.Points < b.Points ) ? -1 : (a.Points > b.Points) ? 1 : 0 );

        return winners;
    }
}