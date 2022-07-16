namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IBoard {
  // Construye las fichas del juego 
    List<Token> BuildTokens( int MaxIdOfToken, ITokenValue CalculateValue ); 
    
    // Recibe una ficha, la valida y la coloca en el tablero 
    void PlaceToken( Token token, int IdPlayer ); 
    // Usando la interfaz IMatch valida si una jugada se puede realizar en el tablero
    bool ValidPlay(Token token);

    // Devuelve una matris con las fichas colocadas en cada posición
    (Token, string)[,] TokensInBoard {
        get;
    }
    // Devuelve el orden en que se fueron jugando las fichas con sus respectivos jugadores
    Tuple<Token, int>[] OrderListOfTokensByPlayer {
        get;
    }
    // Asignar el matcher al board
    void SetMatcher(IMatch match);

    // Devuelve un clone del board
    IBoard Clone();
}