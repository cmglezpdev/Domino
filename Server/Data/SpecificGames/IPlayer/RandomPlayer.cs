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
 
    public override int Points {
        get {
            return points;
        }
        set {
            this.points = value;
        }
    }

    public override Player Clone() {
        RandomPlayer clone = new RandomPlayer();

        return clone;
    }
}