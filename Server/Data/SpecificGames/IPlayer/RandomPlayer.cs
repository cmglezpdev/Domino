namespace Server.Data.Classes;
using Server.Data.Interfaces;

// *Jugador que realiza jugadas de forma random
public class RandomPlayer : Player {
    public override int PlayToken( IBoard board, Token[] hand) {

        Random random = new Random();
        int aux = -1;
        bool[] mask = new bool[hand.Length];
        int count = hand.Length;

        while(count != 0){
            aux = random.Next(0, hand.Length);

            if(board.ValidPlay(hand[aux])) {
                return aux;
            }

            if(!mask[aux]) {
                mask[aux] = true;
                count--;
            }
        }
        return -1;
    }


    public override Player Clone() {
        RandomPlayer clone = new RandomPlayer();

        return clone;
    }
}