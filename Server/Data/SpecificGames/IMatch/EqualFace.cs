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

        if( ( token1.Left.Value == token2.Left.Value && !token1.Left.Played && !token2.Left.Played ) || 
            ( token1.Left.Value == token2.Right.Value && !token1.Left.Played && !token2.Right.Played ) ) {
            aviableFaces1.Add(token1.Left.Value);
        }
        if( ( token1.Right.Value == token2.Left.Value && !token1.Right.Played && !token2.Left.Played ) || 
            ( token1.Right.Value == token2.Right.Value && !token1.Right.Played && !token2.Right.Played ) ) {
            aviableFaces1.Add(token1.Right.Value);
        }
            
        return aviableFaces1.ToArray();
    }

    public bool ValidateMatch(Token token1, int face1, Token token2, int face2) {
        return (token1[face1].Value == token2[face2].Value && !token1[face1].Played && !token2[face2].Played); 
    }
}