namespace Domino.Classes;
using Domino.Interfaces;
// fin del juego
public class Finish : IFinishGame {
    int pass = 0;
    public bool FinishGame( IBoard board, IEnumerable<IPlayer> players ) {
        if(this.pass == players.Count()) return true;

        foreach( IPlayer item in players) {
            if( item.Count == 0) return true;
        }
        return false;
    }
    public void Pass( bool passed ) {
        this.pass = ( passed ) ? this.pass + 1 : 0;
    }
}
