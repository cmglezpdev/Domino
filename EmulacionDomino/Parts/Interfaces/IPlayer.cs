namespace Domino.Interfaces;

public interface IPlayer {
    (int, string) IDPlayer {get; set;}
    void MakeTokens( IEnumerable< IToken > tokens );    
    bool PlayToken( IBoard board); 
    //cambio posible
    int Count {get;}
    //decir cuantas fichas tiene
    int points {get; }
}