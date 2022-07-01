namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class HeuristicPlayer : RandomPlayer {
    List<int> InHand = new List<int>();
    public override bool PlayToken(IBoard board)
    {
        
        Organize(board.MaxIdOfToken);
        if(board.TokensInBoard.Length == 0){
            Token start = Start();
            board.PlaceToken(start, this.IDPlayer.Item1);
            return true;
        }

        (int,int) aux = (0,0);
        for(int i = 0; i < hand.Count; i++) {
            int a = InHand[hand[i][0].Value] + InHand[hand[i][1].Value];
            if(board.ValidPlay(hand[i]) && a > aux.Item2){
                aux = (i, a);
            }
        }
        if(aux.Item2 != 0){
            Token auxtoken = hand[aux.Item1];
            hand.RemoveAt(aux.Item1);
            board.PlaceToken(auxtoken, this.IDPlayer.Item1);
            return true;
        }
        return false;
    }
    public override Player Clone() {
        HeuristicPlayer clone = new HeuristicPlayer();
        clone.MakeTokens( this.hand );

        return clone;
    }
    private Token Start() {
        List<(Token,int)> doubles = Double();
        if(doubles.Count == 0) { 
            int maxtokenindex = 0; 
            for(int i = 0; i < InHand.Count; i++) {
                if(InHand[i] > InHand[maxtokenindex])
                    maxtokenindex = i;
            }
            (int,int) auxindex = (0,0);
            for(int i = 0; i < hand.Count; i++) {
                if(hand[i][1].Value == maxtokenindex && InHand[hand[i][0].Value] > auxindex.Item2 ) {
                    auxindex = (i,InHand[hand[i][0].Value]);
                }
                else if(hand[i][0].Value == maxtokenindex && InHand[hand[i][1].Value] > auxindex.Item2) {
                    auxindex = (i,InHand[hand[i][1].Value]);
                }
            }
            Token auxtoken = hand[auxindex.Item1];
            hand.RemoveAt(auxindex.Item1);
            return auxtoken;
        }
        (Token,int) aux = doubles[0];
        for(int i = 0; i < doubles.Count; i++) {
            int aux1 = doubles[i].Item1[1].Value;
            int aux2 = aux.Item1[1].Value;
            if((InHand[aux1] > InHand[aux2]) || (InHand[aux1] == InHand[aux2] && aux2 > aux1))
                aux = doubles[i];
        }
        hand.RemoveAt(aux.Item2);
        InHand[aux.Item1[1].Value]--;
        return aux.Item1;
    }
    private void Organize(int maxidtoken) {
        InHand.Clear();
        int cant = 0;
        for(int i = 0; i < maxidtoken + 1; i++) {
            for(int j = 0; j < hand.Count; j++) {
                if(i == hand[j][1].Value || i == hand[j][0].Value) {
                    cant++;
                }
            }
            InHand.Add(cant);
            cant = 0;
        }
    }
    private List<(Token,int)> Double() {
        List<(Token,int)> aux = new List<(Token,int)>();
        for(int i = 0; i < hand.Count; i++) {
            if(hand[i][1].Value == hand[i][0].Value)
                aux.Add((hand[i],i));
        }
        return aux;
    }
}