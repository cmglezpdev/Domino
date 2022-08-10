namespace Server.Data.Interfaces;
using Server.Data.Classes;

// Contrato a cumplir para crear una variacion de quien/quienes gana el juego
public interface IWinGame {
    IEnumerable<PlayerInfo> GetWinnersGame( IBoard board, IEnumerable<PlayerInfo> players );
    IWinGame Clone();
}