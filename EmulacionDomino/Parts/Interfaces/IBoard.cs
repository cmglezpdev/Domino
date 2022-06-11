namespace Domino.Interfaces;

public interface IBoard {
    public IToken[] BuildTokens( int MaxIdOfToken ); // Construir las fichas del juego
    void PlaceToken( IToken token ); // Coloca la carta dada por un jugador
    //cambio posible
    bool ValidPlay(IToken token);

    public IToken[] TokensInBoard {
        get;
    }
}