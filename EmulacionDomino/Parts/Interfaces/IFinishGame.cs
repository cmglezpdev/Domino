// Interfas para saber cuando un juego termina
// Es una interfas porque esto puede cambiar 
namespace Domino.Interfaces;

public interface IFinishGame {
    bool FinishGame( IBoard board, IEnumerable<IPlayer> players );
}