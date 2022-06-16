namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * Distribuye las fichas de forma random entre todos los jugadores
 public class RandomDistribution : IDistributeTokens {
    public IPlayer[] DistributeTokens( List<Token> tokens, IPlayer[] players) {
        Random random = new Random();

        foreach(IPlayer itemP in players){

            List< Token > aux = new List<Token>();
            for ( int j = 0; j < 10; j++) {
                int r = random.Next(0,tokens.Count);
                aux.Add(tokens[r]);
                tokens.RemoveAt(r);
            }
            itemP.MakeTokens(aux);
            // foreach(var x in aux) 
            //     System.Console.WriteLine($"[{x.left.Item1}:{x.right.Item1}]");
            // System.Console.WriteLine();
        }
        return players;
    }
}