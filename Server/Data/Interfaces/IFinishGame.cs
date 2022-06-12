// Interfas para saber cuando un juego termina
// Es una interfas porque esto puede cambiar 
namespace Server.Data.Interfaces;

public interface IFinishGame {
    bool FinishGame( IBoard board, IEnumerable<IPlayer> players );
    void Pass(bool passed);
}