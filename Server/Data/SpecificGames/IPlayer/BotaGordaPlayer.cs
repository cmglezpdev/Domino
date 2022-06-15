namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class BotaGordaPlayer : IPlayer {
    List<Token> hand = new List<Token>();
    (int, string) ID;

    public (int, string) IDPlayer {
        get{return this.ID;}
        set{this.ID = value;}
    }
    public void MakeTokens( IEnumerable< Token > tokens ) {
        foreach(Token item in tokens){
            hand.Add(item);
        }
    }  
    public int Count {
        get { return hand.Count; }
    }
    public int points {
        get {
            int total = 0;
            for( int i = 0; i < hand.Count; i++ ) {
                total += hand[i].value;
            }
            return total;
        }
    }
    public IEnumerable<Token> Hand {
        get{ return this.hand; }
    }
    public bool PlayToken( IBoard board ) {
        int aux = int.MinValue;
        int auxindex = -1;
        for(int i = 1; i < hand.Count; i++){
            if(board.ValidPlay(hand[i])) 
                if(hand[i].value > aux) {
                    auxindex = i;
                    aux = hand[i].value;
            }
        }
        if(auxindex != -1) {
            board.PlaceToken( hand[auxindex].Clone() );
            hand.RemoveAt(auxindex);
            return true;
        }
        return false;
    }  
}