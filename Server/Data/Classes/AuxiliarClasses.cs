namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class StatusCurrentPlay {
    public int IDPlayerPlayed {get; set;}
    public bool Passed {get; set;}
    public Token? TokenPlayed {get; set;}
    public IBoard? StatusBoard {get; set;}
}

public class PlayInfo {
    public IEnumerable<ResPlayer>? Players {get; set;}
    public int? CurrentPlayer {get; set;} // Indice de jugador en la lista de jugadores
    public int? points {get; set;} // cantidad actual de puntos de jugador
    public bool? Passed {get; set;} // Si el jugador se paso o no
    public IEnumerable< IEnumerable<VertexToken> >? TokensInBoard {get; set;} // Las fichas que estan en el tablero despues de la jugada
    public bool? FinishGame {get; set;} // True si se termino el juego
    public IEnumerable<ResPlayer>? Winners{get; set;} // Lista de ganadores en la ronda actual
}
public class PlayerInfo {
    public int Count {get; private set;}
    public int Points {get; private set;}
    public (int, string) IDPlayer {get; private set;}

    public PlayerInfo(int countTokens, int Points, int ID, string name) {
        this.Count = countTokens;
        this.Points = Points;
        this.IDPlayer = (ID, name);
    }
}
