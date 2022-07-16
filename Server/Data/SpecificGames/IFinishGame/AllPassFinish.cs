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

        int n = (int)Game.manager?.StatusCurrentPlay.Count!;
        if( n < players.Count() ) return false;
        
        bool[] aux = new bool[players.Count()];
        foreach(var item in Game.manager.StatusCurrentPlay){
            if(item.Passed) aux[Game.manager.SearchPlayerIndex(item.IDPlayerPlayed)] = true;
            else aux = new bool[players.Count()];
            }
        if(aux.All(x => x == true)) return true;

         int count = 0;
        for(int i = n - 1; i >= 0; i --) {
            if( Game.manager.StatusCurrentPlay[i].Passed ) {
                count ++;
                if( count == players.Count() ) return true;
                continue;
            } 
            break;
        }

        return false;
    }
}
