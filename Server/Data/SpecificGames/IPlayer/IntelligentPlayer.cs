namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class IntelligentPlayer : RandomPlayer {
    List<int> InHand = new List<int>();
    public override bool PlayToken(IBoard board)
    {
        
        Organize(board.MaxIdOfToken);
        if(board.TokensInBoard.GetLength(0) == 0){
            Token start = Start();
            board.PlaceToken(start, this.IDPlayer.Item1);
            return true;
        }
        List<int> tokendisponible = Token_Disponible(board.TokensInBoard);
        if(!Can_Play(tokendisponible)) return false;

        Token aux= Select_Play(tokendisponible);
        board.PlaceToken(aux, IDPlayer.Item1);
        return true;
    }
    public override Player Clone() {
        IntelligentPlayer clone = new IntelligentPlayer();
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
                if(hand[i].right.Item1 == maxtokenindex && InHand[hand[i].left.Item1] > auxindex.Item2 ) {
                    auxindex = (i,InHand[hand[i].left.Item1]);
                }
                else if(hand[i].left.Item1 == maxtokenindex && InHand[hand[i].right.Item1] > auxindex.Item2) {
                    auxindex = (i,InHand[hand[i].right.Item1]);
                }
            }
            Token auxtoken = hand[auxindex.Item1];
            hand.RemoveAt(auxindex.Item1);
            return auxtoken;
        }
        (Token,int) aux = doubles[0];
        for(int i = 0; i < doubles.Count; i++) {
            int aux1 = doubles[i].Item1.right.Item1;
            int aux2 = aux.Item1.right.Item1;
            if((InHand[aux1] > InHand[aux2]) || (InHand[aux1] == InHand[aux2] && aux2 > aux1))
                aux = doubles[i];
        }
        hand.RemoveAt(aux.Item2);
        InHand[aux.Item1.right.Item1]--;
        return aux.Item1;
    }
    private void Organize(int maxidtoken) {
        int cant = 0;
        for(int i = 0; i < maxidtoken; i++) {
            for(int j = 0; j < hand.Count; j++) {
                if(i == hand[j].right.Item1 || i == hand[j].left.Item1) {
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
            if(hand[i].right.Item1 == hand[i].left.Item1)
                aux.Add((hand[i],i));
        }
        return aux;
    }
    private List<int> Token_Disponible(Token[,] tokens){
        List<int> disponible = new List<int>();
        for(int i = 0; i < tokens.GetLength(0); i++){
            for(int j = 0; j < tokens.GetLength(1); j++){
                if(tokens[i,j].right.Item2 ){
                    disponible.Add(tokens[i,j].right.Item1);
                }
                if(tokens[i,j].left.Item2 ){
                    disponible.Add(tokens[i,j].left.Item1);
                } 
            }
        }
        return disponible;
    }
    private Token Select_Play(List<int> disponible){
        (int,int) aux = (0,0);
        for(int i = 0; i < disponible.Count; i++) {
            if(InHand[disponible[i]] > aux.Item2){
                aux = (disponible[i], InHand[disponible[i]]);
            }
        }
        Token auxtoken;
        (int,int) aux2 = (0,0);
        for(int i = 0; i < hand.Count; i++){
            if(hand[i].right.Item1 == aux.Item1 && hand[i].left.Item1 > aux2.Item2){
                aux2 = (i,hand[i].left.Item1);
            }
            else if(hand[i].left.Item1 == aux.Item1 && hand[i].right.Item1 > aux2.Item2){
                aux2 = (i,hand[i].right.Item1);
            }
        }
        auxtoken = hand[aux2.Item1];
        hand.RemoveAt(aux.Item1);
        return auxtoken;
    }
    private bool Can_Play(List<int> disponible){
        for(int i = 0; i < InHand.Count; i++){
            if(InHand[disponible[i]] != 0) return true;
        }
        return false;
    }
}