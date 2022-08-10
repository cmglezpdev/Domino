namespace Server.Data.Interfaces;
using Server.Data.Classes;

// Contrato a cumplir para crear una variacion de las reglas que deben cumplir dos fichas para ser jugadas entre si
public interface IMatch
{
    bool ValidateMatch( Token token1, Token token2 );
    bool ValidateMatch( Token token1, int face1, Token token2, int face2 );
    int[] WhichFacePlay( Token token1, Token? token2 );
    IMatch Clone();
}