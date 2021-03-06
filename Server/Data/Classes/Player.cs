namespace Server.Data.Classes;
using Server.Data.Interfaces;

// *Jugador que realiza jugadas de forma random
public abstract class Player {
    protected (int, string) ID; // id number, player name

    public (int, string) IDPlayer {
        get{return this.ID;}
        set{this.ID = value;}
    }

    public abstract Player Clone();

    public abstract int PlayToken( IBoard board, Token[] hand);
}