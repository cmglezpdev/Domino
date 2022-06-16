namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class AllforOneDistribution : IDistributeTokens {
    public IPlayer[] DistributeTokens( List<Token> tokens, IPlayer[] players) {
        Random r = new Random();
        int[] playerindex = new int[players.Length];
        for(int i = 0; i < playerindex.Length; i++){
            playerindex[i] = i;
        }
        playerindex = playerindex.OrderBy(x => r.Next()).ToArray();
        
        bool[] mask = new bool[10];

        int IntMax = 0;
        int mark = tokens[0].right.Item1;
        for(int i = 1; i < tokens.Count; i++){
            if(tokens[i].right.Item1 == mark || tokens[i].left.Item1 == mark){
                IntMax++;
            }
        }
        List<List<Token>> hands = new List<List<Token>>();
        
        for(int i = 0; i < players.Length; i++){
            List<Token> aux = new List<Token>();
            int auxI = r.Next(0,IntMax);
            while(mask[auxI]){
                auxI = r.Next(0,IntMax);
            }
            mask[auxI] = true;
            for(int j = 0; j < tokens.Count; j++){
                if(tokens[j].right.Item1 == auxI || tokens[j].left.Item1 == auxI){
                    aux.Add(tokens[j]);
                    tokens.RemoveAt(j);
                    j--;
                }
            }
            hands.Add(aux);    
        }
        for(int i = 0; i < hands.Count; i++){
            while(hands[i].Count < 10) {
                int aux2 = r.Next(0, tokens.Count);
                hands[i].Add(tokens[aux2]);
                tokens.RemoveAt(aux2);   
                }
            players[playerindex[i]].MakeTokens(hands[i]);
        } 
        return players;
    }
}