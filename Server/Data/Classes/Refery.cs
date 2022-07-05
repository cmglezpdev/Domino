namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class Refery {
    List<Token>[]? hands;
    Player[]? players;
    IBoard board;

    public Refery(IBoard board) {
        
        this.board = board;

    } 
    public void MakeTokens(List<Token>[] hand, Player[] ply){

        this.hands = hand;
        this.players = ply;
    }
    public bool Play(Player ply) {
        bool aux = false;
        for(int i = 0; i < players.Length; i++){
            if(players[i].IDPlayer.Item1 == ply.IDPlayer.Item1){
                aux = players[i].PlayToken(board, hands[i].ToArray());
            }
        }
        return aux;
    }
    public int points(int indexplayer) {
        int total = 0;
        for( int i = 0; i < players.Length; i++ ) {
            if(players[i].IDPlayer.Item1 == indexplayer){
                foreach(var item in hands[i]) {
                    total += item.Value;
                }
            }
        }
        return total;
    }
}