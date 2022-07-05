namespace Server.Data.Classes;
using Server.Data.Interfaces;

// *Jugador que realiza jugadas de forma random
public class RandomPlayer : Player {
    public override bool PlayToken( IBoard board, Token[] hand) {

        Random random = new Random();
        int aux = -1;
        bool[] mask = new bool[hand.Length];
        int count = hand.Length;

        while(count != 0){
            aux = random.Next(0, hand.Length);

            if(board.ValidPlay(hand[aux])) {
                board.PlaceToken( hand[aux].Clone(), this.IDPlayer.Item1 );
                return true;
            }

            if(!mask[aux]) {
                mask[aux] = true;
                count--;
            }
        }
        return false;
    }
 
    // public override int points {
    //     get {
    //         int total = 0;
    //         // string s = "";
    //         for( int i = 0; i < hand.Count; i++ ) {
    //             total += hand[i].Value;
    //             // s += $"[{hand[i].left.Item1}:{hand[i].right.Item1}]";
    //         }
    //         // System.Console.WriteLine(s);
    //         return total;
    //     }
    // }

    public override Player Clone() {
        RandomPlayer clone = new RandomPlayer();

        return clone;
    }
}