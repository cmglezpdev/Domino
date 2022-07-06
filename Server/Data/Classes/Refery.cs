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
    public bool Play(int ID) {
        int aux = -1;
        
        aux = players[ID].PlayToken(board, hands[ID].ToArray());

        if(aux < 0 || aux > hands[ID].Count) return false;
        if(!board.ValidPlay(hands[ID][aux])) return false;

        board.PlaceToken(hands[ID][aux], players[ID].IDPlayer.Item1);
        hands[ID].RemoveAt(aux);
        return true;
    }
    public int count(int ID){

        return hands[ID].Count;
    }
    public int points(int ID) {
        int total = 0;
        foreach(var item in hands[ID]) {
            total += item.Value;
        }
        return total;
    }
}