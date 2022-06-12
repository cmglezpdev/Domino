namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * Distribuye las fichas de forma random entre todos los jugadores
 public class RandomDistribution : IDistributeTokens {
    public IPlayer[] DistributeTokens( IToken[] tokens, IPlayer[] players) {
        Random random = new Random();
        List< IToken > auxT = new List<IToken>();
        /* Copying the tokens to a new list. */
        foreach(IToken itemT in tokens){
            auxT.Add(itemT);
        }
        foreach(IPlayer itemP in players){

            List< IToken > aux = new List<IToken>();
            for ( int j = 0; j < 10; j++) {
                int r = random.Next(0,auxT.Count);
                aux.Add(auxT[r]);
                auxT.RemoveAt(r);
            }
            itemP.MakeTokens(aux);
            // foreach(var x in aux) 
            //     System.Console.WriteLine($"[{x.left.Item1}:{x.right.Item1}]");
            // System.Console.WriteLine();
        }
        return players;
    }
}