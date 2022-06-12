namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * El juego finaliza solo cuando todos los jugadores se pasan
public class AllPassFinish : IFinishGame {
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
