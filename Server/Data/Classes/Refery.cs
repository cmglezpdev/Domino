namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class Refery {
    List<Token>[] hands;
    Player[] players;
    IBoard board;

    public Refery(IBoard board) {
        
        this.board = board;
        this.hands = new List<Token>[0];
        this.players = new Player[0];
    } 
    public void MakeTokens(List<Token>[] hand, Player[] ply){

        this.hands = hand;
        this.players = ply;
    }
    public bool Play(int indexPlayer) {
        int aux = -1;
        
        aux = players[indexPlayer].PlayToken(board, hands[indexPlayer].ToArray());

        if(aux < 0 || aux > hands[indexPlayer].Count) return false;
        if(!board.ValidPlay(hands[indexPlayer][aux])) return false;

        board.PlaceToken(hands[indexPlayer][aux], indexPlayer);
        hands[indexPlayer].RemoveAt(aux);
        return true;
    }
    public Token[] Hand( int indexPlayer ) {
        List<Token> hand = new List<Token>();
        for(int i = 0; i < this.hands[indexPlayer].Count; i ++) {
            hand.Add( this.hands[ indexPlayer ][i].Clone() );
        }

        return hand.ToArray();
    }
    public int Count(int indexPlayer){

        return hands[indexPlayer].Count;
    }
    public int Points(int indexPlayer) {
        int total = 0;
        foreach(var item in hands[indexPlayer]) {
            total += item.Value;
        }
        return total;
    }
    public Player Player(int indexPlayer) {
        return players[indexPlayer].Clone();
    }
    // TODO: Arreglar todo lo que tiene indexPlayer, ver si se refiere al indexPlayer del jugador o al indice
    public PlayerInfo[] PlayerInformation {
        get {
            List<PlayerInfo> info = new List<PlayerInfo>();
            int contPlayers = hands.Length;
            
            for(int i = 0; i < contPlayers; i ++) {
                info.Add(new PlayerInfo(this.Count(i), this.Points(i), this.Player(i).IDPlayer.Item1, this.Player(i).IDPlayer.Item2));
            }

            return info.ToArray();
        }
    }
}