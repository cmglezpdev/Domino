namespace Server.Data.Classes;
using Server.Data.Interfaces;

//jugador que juega la ficha de mas valor
public class BotaGordaPlayer : RandomPlayer {
    public override bool PlayToken( IBoard board, Token[] hand) {
        int index = -1;

        for(int i = 0; i < hand.Length; i++){
            if(board.ValidPlay(hand[i])) {
                if(index == -1) index = i;
                else if(hand[i].Value > hand[index].Value) index = i;
            }
        }
        if(index != -1){
            board.PlaceToken(hand[index].Clone(), this.IDPlayer.Item1);
            return true;
        }
        return false;
    }  

    public override Player Clone() {
        BotaGordaPlayer clone = new BotaGordaPlayer();
        return clone;
    }

}