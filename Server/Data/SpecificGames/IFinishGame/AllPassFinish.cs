namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * El juego finaliza hallan la cantidad de jugadores en pases consecutivos o alguien se pega
public class AllPassFinish : IFinishGame {

    public IFinishGame Clone() {
        AllPassFinish clone = new AllPassFinish();
        return clone;
    }
    
    public bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players, PublicInformation Information ) {

        var StatusCurrentPlay = Information.StatusCurrentPlay;

        foreach( var item in players) {
            if( item.Count == 0) return true;
        }   

        // Ver si alguien a jugado anteriormente
        int n = StatusCurrentPlay.Count!;
        // si todos los jugadores no han jugado entonces retorno falso
        if( n < players.Count() ) return false;
        
        bool[] aux = new bool[players.Count()];
        
        // Comprobar si todos los jugadores se pasaron 
        foreach(var item in StatusCurrentPlay){
            if(item.Passed) 
                aux[this.SearchPlayerIndex(item.IDPlayerPlayed, players.ToArray())] = true;
            else 
                aux = new bool[players.Count()];
        }
        // Si todos se pasaron el juego se acabó
        if(aux.All(x => x == true)) return true;

         int count = 0;
        //  Si las ultimas jugadas se pasaron entonces termina igual
        for(int i = n - 1; i >= 0; i --) {
            if( StatusCurrentPlay[i].Passed ) {
                count ++;
                if( count == players.Count() ) return true;
                continue;
            } 
            break;
        }

        return false;
    }

    private int SearchPlayerIndex(int IDPlayerPlayed, PlayerInfo[] players) {
        for(int i = 0; i < players.Length; i++) {
            if( players[i].IDPlayer.Item1 == IDPlayerPlayed ) return i;
        }
        return -1;
    }
}
