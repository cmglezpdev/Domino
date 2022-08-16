namespace Server.Data.Classes;
using Server.Data.Interfaces;

// Clase que representa la información actual de una jugada
public class StatusCurrentPlay {
    public int IDPlayerPlayed {get; set;} // El jugador que la realizó
    public bool Passed {get; set;} // si se pasó
    public Token? TokenPlayed {get; set;} // la ficha que jugo
    public IBoard? StatusBoard {get; set;} // el estado del tablero

    public StatusCurrentPlay ( int IdPlayerPlayed, bool Passed, Token? tokenPlayed, IBoard? Board ) {
        this.IDPlayerPlayed = IdPlayerPlayed;
        this.Passed = Passed;
        this.TokenPlayed = tokenPlayed;
        this.StatusBoard = Board;
    }

    public StatusCurrentPlay Clone() {
        return new StatusCurrentPlay( 
            this.IDPlayerPlayed, 
            this.Passed, 
            this.TokenPlayed?.Clone(), 
            this.StatusBoard?.Clone() 
        );
    }
}

// Esta representa el estado de una jugada también ,pero contiene mas información 
//  pq es la que se envía al frontend para que se muestre la información
public class PlayInfo {
    public IEnumerable<ResPlayer>? Players {get; set;} // Lista de jugadores con su información
    public int? CurrentPlayer {get; set;} // ID del jugador que jugo
    public int? points {get; set;} // cantidad actual de puntos del jugador
    public bool? Passed {get; set;} // Si el jugador se pasó o no
    public IEnumerable< IEnumerable<FacesToken> >? TokensInBoard {get; set;} // Las fichas que estan en el tablero después de la jugada
    public bool? FinishGame {get; set;} // True si se terminó el juego
    public IEnumerable<ResPlayer>? Winners{get; set;} // Lista de ganadores en la ronda actual
}


// Esta clase representa un jugador con su información
public class PlayerInfo {
    public int Count {get; private set;} // cantidad de fichas
    public int Points {get; private set;} // cantidad de puntos
    public (int, string) IDPlayer {get; private set;} // id number, player name

    public PlayerInfo(int countTokens, int Points, int ID, string name) {
        this.Count = countTokens;
        this.Points = Points;
        this.IDPlayer = (ID, name);
    }
}

// Info de un jugador que es convertida a JSON para ser enviada al frontend
public class ResPlayer {
    public int? Id {get; set;}
    public string? Name {get; set;}
    public int? Points {get; set;}
    public FacesToken[]? HandTokens {get; set;}
}

// Info de una ficha parseada para un JSON
public class FacesToken {
    public int? Left {get; set;}
    public int? Right {get; set;}
    public string? Direction {get; set;} // dirección de la ficha en el tablero
}


// Reperesenta toda la información que es publica durante el juego y que los jugadores pueden tener acceso
public class PublicInformation {
    public int MaxIdOfToken{ get; set; } // Máximo número que puede tener una ficha
    public int[] IdOfPlayers{ get; set; } // Índice de los jugadores(esto corresponde con las propiedades de abajo)
    public int[] PassedOfPlayers{ get; set; } // Pases de los jugadores
    public int[] CountTokenByPlayers{ get; set; } // Contador de tokens por jugador
    public List<StatusCurrentPlay> StatusCurrentPlay{ get; set; } // Información pública de los jugadores

    public PublicInformation() {
        this.MaxIdOfToken = 0;
        this.IdOfPlayers = new int[0];
        this.PassedOfPlayers = new int[0];
        this.CountTokenByPlayers = new int[0];
        this.StatusCurrentPlay = new List<StatusCurrentPlay>();
    }

    public PublicInformation Clone() {

        int[] IdOfPlayersClone = new int[ this.IdOfPlayers.Length ];
        Array.Copy( this.IdOfPlayers, IdOfPlayersClone, IdOfPlayers.Length );

        int[] PassedOfPlayersClone = new int[ this.PassedOfPlayers.Length ];
        Array.Copy( this.PassedOfPlayers, PassedOfPlayersClone, PassedOfPlayers.Length );

        int[] CountTokenByPlayersClone = new int[ this.CountTokenByPlayers.Length ];
        Array.Copy( this.CountTokenByPlayers, CountTokenByPlayersClone, CountTokenByPlayers.Length );

        List<StatusCurrentPlay> StatusCurrentPlayClone = new List<StatusCurrentPlay>();
        foreach (StatusCurrentPlay status in this.StatusCurrentPlay) {
            StatusCurrentPlayClone.Add( status.Clone() );
        }

        return new PublicInformation () {
            MaxIdOfToken = this.MaxIdOfToken,
            IdOfPlayers = IdOfPlayersClone,
            PassedOfPlayers = PassedOfPlayersClone,
            CountTokenByPlayers = CountTokenByPlayersClone,
            StatusCurrentPlay = StatusCurrentPlayClone,
        };
    }
}