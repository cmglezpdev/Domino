namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class EqualFace : IMatch
{

/// > If the value of any face on token1 matches the value of any face on token2, and neither face has
/// been played, then return true
    public bool ValidateMatch( Token token1, Token token2 )
    {
       return WhichFacePlay(token1, token2).Length != 0;
    }

    public int[] WhichFacePlay( Token token1, Token token2 )
    {    
        List<int> aviableFaces1 = new List<int>();

        if( ValidateMatch(token1, 0, token2, 0) || ValidateMatch(token1, 0, token2, 1) ) aviableFaces1.Add(0);
        if( ValidateMatch(token1, 1, token2, 0) || ValidateMatch(token1, 1, token2, 1) ) aviableFaces1.Add(1);
            
        return aviableFaces1.ToArray();
    }

    public bool ValidateMatch(Token token1, int face1, Token token2, int face2) {
        return (token1[face1].Value == token2[face2].Value && !token1[face1].Played && !token2[face2].Played); 
    }
}