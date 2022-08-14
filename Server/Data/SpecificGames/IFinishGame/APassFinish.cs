namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * El juego finaliza cuando alguien se pegue o cuando todos la mayoria de ellos se pasen al menos dos veces
public class APassFinish : IFinishGame {
    public IFinishGame Clone() => new APassFinish();

    public bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players, PublicInformation Information ) {
       
        // Si alguien se paso
        foreach(var item in players) {
            if( item.Count == 0) return true;
        }
       
        // Si la mayoria se paso al menos dos veces retornar true
        int count = 0;
        for(int i = 0; i < Information.PassedOfPlayers.Length; i ++)
            if( Information.PassedOfPlayers[i] >= 2 ) count ++;

        int comp = players.Count() / 2;
        if( players.Count() %2 != 0 ) comp ++;
        return (count >= comp);
    }
}
