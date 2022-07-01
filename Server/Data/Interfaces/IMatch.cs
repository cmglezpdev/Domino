namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IMatch
{
    bool ValidateMatch( Token token1, Token token2 );
    bool ValidateMatch( Token token1, int face1, Token token2, int face2 );
    int[] WhichFacePlay( Token token1, Token? token2 );
}