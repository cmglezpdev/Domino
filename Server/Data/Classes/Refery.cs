namespace Server.Data.Classes;
using Server.Data.Interfaces;
using Server.Data.Delegates;
public class Refery {
    List<Token>[] hands;
    Player[] players;
    IBoard board;
    SearchPlayerIndex Search;

    public Refery(IBoard board, SearchPlayerIndex Search) {
        this.board = board;
        this.hands = new List<Token>[0];
        this.players = new Player[0];
        this.Search = Search;
    } 
    public void MakeTokens(List<Token>[] hand, Player[] ply){

        this.hands = hand;
        this.players = ply;
    }

    // Relaiza la jugada del jugador y devuelve información de la jugada
    public StatusCurrentPlay Play(int IdPlayer, PublicInformation Information) {
        int aux = -1;
        int IndexPlayer = this.Search(IdPlayer, this.players);
        // obtener la ficha que va a jugar
        aux = players[IndexPlayer].PlayToken(board, hands[IndexPlayer].ToArray(), Information);

        // Si el jugador no pudo realizar la jugada
        if((aux < 0 || aux >= hands[IndexPlayer].Count) || !board.ValidPlay(hands[IndexPlayer][aux]) ) {
            // Crear el estado del juego para cuando el jugador no jugó
            return new StatusCurrentPlay(IdPlayer, true, null, board.Clone());
        } 

        // Actualizar el board con la nueva jugada y remover la ficha de la mano del jugador
        board.PlaceToken(hands[IndexPlayer][aux], IdPlayer);
        Token t = hands[IndexPlayer][aux].Clone();        
        hands[IndexPlayer].RemoveAt(aux);

        // Crear el estado del juego cuando el jugador ya realizó su jugada
        return new StatusCurrentPlay( 
            IdPlayer, 
            false, 
            t,
            board.Clone()
        );

    }
    // Devuelve las fichas de la mano del jugador con Id: IdPlayer
    public Token[] Hand( int IdPlayer ) {
        int IndexPlayer = this.Search(IdPlayer, this.players);
        List<Token> hand = new List<Token>();
        for(int i = 0; i < this.hands[IndexPlayer].Count; i ++) {
            hand.Add( this.hands[ IndexPlayer ][i].Clone() );
        }

        return hand.ToArray();
    }
    // Cuenta la cantidad de fichas que tiene el jugador con Id: IdPlayer
    public int Count(int IdPlayer){
        int IndexPlayer = this.Search(IdPlayer, this.players);
        return hands[IndexPlayer].Count;
    }
    // Cantidad de Puntos que tiene el jugador con Id: IdPlayer
    public int Points(int IdPlayer) {
        int total = 0;
        int IndexPlayer = this.Search(IdPlayer, this.players);
        foreach(var item in hands[IndexPlayer]) {
            total += item.Value;
        }
        return total;
    }

    // Buscar el jugador y devolver su indice
    public Player Player(int IdPlayer) {
        int IndexPlayer = this.Search(IdPlayer, this.players);
        return players[IndexPlayer].Clone();
    }
    
    // Retorna informacion del jugador
    public PlayerInfo[] PlayerInformation {
        get {
            List<PlayerInfo> info = new List<PlayerInfo>();
            int contPlayers = hands.Length;
            
            for(int i = 0; i < contPlayers; i ++) {
                int IdPlayer = players[i].IDPlayer.Item1;
                info.Add( new PlayerInfo(
                    this.Count(IdPlayer), 
                    this.Points(IdPlayer), 
                    this.Player(IdPlayer).IDPlayer.Item1, 
                    this.Player(IdPlayer).IDPlayer.Item2
                ));
            }

            return info.ToArray();
        }
    }

    public Refery Clone() {
        Refery clone = new Refery(this.board.Clone(), this.Search);
        
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