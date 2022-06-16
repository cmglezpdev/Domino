namespace Server.Data.Classes;
using Server.Data.Interfaces;

// *Jugador que realiza jugadas de forma random
public class RandomPlayer : IPlayer {
    protected List< Token > hand = new List<Token>();
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
    public virtual bool PlayToken( IBoard board ) {

        Random random = new Random();
        int aux = -1;
        bool[] mask = new bool[hand.Count];
        int count = hand.Count;

        while(count != 0){
            aux = random.Next(0, hand.Count);

            if(board.ValidPlay(hand[aux])) {
                board.PlaceToken( hand[aux].Clone() );
                hand.RemoveAt(aux);
                return true;
            }

            if(!mask[aux]) {
                mask[aux] = true;
                count--;
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

    public virtual IPlayer Clone() {
        RandomPlayer clone = new RandomPlayer();
        clone.MakeTokens( this.hand );

        return clone;
    }
}