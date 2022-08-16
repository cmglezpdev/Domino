// Interfas para saber cuando un juego termina
namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IFinishGame {
    bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players, PublicInformation Information );
    IFinishGame Clone();
}