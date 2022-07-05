namespace Server.Data.Classes;
using Server.Data.Interfaces;

// *Jugador que realiza jugadas de forma random
public abstract class Player {
    protected (int, string) ID; // id number, player name
    int count = 0; 
    protected int points = 0;

    public (int, string) IDPlayer {
        get{return this.ID;}
        set{this.ID = value;}
    }
    // public virtual void MakeTokens( IEnumerable< Token > tokens ) {
    //     foreach(Token item in tokens){
    //         hand.Add(item);
    //     }
    // }    
    public virtual int Count {
        get { return count; }
        set { count = value; }
    }

    // public virtual IEnumerable<Token> Hand {
    //     get{ return this.hand; }
    // }

    public abstract Player Clone();
    public abstract int Points {get; set;}
    public abstract bool PlayToken( IBoard board, Token[] hand);
}