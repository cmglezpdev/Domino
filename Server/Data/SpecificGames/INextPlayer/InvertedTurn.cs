namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * La lista de jugadores de forma consecutiva 0,1,2,...,n y si alguien se pasa el orden se invierte
public class InvertedTurn : INextPlayer {
    int cursor = -1;
    int mov = 1;
    List<int> CountTokensPlayer = new List<int>(); 
    public int NextPlayer( PlayerInfo[] players ) {
        
        if( CountTokensPlayer.Count == 0 ) {
            foreach( var ply in players ) {
                CountTokensPlayer.Add( ply.Count );
            }
            return (++this.cursor);
        }
        
        int countToken = -1, i = 0;
        foreach(var x in players) {
            if( i == cursor ) {
                countToken = x.Count;
                break;
            }
            i ++;
        }
        
        // No se pasaron, seguir el mismo orden
        if( countToken == CountTokensPlayer[ cursor ] ) {
            this.mov *= -1;
        }
        //  Actualizar la cant de fichas que tenemos guardado  
        else {
            this.CountTokensPlayer[ cursor ] --;
        }

        this.cursor += mov;
        if( this.cursor >= players.Count() ) this.cursor = 0;
        if( this.cursor < 0 ) this.cursor = players.Count() - 1; 

        return this.cursor;
    }
}