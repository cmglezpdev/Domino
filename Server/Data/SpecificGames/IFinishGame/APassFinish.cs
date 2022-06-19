namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * El juego finaliza cuando alguien se pegue o cuando alguien se pase por primera vez
public class APassFinish : IFinishGame {
    int pass = 0;
    public bool FinishGame( IBoard board, IEnumerable<IPlayer> players ) {
        if(this.pass > 0) return true;

        foreach( IPlayer item in players) {
            if( item.Count == 0) return true;
        }
        return false;
    }
    public void Pass( bool passed ) {
        this.pass = ( passed ) ? this.pass + 1 : 0;
    }
}
