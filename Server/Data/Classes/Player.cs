namespace Server.Data.Classes;
using Server.Data.Interfaces;

// *Jugador que realiza jugadas de forma random
public abstract class Player {
    protected List< Token > hand = new List<Token>();
    protected (int, string) ID; // id number, player name

    public (int, string) IDPlayer {
        get{return this.ID;}
        set{this.ID = value;}
    }
    public virtual void MakeTokens( IEnumerable< Token > tokens ) {
        foreach(Token item in tokens){
            hand.Add(item);
        }
    }    
    public virtual int Count {
        get { return hand.Count; }
    }

    public virtual IEnumerable<Token> Hand {
        get{ return this.hand; }
    }

    public abstract Player Clone();
    public abstract int points {get;}
    public abstract bool PlayToken( IBoard board );
}