// Interfas para saber cuando un juego termina
// Es una interfas porque esto puede cambiar 
namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IFinishGame {
    bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players );
}