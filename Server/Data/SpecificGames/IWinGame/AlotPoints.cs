namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class ALotPoints : IWinGame {
    public IWinGame Clone() => new ALotPoints();

    // TODO: Si alguien se pega entonces este va a ser el primero siempre.
    public IEnumerable<PlayerInfo> GetWinnersGame( IBoard board, IEnumerable<PlayerInfo> players ) {
        List< PlayerInfo > winners = new List<PlayerInfo>();
        foreach( var ply in players ) winners.Add(ply);

        winners.Sort((a, b) => {
            int Ida = a.IDPlayer.Item1;
            int Idb = b.IDPlayer.Item1;

            if( Manager.CountTokenByPlayers[ Manager.SearchPlayerIndex(Ida) ] == 0 ) return -1;
            if( Manager.CountTokenByPlayers[ Manager.SearchPlayerIndex(Idb) ] == 0 ) return 1;
            
            return ( a.Points > b.Points ) ? -1 : (a.Points > b.Points) ? 1 : 0;
        });


        foreach(var x in winners)
            System.Console.WriteLine($"ID: {x.IDPlayer.Item1} -- Name: {x.IDPlayer.Item2} --> {x.Points}");
        System.Console.WriteLine();

        return winners;
    }
}