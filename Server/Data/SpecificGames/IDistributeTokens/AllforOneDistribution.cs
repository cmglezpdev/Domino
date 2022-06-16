namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class AllforOneDistribution : IDistributeTokens {
    public IPlayer[] DistributeTokens( List<Token> tokens, IPlayer[] players) {
        Random r = new Random();
        players = players.OrderBy(x => r.Next()).ToArray();
        
        int count = 0;
        bool[] mask = new bool[10];
    
        for(int i = 0; i < players.Length; i++){
            List<Token> aux = new List<Token>();
            int auxI = r.Next(0,9);
            while(mask[auxI]){
                auxI = r.Next(0,9);
            }
            mask[auxI] = true;
            for(int j = 0; j < tokens.Count; j++){
                if(tokens[j].right.Item1 == auxI || tokens[j].left.Item1 == auxI){
                    aux.Add(tokens[j]);
                    tokens.RemoveAt(j);
                    count++;
                    j--;
                }
            }
            while(count < 10) {
                int aux2 = r.Next(0, tokens.Count);
                aux.Add(tokens[aux2]);
                tokens.RemoveAt(aux2);
                count++;    
                }
            count = 0;
            players[i].MakeTokens(aux);
        }
        return players;
    }
}