namespace Server.Data.Classes;
using Server.Data.Interfaces;

// Implementación que r
public class EqualFace : IMatch
{
    public bool ValidateMatch( Token token1, Token token2 )
    {
       return WhichFacePlay(token1, token2).Length != 0;
    }

    public int[] WhichFacePlay( Token token1, Token? token2 )
    {    
        List<int> aviableFaces1 = new List<int>();

        if( token2 == null ) {
            for(int i = 0; i < token1.Faces.Length; i++) {
                if( !token1.Faces[i].Played ) {
                    aviableFaces1.Add(i);
                }
            }

            return aviableFaces1.ToArray();
        }


        for(int i = 0; i < token1.Faces.Length; i++) {
            for(int j = 0; j < token2.Faces.Length; j ++) {
                
                if( ValidateMatch(token1, i, token2, j) ) {
                    if( !aviableFaces1.Contains(i) )
                       aviableFaces1.Add(i);
                }
            }
        }
        
        // if( ValidateMatch(token1, 0, token2, 0) || ValidateMatch(token1, 0, token2, 1) ) aviableFaces1.Add(0);
        // if( ValidateMatch(token1, 1, token2, 0) || ValidateMatch(token1, 1, token2, 1) ) aviableFaces1.Add(1);
            
        return aviableFaces1.ToArray();
    }

    public bool ValidateMatch(Token token1, int face1, Token token2, int face2) {
        return (token1[face1].Value == token2[face2].Value && !token1[face1].Played && !token2[face2].Played); 
    }

    public IMatch Clone() => new EqualFace();

}