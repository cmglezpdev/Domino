namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * Distribuye las fichas de forma random entre todos los jugadores
 public class RandomDistribution : IDistributeTokens {
    public List<Token>[] DistributeTokens( List<Token> tokens, int playerofnumber, int countTokens) {
        Random random = new Random();

        List<Token>[] hand = new List<Token>[playerofnumber];

        for(int i = 0; i < hand.Length; i++) {
            List< Token > aux = new List<Token>();
            for ( int j = 0; j < countTokens; j++) {
                int r = random.Next(0,tokens.Count);
                aux.Add(tokens[r]);
                tokens.RemoveAt(r);
            }
            hand[i] = aux;
        }

        return hand;
    }
}