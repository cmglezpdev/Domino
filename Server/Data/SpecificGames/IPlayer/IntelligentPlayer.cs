namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class IntelligentPlayer : RandomPlayer {
    List<int> InHand = new List<int>();
    public override bool PlayToken(IBoard board)
    {
        
        Organize(board.MaxIdOfToken);
        if(board.TokensInBoard.Length == 0){
            Token start = Start();
            board.PlaceToken(start, this.IDPlayer.Item1);
            return true;
        }
        List<int> tokendisponible = Token_Disponible(board.TokensInBoard);
        if(!Can_Play(tokendisponible)) return false;

        Token aux= Select_Play(tokendisponible);
        board.PlaceToken(aux, this.IDPlayer.Item1);
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
    private List<int> Token_Disponible(Token[,] tokens){
        List<int> disponible = new List<int>();
        for(int i = 0; i < tokens.GetLength(0); i++){
            for(int j = 0; j < tokens.GetLength(1); j++){
                if(!tokens[i,j][1].Played ){
                    disponible.Add(tokens[i,j][1].Value);
                }
                if(!tokens[i,j][0].Played ){
                    disponible.Add(tokens[i,j][0].Value);
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
            if(hand[i][1].Value == aux.Item1 && hand[i][0].Value > aux2.Item2){
                aux2 = (i,hand[i][0].Value);
            }
            else if(hand[i][0].Value == aux.Item1 && hand[i][1].Value > aux2.Item2){
                aux2 = (i,hand[i][1].Value);
            }
        }
        auxtoken = hand[aux2.Item1];
        hand.RemoveAt(aux2.Item1);
        return auxtoken;
    }
    private bool Can_Play(List<int> disponible){
        for(int i = 0; i < disponible.Count; i++){
            if(InHand[disponible[i]] != 0) return true;
        }
        return false;
    }
}