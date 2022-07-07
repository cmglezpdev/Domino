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
    public bool Play(int IdPlayer) {
        int aux = -1;
        int IndexPlayer = SearchPlayerIndex(IdPlayer);
        aux = players[IndexPlayer].PlayToken(board, hands[IndexPlayer].ToArray());

        if(aux < 0 || aux > hands[IndexPlayer].Count) return false;
        if(!board.ValidPlay(hands[IndexPlayer][aux])) return false;

        board.PlaceToken(hands[IndexPlayer][aux], IdPlayer);
        hands[IndexPlayer].RemoveAt(aux);
        return true;
    }
    public Token[] Hand( int IdPlayer ) {
        int IndexPlayer = SearchPlayerIndex(IdPlayer);
        List<Token> hand = new List<Token>();
        for(int i = 0; i < this.hands[IndexPlayer].Count; i ++) {
            hand.Add( this.hands[ IndexPlayer ][i].Clone() );
        }

        return hand.ToArray();
    }
    public int Count(int IdPlayer){
        int IndexPlayer = SearchPlayerIndex(IdPlayer);
        return hands[IndexPlayer].Count;
    }
    public int Points(int IdPlayer) {
        int total = 0;
        int IndexPlayer = SearchPlayerIndex(IdPlayer);
        foreach(var item in hands[IndexPlayer]) {
            total += item.Value;
        }
        return total;
    }

    public int SearchPlayerIndex(int IdPlayer) {
        for(int i = 0; i < players.Length; i ++) {
            if(players[i].IDPlayer.Item1 == IdPlayer) return i;
        }
        return -1;
    }

    public Player Player(int IdPlayer) {
        int IndexPlayer = SearchPlayerIndex(IdPlayer);
        return players[IndexPlayer].Clone();
    }
    public PlayerInfo[] PlayerInformation {
        get {
            List<PlayerInfo> info = new List<PlayerInfo>();
            int contPlayers = hands.Length;
            
            for(int i = 0; i < contPlayers; i ++) {
                int IdPlayer = players[i].IDPlayer.Item1;
                info.Add(
                    new PlayerInfo(this.Count(IdPlayer), 
                    this.Points(IdPlayer), 
                    this.Player(IdPlayer).IDPlayer.Item1, 
                    this.Player(IdPlayer).IDPlayer.Item2)
                );
            }

            return info.ToArray();
        }
    }

    public Refery Clone() {
        Refery clone = new Refery(this.board.Clone());
        
        Player[] players = new Player[this.players.Length];
        for(int i = 0; i < players.Length; i ++) players[i] = this.players[i].Clone();

        List<Token>[] hands = new List<Token>[this.hands.Length];
        for(int i = 0; i < hands.Length; i ++) {
            hands[i] = new List<Token>();
            for(int j = 0; j < this.hands[i].Count; j ++) {
                hands[i].Add(this.hands[i][j].Clone());
            }
        }

        clone.MakeTokens(hands, players);

        return clone;
    }
}