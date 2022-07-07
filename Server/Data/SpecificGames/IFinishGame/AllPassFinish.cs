namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * El juego finaliza solo cuando todos los jugadores se pasan o alguien se pega
public class AllPassFinish : IFinishGame {
    int pass = 0;

    public IFinishGame Clone() {
        AllPassFinish clone = new AllPassFinish();
        clone.pass = pass;
        return clone;
    }
    
    // FIXME: Arreglar esto, que no esta contando la cantidad de pases 
    public bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players ) {
        if(this.pass == players.Count()) return true;

        foreach( var item in players) {
            if( item.Count == 0) return true;
        }
        return false;
    }
}
