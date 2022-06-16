namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class AllforOneDistribution : IDistributeTokens {
    public IPlayer[] DistributeTokens( Token[] tokens, IPlayer[] players) {
        Random r = new Random();
        players = players.OrderBy(x => r.Next()).ToArray();
        
        List<Token> auxT = new List<Token>();
        foreach(Token itemT in tokens){
            auxT.Add(itemT);
        }
        int count = 0;
        bool[] mask = new bool[10];
        

        for(int i = 0; i < players.Length; i++){
            List<Token> aux = new List<Token>();
            int auxI = r.Next(0,9);
            while(!mask[auxI]){
                auxI = r.Next(0,9);
            }
            mask[auxI] = true;
            for(int j = 0; j < tokens.Length; j++){
                if(auxT[j].right.Item1 == auxI || auxT[j].left.Item1 == auxI){
                    aux.Add(auxT[j]);
                    auxT.RemoveAt(j);
                    count++;
                }
            }
            while(count < 10) {
                int aux2 = r.Next(0, auxT.Count);
                aux.Add(auxT[aux2]);
                auxT.RemoveAt(aux2);
                count++;    
                }
            count = 0;
            players[i].MakeTokens(aux);
        }
        return players;
    }
}