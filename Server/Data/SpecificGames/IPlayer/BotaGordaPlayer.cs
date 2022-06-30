namespace Server.Data.Classes;
using Server.Data.Interfaces;

//jugador que juega la ficha de mas valor
public class BotaGordaPlayer : RandomPlayer {
    public override bool PlayToken( IBoard board ) {
        int aux = int.MinValue;
        int auxindex = -1;
        for(int i = 0; i < hand.Count; i++){
            if(board.ValidPlay(hand[i])) 
                if(hand[i].Value > aux) {
                    auxindex = i;
                    aux = hand[i].Value;
            }
        }
        if(auxindex != -1) {
            board.PlaceToken( hand[auxindex].Clone(), this.IDPlayer.Item1 );
            hand.RemoveAt(auxindex);
            return true;
        }
        return false;
    }  

    public override Player Clone() {
        BotaGordaPlayer clone = new BotaGordaPlayer();
        clone.MakeTokens( this.hand );

        return clone;
    }

}