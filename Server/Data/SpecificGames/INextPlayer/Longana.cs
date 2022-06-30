namespace Server.Data.Classes;

using System.Collections.Generic;
using Server.Data.Interfaces;

public class NextPlayerLongana : INextPlayer
{
    int cursor = -1;
    List<int>? CountTokensPlayer; 
    public int NextPlayer( Player[] players ) {
        
        if( CountTokensPlayer == null ) {
            CountTokensPlayer = new List<int>();
            foreach( var ply in players ) {
                CountTokensPlayer.Add( ply.Count );
            }
            return (this.cursor = (this.cursor + 1)%players.Length);
        }

        if( players[this.cursor].Count != this.CountTokensPlayer[this.cursor] ) {
            this.CountTokensPlayer[this.cursor] = players[this.cursor].Count;
            return this.cursor;
        }
        
        return (this.cursor = (this.cursor + 1)%players.Length);
    }
}