namespace Domino.Classes;
using Domino.Interfaces;
public class Board : IBoard {

    List<IToken> board = new List<IToken>();
    List<IToken> Aviabletoken = new List<IToken>();
    public IEnumerable< IToken > BuildTokens( int MaxIdOfToken ) {
        List<Token> tokens = new List<Token>();

        for(int i = 0; i <= MaxIdOfToken; i++){
            for(int j = i + 1; j <= MaxIdOfToken; j++){
                tokens.Add(new Token(new int[]{i , j}));
            }
        }
        return tokens;
    }
    public void PlaceToken( IToken token, int ID ) {
        board.Add(token);
        token.Play(ID);
        for( int i = 0; i < Aviabletoken.Count; i++){
            foreach(int item in Aviabletoken[i].AviablePositions){
                if(item == ID) Aviabletoken[i].Play(ID);
            }
        }
        if(token.AviablePositions.Count() != 0){
            Aviabletoken.Add(token);
        }
    }
    public IEnumerable< IToken > AviableTokens {
        get{ 
            return Aviabletoken;
            }
    }
}
