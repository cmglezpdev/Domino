namespace Server.Data.Classes;
using Server.Data.Interfaces;

public abstract class Player {
    protected (int, string) ID; // id number, player name

    public (int, string) IDPlayer {
        get{return this.ID;}
        set{this.ID = value;}
    }

    public abstract Player Clone();

    // Devuelve el indice de la ficha a jugar
    public abstract int PlayToken( IBoard board, Token[] hand, PublicInformation Information);
}