namespace Server.Models;
public class TypeGame {
    public int countTokens {get; set;} // Cantidad de fichas por jugador
    public int maxIdTokens {get; set;} // Id maximo que tiene una ficha
    public int countPlayers {get; set;} // Cantidad de jugadores
    public int matcher {get; set;} // Tipo de matcher
    public int[]? player {get; set;} // tipo de jugador
    public int board {get; set;} // tipo de tablero
    public int finishGame {get; set;} // tipo de finalizacion del juego
    public int winGame {get; set;} // de que forma se selecciona los ganadores
    public int tokenValue {get; set;} // tipo de valor de las fichas
    public int nextPlayer {get; set;} // como es el orden de los jugadores
    public int distributeTokens {get; set;} // como distribuir las fichas entre los jugadores
}