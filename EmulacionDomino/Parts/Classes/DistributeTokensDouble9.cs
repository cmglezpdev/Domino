namespace Domino.Classes;
using Domino.Interfaces;
 public class DistributeTokensDouble9 : IDistributeTokens {
    public IEnumerable<IPlayer> DistributeTokens( IEnumerable< IToken > tokens, IEnumerable<IPlayer> players ) {
        Random random = new Random();
        List< IToken > auxT = new List<IToken>();
        foreach(IToken itemT in tokens){
            auxT.Add(itemT);
        }
        foreach(IPlayer itemP in players){

            List< IToken > aux = new List<IToken>();
            for ( int j = 0; j < 10; j++) {
                int r = random.Next(0,auxT.Count);
                aux[j] = auxT[r];
                auxT.RemoveAt(r);
            }
            itemP.MakeTokens(aux);
        }
        return players;
    }
}