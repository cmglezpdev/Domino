namespace Domino.Interfaces;

public interface IBoard {
    public IEnumerable< IToken > BuildTokens( int MaxIdOfToken ); // Construir las fichas del juego
    void PlaceToken( IToken token, int ID ); // Coloca la carta dada por un jugador
    IEnumerable< IToken > AviableTokens { get;}
}