namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IBoard {
    List<Token> BuildTokens( int MaxIdOfToken, TokenValue CalculateValue ); // Construir las fichas del juego
    void PlaceToken( Token token, int IdPlayer ); // Coloca la carta dada por un jugador
    //cambio posible
    bool ValidPlay(Token token);

    Token[,] TokensInBoard {
        get;
    }
    Tuple<Token, int>[] OrderListOfTokensByPlayer {
        get;
    }
    int MaxIdOfToken {
        get;
    } 

    void SetMatcher(IMatch match);
}