namespace Server.Data.Interfaces;
using Server.Data.Classes;

// Contrato a cumplir para crear una variacion de las reglas que deben cumplir dos fichas para ser jugadas entre si
public interface IMatch
{
    // Valida si dos fichas pueden ser jugadas juntas
    bool ValidateMatch( Token token1, Token token2 );
    // Valida si por la cara face1 de ficha1 se puede jugar la cara face2 de ficha 2 
    bool ValidateMatch( Token token1, int face1, Token token2, int face2 );
    // Devuelve un array con las caras de las fichas que pueden ser jugadas
    int[] WhichFacePlay( Token token1, Token? token2 );
    // Retorna un clone 
    IMatch Clone();
}