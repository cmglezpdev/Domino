namespace Domino.Interfaces;

public interface IPlayer {
    void MakeTokens( IEnumerable< IToken > tokens );    
    void PlayToken( IBoard board , IFinishGame finish); 
    //cambio posible
    int cant {get;}
    //decir cuantas fichas tiene
    int points {get; }
}