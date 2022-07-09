namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * Tablero con que se coloca las nuevas fichas consecutivamente
public class UnidimensionalBoard : IBoard {
    List<Token> board = new List<Token>();
    int maxIdOfToken;
    IMatch matcher = null!;
    List<Tuple<Token, int>> PlayerByToken = new List<Tuple<Token, int>>();
    public List<Token> BuildTokens( int MaxIdOfToken, TokenValue calcValue ) {
        this.maxIdOfToken = MaxIdOfToken;
        List<Token> tokens = new List<Token>();

        for(int i = 0; i <= MaxIdOfToken; i++){
            for(int j = i; j <= MaxIdOfToken; j++){
                tokens.Add(new Token(i , j, calcValue));
            }
        }
        return tokens;
    }
    public void PlaceToken( Token token, int IdPlayer ) {
        if( board.Count == 0 ) {
            board.Add(token);
            PlayerByToken.Add(new Tuple<Token, int>( token, IdPlayer ));
            return;
        } 

        if( matcher.ValidateMatch(token, board[0]) ) {
            Play(token, 0);
            PlayerByToken.Add(new Tuple<Token, int>( token, IdPlayer ));
            return;
        }

        if( matcher.ValidateMatch(token, board[ board.Count - 1 ]) ) {
            Play(token, board.Count - 1);
            PlayerByToken.Add(new Tuple<Token, int>( token, IdPlayer ));
            return;
        }    
    }
    public void SetMatcher( IMatch matcher ) {
        this.matcher = matcher;
    }
    private void Play(Token token, int pos) {
        Token item = board[pos];
        // Solo se puede jugar por la derecha de la ficha
        if( pos == 0 ) {
            // La ficha cabe esactamente como esta puesta
            if( this.matcher.ValidateMatch(token, 0, item, 0) ) {
                board[0].Played(0);
                board.Insert(0, token.Clone());
                board[0].Played( 0 );
                board[0].SwapFaces();
                return;
            }
            // Se rota la ficha
            if( this.matcher.ValidateMatch(token, 1, item, 0)) {
                board[0].Played(0);
                board.Insert(0, token.Clone());
                board[0].Played(1);
                return;
            }
        }
    
        if( pos == board.Count - 1 ) {
          
            if( this.matcher.ValidateMatch(token, 0, item, 1) ) {
                board[pos].Played(1);
                board.Add(token.Clone());
                board[board.Count - 1].Played(0);
                return;
            }
          
            if(this.matcher.ValidateMatch(token, 1, item, 1)) {
                board[pos].Played(1);
                board.Add(token.Clone());
                board[board.Count - 1].Played( 1 );
                board[board.Count - 1].SwapFaces();
                return;
            }
        }
    }
    public bool ValidPlay(Token token) {
        // Puede jugar cualquier ficha
        if( board.Count == 0 ) return true;
        
        if( this.matcher.ValidateMatch(token, board[0]) || this.matcher.ValidateMatch(token, board[ board.Count - 1 ]) ) return true;   
        
        return false;
    }

    public IBoard Clone() {
        UnidimensionalBoard clone = new UnidimensionalBoard();
        clone.board = new List<Token>();
        
        foreach( var item in board ) clone.board.Add( item.Clone() );
        clone.maxIdOfToken = maxIdOfToken;
        clone.matcher = matcher.Clone();
        
        clone.PlayerByToken = new List<Tuple<Token, int>>();
        foreach( var item in PlayerByToken )
            clone.PlayerByToken.Add( new Tuple<Token, int>( item.Item1.Clone(), item.Item2 ) );
        
        return clone;
    }

    public (Token, string)[,] TokensInBoard {
        get{ 
            (Token, string)[,] tokens = new (Token, string)[1, this.board.Count];
            for(int i = 0; i < this.board.Count; i ++) {
                var t = this.board[i];
                tokens[0, i] = (t, (t[0].Value == t[1].Value) ? "vertical" : "horizontal");
            }
            
            return tokens; 
        }
    }
    public Tuple<Token, int>[] OrderListOfTokensByPlayer => this.PlayerByToken.ToArray();
    public int MaxIdOfToken => this.maxIdOfToken;
}
