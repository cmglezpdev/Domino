namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * El juego finaliza cuando hay al menos una cantidad de pases iguales a la cantidad de jugadores o alguien se pega
public class AllPassFinish : IFinishGame {

    public IFinishGame Clone() {
        AllPassFinish clone = new AllPassFinish();
        return clone;
    }
    
    public bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players ) {

        foreach( var item in players) {
            if( item.Count == 0) return true;
        }   

        int n = Manager.StatusCurrentPlay.Count;
        if( n < players.Count() ) return false;
        
        int count = 0;
        for(int i = n - 1; i >= 0; i --) {
            if( Manager.StatusCurrentPlay[i].Passed ) {
                count ++;
                if( count == players.Count() ) return true;
                continue;
            } 
            break;
        }

        return false;
    }
}
