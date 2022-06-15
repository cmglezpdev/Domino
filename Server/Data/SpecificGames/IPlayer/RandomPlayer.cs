namespace Server.Data.Classes;
using Server.Data.Interfaces;

// *Jugador que realiza jugadas de forma random
public class RandomPlayer : IPlayer {
    List< Token > hand = new List<Token>();
    (int, string) ID; // id number, player name

    public (int, string) IDPlayer {
        get{return this.ID;}
        set{this.ID = value;}
    }
    public void MakeTokens( IEnumerable< Token > tokens ) {
        foreach(Token item in tokens){
            hand.Add(item);
        }
    }    
    public bool PlayToken( IBoard board ) {

        //revisa si es posible jugar alguna ficha
        for( int i = 0; i < hand.Count; i++){
            if(board.ValidPlay(hand[i])){
                
                board.PlaceToken( hand[i].Clone() );
                hand.RemoveAt(i);

                return true;
            }
        }

        return false;
    }
    public int Count {
        get { return hand.Count; }
    }
    public int points {
        get {
            int total = 0;
            // string s = "";
            for( int i = 0; i < hand.Count; i++ ) {
                total += hand[i].value;
                // s += $"[{hand[i].left.Item1}:{hand[i].right.Item1}]";
            }
            // System.Console.WriteLine(s);
            return total;
        }
    }

    public IEnumerable<Token> Hand {
        get{ return this.hand; }
    }
}