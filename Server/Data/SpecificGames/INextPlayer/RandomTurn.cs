namespace Server.Data.Classes;
using Server.Data.Interfaces;

// Selecciona al siguiente jugador de forma aleatoria
public class RandomTurn : INextPlayer {
    public int NextPlayer( PlayerInfo[] players ) {
        Random random = new Random();
        int index = random.Next(0 , players.Count());
        return players[index].IDPlayer.Item1;
    }
}