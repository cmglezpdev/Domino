namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class RareEquivalence : IMatch
{
    public bool ValidateMatch(Token token1, Token token2)
    {
        return WhichFacePlay(token1, token2).Length != 0;
    }

    public bool ValidateMatch(Token token1, int face1, Token token2, int face2)
    {
        if( !token1[face1].Played && !token2[face2].Played ) {

            // True si el valor de una cara es sucesora de la otra
            if (token1[face1].Value == token2[face2].Value + 1) return true;
            if (token2[face2].Value == token1[face1].Value + 1) return true;
        
            // Si una cara es cero entonces machea con todos los valores de la otra cara
            if( token1[face1].Value == 0 ) return true;
            if( token2[face2].Value == 0 ) return true;

            // Una cara puede machear con las que son multiplos de el 
            if( token1[face1].Value % token2[face2].Value == 0 ) return true;
            if( token2[face2].Value % token1[face1].Value == 0 ) return true;

        }

        return false;
    }

    public int[] WhichFacePlay(Token token1, Token token2)
    {
        List<int> aviableFaces1 = new List<int>();
        if( ValidateMatch(token1, 0, token2, 0) || ValidateMatch(token1, 0, token2, 1) ) aviableFaces1.Add(0);
        if( ValidateMatch(token1, 1, token2, 0) || ValidateMatch(token1, 1, token2, 1) ) aviableFaces1.Add(1);
    
        return aviableFaces1.ToArray();
    }
}