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
    // Para esto usa la propiedad estatica Manager.StatusCurrentPlay
    public bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players ) {

        foreach( var item in players) {
            if( item.Count == 0) return true;
        }

        bool[] aux = new bool[players.Count()];
        foreach(var item in Manager.StatusCurrentPlay){
            if(item.Passed) aux[Manager.SearchPlayerIndex(item.IDPlayerPlayed)] = true;
            else aux = new bool[players.Count()];
            }
        if(aux.All(x => x == true)) return true;

        return false;
    }
}
