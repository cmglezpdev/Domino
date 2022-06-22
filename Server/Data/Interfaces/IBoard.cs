namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IBoard {
    public List<Token> BuildTokens( int MaxIdOfToken ); // Construir las fichas del juego
    void PlaceToken( Token token, int IdPlayer ); // Coloca la carta dada por un jugador
    //cambio posible
    bool ValidPlay(Token token);

    public Token[][] TokensInBoard {
        get;
    }
    public int[] PlayerByTokens {
        get;
    }
}