namespace Server.Data.Classes;
using Server.Data.Interfaces;

// Distribuye todas las fichas repartiendo todas las disponibles con un mismo número a cada jugador
public class AllforOneDistribution : IDistributeTokens {
    public IDistributeTokens Clone() => new AllforOneDistribution();

    public List<Token>[] DistributeTokens( List<Token> tokens,int playerofnumber, int countTokens ) {
        Random r = new Random();
        
        // Guardamos un índice para cada jugador
        int[] playerindex = new int[playerofnumber];
        for(int i = 0; i < playerindex.Length; i++){
            playerindex[i] = i;
        }
        // y los ordenamos de manera random para poder repartir las fichas
        playerindex = playerindex.OrderBy(x => r.Next()).ToArray();

        // Selecciono un la primera ficha y cuento todas las fichas que tienen una de sus caras igual a la seleccionada
        int IntMax = 0; 
        int mark = tokens[0][1].Value;
        for(int i = 1; i < tokens.Count; i++){
            if(tokens[i][1].Value == mark || tokens[i][0].Value == mark){
                IntMax++;
            }
        }
        bool[] mask = new bool[IntMax];
        List<List<Token>> hands = new List<List<Token>>();
                
        // Recorro todos los valores posibles que pueda tener una cara de una ficha
        for(int i = 0; i < playerofnumber; i++){
            List<Token> aux = new List<Token>();
            int auxI = r.Next(0,IntMax);
            while(mask[auxI]){
                auxI = r.Next(0,IntMax);
            }
            mask[auxI] = true;
            for(int j = 0; (j < tokens.Count) && (aux.Count != countTokens); j++){
                if(tokens[j][1].Value == auxI || tokens[j][0].Value == auxI){
                    aux.Add(tokens[j]);
                    tokens.RemoveAt(j);
                    j--;
                }
            }
            hands.Add(aux);    
        }
        for(int i = 0; i < hands.Count; i++){
            while(hands[i].Count < countTokens) {
                int aux2 = r.Next(0, tokens.Count);
                hands[i].Add(tokens[aux2]);
                tokens.RemoveAt(aux2);   
                }
        } 
        return hands.ToArray();
    }
}