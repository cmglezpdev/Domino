namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IPlayer {
    (int, string) IDPlayer {get; set;}
    void MakeTokens( IEnumerable< Token > tokens );    
    bool PlayToken( IBoard board); 
    //cambio posible
    int Count {get;}
    //decir cuantas fichas tiene
    int points {get; }
    // Fichas que tiene
    IEnumerable<Token> Hand{ get; }

    IPlayer Clone();
}