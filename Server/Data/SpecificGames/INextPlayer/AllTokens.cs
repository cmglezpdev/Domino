namespace Server.Data.Classes;

using System.Collections.Generic;
using Server.Data.Interfaces;

public class NextPlayerLongana : INextPlayer
{
    int cursor = -1;
    List<int> CountTokensPlayer = new List<int>();

    public INextPlayer Clone() {
        
        NextPlayerLongana clone = new NextPlayerLongana();
        clone.cursor = cursor;

        foreach( int item in CountTokensPlayer )
            clone.CountTokensPlayer.Add(item);

        return clone;
    }

    public int NextPlayer( PlayerInfo[] players ) {
        
        if( CountTokensPlayer.Count == 0 ) {
            foreach( var ply in players ) {
                CountTokensPlayer.Add( ply.Count );
            }
            return (this.cursor = (this.cursor + 1)%players.Length);
        }

        if( players[this.cursor].Count != this.CountTokensPlayer[this.cursor] ) {
            this.CountTokensPlayer[this.cursor] = players[this.cursor].Count;
            return this.cursor;
        }
        
        this.cursor = (this.cursor + 1)%players.Length;
        
        return players[this.cursor].IDPlayer.Item1;
    }
}