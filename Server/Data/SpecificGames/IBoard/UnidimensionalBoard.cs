namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * Tablero con que se coloca las nuevas fichas consecutivamente
public class UnidimensionalBoard : IBoard {
    List<Token> board = new List<Token>();
    List<int> PlayerByToken = new List<int>();
    public List<Token> BuildTokens( int MaxIdOfToken ) {
        List<Token> tokens = new List<Token>();

        for(int i = 0; i <= MaxIdOfToken; i++){
            for(int j = i; j <= MaxIdOfToken; j++){
                tokens.Add(new Token(i , j));
            }
        }
        return tokens;
    }
    public void PlaceToken( Token token, int IdPlayer ) {
        if( board.Count == 0 ) {
            board.Add(token);
            PlayerByToken.Add(IdPlayer);
            return;
        } 

        if( ValidPlay(token, board[0]) ) {
            Play(token, 0);
            PlayerByToken.Insert(0, IdPlayer);
            return;
        }

        if( ValidPlay(token, board[ board.Count - 1 ]) ) {
            Play(token, board.Count - 1);
            PlayerByToken.Add(IdPlayer);
            return;
        }    
    }
     private void Play(Token token, int pos) {
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
    public bool ValidPlay(Token token) {
        // Puede jugar cualquier ficha
        if( board.Count == 0 ) return true;
        
        if( ValidPlay(token, board[0]) || ValidPlay(token, board[ board.Count - 1 ]) ) return true;   
        
        return false;
    }
    public bool ValidPlay(Token token, Token item) {

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
    public Token[][] TokensInBoard {
        get{ 
            Token[][] tokens = new Token[1][];
            tokens[0] = this.board.ToArray();
            
            return tokens; 
        }
    }
    public int[] PlayerByTokens {
        get{ return this.PlayerByToken.ToArray(); }
    }
}
