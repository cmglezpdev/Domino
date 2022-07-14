namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class ALotPoints : IWinGame {
    public IWinGame Clone() => new ALotPoints();

    // El que mas punto tenga gana, pero si alguien se pega gana entoces el
    public IEnumerable<PlayerInfo> GetWinnersGame( IBoard board, IEnumerable<PlayerInfo> players ) {
        List< PlayerInfo > winners = new List<PlayerInfo>();
        foreach( var ply in players ) winners.Add(ply);

        winners.Sort((a, b) => {
            if( a.Points == 0 ) return -1;
            if( b.Points == 0 ) return 1;
            return ( a.Points > b.Points ) ? -1 : (a.Points < b.Points) ? 1 : 0;
        });

        return winners;
    }
}