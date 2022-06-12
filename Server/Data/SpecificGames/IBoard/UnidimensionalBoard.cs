namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class UnidimensionalBoard : IBoard {
    List<IToken> board = new List<IToken>();
    public IToken[] BuildTokens( int MaxIdOfToken ) {
        List<Token> tokens = new List<Token>();

        for(int i = 0; i <= MaxIdOfToken; i++){
            for(int j = i; j <= MaxIdOfToken; j++){
                tokens.Add(new Token(i , j));
            }
        }
        return tokens.ToArray();
    }
    public void PlaceToken( IToken token ) {
        if( board.Count == 0 ) {
            board.Add(token);
            return;
        } 

        if( ValidPlay(token, board[0]) ) {
            Play(token, 0);
            return;
        }

        if( ValidPlay(token, board[ board.Count - 1 ]) ) {
            Play(token, board.Count - 1);
            return;
        }    
    }
     private void Play(IToken token, int pos) {
        if( pos == 0 ) {
            // Solo se juega por la parte izquierda de la ficha del tablero
            int faceToken = board[0].left.Item1;
            if( token.left.Item2 && token.left.Item1 == faceToken ) {
                board[0].Played(token.left.Item1);
                board.Insert(0, token);
                board[0].Played(token.left.Item1);
                board[0].SwapVertex();
                return;
            }
            
            if( token.right.Item2 && token.right.Item1 == faceToken ) {
                board[0].Played(token.right.Item1);
                board.Insert(0, token);
                board[0].Played(token.right.Item1);
                return;
            }
        }
        
        if( pos == this.board.Count - 1 ) {
            // Solo se juega con la parte derecha de la ficha del tablero
            int faceToken = board[pos].right.Item1;
            if( token.left.Item2 && token.left.Item1 == faceToken ) {
                board[pos].Played(token.left.Item1);
                board.Add(token);
                board[ ++pos ].Played(token.left.Item1);
                return;
            }
            
            if( token.right.Item2 )
                if( token.right.Item1 == faceToken ) {
                    board[pos].Played(token.right.Item1);
                    board.Add(token);
                    board[ ++ pos].Played(token.right.Item1);
                    board[ pos ].SwapVertex();
                    return;
                }
        }
        
    }
    public bool ValidPlay(IToken token) {
        // Puede jugar cualquier ficha
        if( board.Count == 0 ) return true;
        
        if( ValidPlay(token, board[0]) || ValidPlay(token, board[ board.Count - 1 ]) ) return true;   
        
        return false;
    }
    public bool ValidPlay(IToken token, IToken item) {

        if( item.left.Item2 ) {
            int faceToken = item.left.Item1;
            if( token.left.Item2 ) 
                if( token.left.Item1 == faceToken ) return true;
            if( token.right.Item2 )
                if( token.right.Item1 == faceToken ) return true;
        }
        if( item.right.Item2 ) {
            int faceToken = item.right.Item1;
            if( token.left.Item2 ) 
                if( token.left.Item1 == faceToken ) return true;
            if( token.right.Item2 )
                if( token.right.Item1 == faceToken ) return true;
        }
        

        return false;
    }
    public IToken[] TokensInBoard {
        get{ return this.board.ToArray(); }
    }
}
