namespace Domino.Classes;
using Domino.Interfaces;
public class WinGame : IWinGame {
    public IEnumerable<IPlayer> GetWinnersGame( IBoard board, IEnumerable<IPlayer> players ) {
        List< IPlayer > winners = new List<IPlayer>();
        foreach( IPlayer item in players) {
            if( item.cant == 0) winners.Add(item);
        }
        if(winners.Count != 0) {
            List < IPlayer > mostpoints = new List<IPlayer>();
            foreach( IPlayer item2 in players){
                mostpoints.Add(item2);
            }
            for(int i = 0; i < mostpoints.Count; i++) {
                for(int j = 0; i < mostpoints.Count; i++) {
                    if( mostpoints[i].points >= mostpoints[j].points ) {
                        IPlayer aux = mostpoints[i];
                        mostpoints[i] = mostpoints[j];
                        mostpoints[j] = aux;
                    }
                }
            }
            for(int i = 0; i < mostpoints.Count; i++ ) {
                if( mostpoints[0].points == mostpoints[i].points) winners.Add(mostpoints[i]);
            }
        }
        return winners;
    }
}