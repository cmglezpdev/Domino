namespace Server.Data.Interfaces;
using Server.Data.Classes;

// Contrato a cumplir para crear una variacion de como se selecciona el próximo jugador a jugar
public interface INextPlayer {
    int NextPlayer( PlayerInfo[] players );
    INextPlayer Clone();
}