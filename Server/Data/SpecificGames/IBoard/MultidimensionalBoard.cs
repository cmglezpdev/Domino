namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class MultidimensionalBorad : IBoard
{
    private class InfoToken {
        public Token token {get;set;} = null!; // token
        public string direction {get;set;} = null!; 
        public InfoToken Clone() => new InfoToken() {
            token = token.Clone(),
            direction = direction
        };
        
    }

    private class Coord {
        public int x{get; set;}
        public int y{get; set;}

        public Coord Clone() => new Coord() {
            x = x,
            y = y
        };
    }

    private IMatch matcher = null!;
    private int maxIdOfToken;

    private Dictionary< Token, int > TokenByPlayer = new Dictionary<Token, int>(); // Tokens correspondientes a cada jugador
    private Dictionary< Coord, InfoToken > board = new Dictionary<Coord, InfoToken>(); // Tablero de juego

    public List<Token> BuildTokens(int MaxIdOfToken, ITokenValue calcValue)
    {
        this.maxIdOfToken = MaxIdOfToken;
        List<Token> tokens = new List<Token>();

        for(int i = 0; i <= MaxIdOfToken; i++){
            for(int j = i; j <= MaxIdOfToken; j++){
                if(i == j) 
                    tokens.Add(new TokenDouble(i, j, calcValue));
                else
                tokens.Add(new Token(i , j, calcValue));
            }
        }
        return tokens;
    }
    
    public void PlaceToken(Token token, int IdPlayer)
    {

        // The board is void
        if( board.Count == 0 ) {
            TokenByPlayer[ token ] = IdPlayer;
            this.board[ new Coord(){x = 0, y = 0} ] = new InfoToken(){ 
                                                            token = token.Clone(), 
                                                            direction = ( token.Left.Value != token.Right.Value ) ? "horizontal" : "vertical"
                                                        };
            return;
        }

        // pasar por las posiciones validas para jugar
        foreach( var info in board ) {
            Coord coords = info.Key;
            InfoToken item = info.Value;
            Token tok = item.token;
            // Si este token no tiene por donde jugarle
            if( matcher.WhichFacePlay(item.token, null).Length == 0 ) continue;


            // Si es un token y esta en una linea horizontal || si es un doble y esta puesto verticalmente
            if( ( tok[0].Value != tok[1].Value && item.direction == "horizontal") || (tok[0].Value == tok[1].Value && item.direction == "vertical") ) {
                // Jugar por el lado derecho de la ficha si es que se puede
                if( !tok[0].Played && !board.ContainsKey(new Coord(){x = coords.x - 1, y = coords.y}) ) {
                    if( matcher.ValidateMatch(token, 0, tok, 0) ) {
                        tok.Played(0); // marcar la cara del token de la mesa como jugada
                        token.Played(0); // marcar la cara del token a jugar como jugada
                        token.SwapFaces(); // Invertir las caras
                        this.board[ new Coord(){x = coords.x - 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value != token.Right.Value ) ? "horizontal" : "vertical" }; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                    
                    if( matcher.ValidateMatch(token, 1, tok, 0) ) {
                        tok.Played(0); // marcar la cara del token de la mesa como jugada
                        token.Played(1); // marcar la cara del token a jugar como jugada
                        this.board[ new Coord(){x = coords.x - 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value != token.Right.Value ) ? "horizontal" : "vertical"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                }
                
                // Comprobar si se puede jugar por la izquierda
                if( !tok[1].Played && !board.ContainsKey(new Coord(){x = coords.x + 1, y = coords.y}) ) {
                    if( matcher.ValidateMatch(token, 0, tok, 1) ) {
                        tok.Played(1); // marcar la cara del token de la mesa como jugada
                        token.Played(0); // marcar la cara del token a jugar como jugada
                        this.board[ new Coord(){x = coords.x + 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value != token.Right.Value ) ? "horizontal" : "vertical"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                    
                    if( matcher.ValidateMatch(token, 1, tok, 1) ) {
                        tok.Played(1); // marcar la cara del token de la mesa como jugada
                        token.Played(1); // marcar la cara del token a jugar como jugada
                        token.SwapFaces(); // Invertir las caras
                        this.board[ new Coord(){x = coords.x + 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value != token.Right.Value ) ? "horizontal" : "vertical"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }                    
                }


                // Si el token del board es un doble entonces comprobar si puedo jugar por arriba y por abajo
                if( tok[0].Value == tok[1].Value ) {
                    //   Comprobar si se puede jugar por arriba
                    if( !tok[2].Played && !board.ContainsKey(new Coord(){x = coords.x, y = coords.y - 1}) ) {
                        if( matcher.ValidateMatch(token, 0, tok, 2) ) {
                            tok.Played(2);
                            token.Played(0);
                            token.SwapFaces();
                            this.board[ new Coord(){x = coords.x, y = coords.y - 1} ] = new InfoToken(){token = token.Clone() , direction = "vertical"};
                            return;
                        }
                        
                        if( matcher.ValidateMatch(token, 1, tok, 2) ) {
                            tok.Played(2);
                            token.Played(1);
                            this.board[ new Coord(){x = coords.x, y = coords.y - 1} ] = new InfoToken(){token = token.Clone() , direction = "vertical"};
                            return;
                        }
                    }
                    // Comrpobar si se puede jugar por la parte de abajo
                    if( !tok[3].Played && !board.ContainsKey(new Coord(){x = coords.x, y = coords.y + 1}) ) {
                        if( matcher.ValidateMatch(token, 0, tok, 3) ) {
                            tok.Played(3);
                            token.Played(0);
                            this.board[ new Coord(){x = coords.x, y = coords.y + 1} ] = new InfoToken(){token = token.Clone() , direction = "vertical"};
                            return;
                        }
                        
                        if( matcher.ValidateMatch(token, 1, tok, 3) ) {
                            tok.Played(3);
                            token.Played(1);
                            token.SwapFaces();
                            this.board[ new Coord(){x = coords.x, y = coords.y + 1} ] = new InfoToken(){token = token.Clone() , direction = "vertical"};
                            return;
                        }
                    }
                }

            } else 









            // Si es un token que esta puesto en una linea vertical o si es un doble con una direccion horizontal
            if( ( tok[0].Value != tok[1].Value && item.direction == "vertical") || (tok[0].Value == tok[1].Value && item.direction == "horizontal") ) {

               // Jugar por arriba (el lado derecho) de la ficha si es que se puede
                if( !tok[0].Played && !board.ContainsKey(new Coord(){x = coords.x, y = coords.y - 1}) ) {
                    if( matcher.ValidateMatch(token, 0, tok, 0) ) {
                        tok.Played(0); // marcar la cara del token de la mesa como jugada
                        token.Played(0); // marcar la cara del token a jugar como jugada
                        token.SwapFaces(); // Invertir las caras
                        this.board[ new Coord(){x = coords.x, y = coords.y - 1} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value == token.Right.Value ) ? "horizontal" : "vertical" }; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                    
                    if( matcher.ValidateMatch(token, 1, tok, 0) ) {
                        tok.Played(0); // marcar la cara del token de la mesa como jugada
                        token.Played(1); // marcar la cara del token a jugar como jugada
                        this.board[ new Coord(){x = coords.x, y = coords.y - 1} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value == token.Right.Value ) ? "horizontal" : "vertical"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                }
                
                // Comprobar si se puede jugar por la abajo (izquierda)
                if( !tok[1].Played && !board.ContainsKey(new Coord(){x = coords.x, y = coords.y + 1}) ) {
                    if( matcher.ValidateMatch(token, 0, tok, 1) ) {
                        tok.Played(1); // marcar la cara del token de la mesa como jugada
                        token.Played(0); // marcar la cara del token a jugar como jugada
                        this.board[ new Coord(){x = coords.x, y = coords.y + 1} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value == token.Right.Value ) ? "horizontal" : "vertical"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                    
                    if( matcher.ValidateMatch(token, 1, tok, 1) ) {
                        tok.Played(1); // marcar la cara del token de la mesa como jugada
                        token.Played(1); // marcar la cara del token a jugar como jugada
                        token.SwapFaces(); // Invertir las caras
                        this.board[ new Coord(){x = coords.x, y = coords.y + 1} ] = new InfoToken(){token = token.Clone() , direction = ( token.Left.Value == token.Right.Value ) ? "horizontal" : "vertical"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }                    
                }


                // Si el token del board es un doble entonces comprobar si puedo jugar por arriba y por abajo(derecha o izq)
                if( tok[0].Value == tok[1].Value ) {
                    //   Comprobar si se puede jugar por arriba
                    if( !tok[2].Played && !board.ContainsKey(new Coord(){x = coords.x - 1, y = coords.y}) ) {
                        if( matcher.ValidateMatch(token, 0, tok, 2) ) {
                            tok.Played(2);
                            token.Played(0);
                            token.SwapFaces();
                            this.board[ new Coord(){x = coords.x - 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "horizontal"};
                            return;
                        }
                        
                        if( matcher.ValidateMatch(token, 1, tok, 2) ) {
                            tok.Played(2);
                            token.Played(1);
                            this.board[ new Coord(){x = coords.x - 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "horizontal"};
                            return;
                        }
                    }
                    // Comrpobar si se puede jugar por la parte de abajo
                    if( !tok[3].Played && !board.ContainsKey(new Coord(){x = coords.x + 1, y = coords.y}) ) {
                        if( matcher.ValidateMatch(token, 0, tok, 3) ) {
                            tok.Played(3);
                            token.Played(0);
                            this.board[ new Coord(){x = coords.x + 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "horizontal"};
                            return;
                        }
                        
                        if( matcher.ValidateMatch(token, 1, tok, 3) ) {
                            tok.Played(3);
                            token.Played(1);
                            token.SwapFaces();
                            this.board[ new Coord(){x = coords.x + 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "horizontal"};
                            return;
                        }
                    }
                }

            }
        }
    }



    public bool ValidPlay(Token token)
    {
        if( board.Count == 0 ) return true;

        foreach( var info in board ) {
            Coord coords = info.Key;
            InfoToken item = info.Value;
            Token tok = item.token;
            // Si este token no tiene por donde jugarle
            if( matcher.ValidateMatch(token, tok)) return true;
        }

        return false;
    }
    public void SetMatcher(IMatch match)
    {
        this.matcher = match;
    }
    public Tuple<Token, int>[] OrderListOfTokensByPlayer {
        get {
            List<Tuple<Token, int>> list = new List<Tuple<Token, int>>();
            foreach(var x in TokenByPlayer) {
                list.Add( new Tuple<Token, int>(x.Key, x.Value) );
            }
            return list.ToArray();
        }

    }
    public (Token, string)[,] TokensInBoard {
        get {
            
            (int left, int top, int right, int bottom) = BordersBoard(); // Extremos del tablero
            NormalizeBoard(top, left); // Normalizar el tablero
            right -= left; // Calcular el ancho del tablero
            bottom -= top; // Calcular el alto del tablero

            (Token, string) [,] tokens = new (Token, string)[bottom + 1, right + 1]; // Crear el tablero de tokens
            foreach( var info in board ) {
                Coord coords = info.Key;
                InfoToken item = info.Value;
                Token tok = item.token;
                tokens[ coords.y, coords.x ] = (tok, item.direction); // Guardar el token en el tablero
            }

            return tokens;
        }
    }

    // top - left
    private Tuple< int, int, int, int > BordersBoard() { 
        int left = 0, top = 0, right = 0, bottom = 0;

        foreach( var info in board ) {
            Coord coords = info.Key;
            if( coords.x < left ) left = coords.x;
            if( coords.y < top ) top = coords.y;
            if( coords.x > right ) right = coords.x;
            if( coords.y > bottom ) bottom = coords.y;
        }

        return new Tuple<int, int, int, int>(left, top, right, bottom);
    }
    private void NormalizeBoard( int top, int left ) {
        Dictionary<Coord, InfoToken> newBorad = new Dictionary<Coord, InfoToken>();

        foreach( var info in board ) {
            Coord coords = info.Key;
            InfoToken item = info.Value;
            Token tok = item.token;
            newBorad[ new Coord(){x = coords.x - left, y = coords.y - top} ] = new InfoToken(){token = tok.Clone() , direction = item.direction};
        }

        this.board = newBorad;
    }

    public IBoard Clone() {
        MultidimensionalBorad board = new MultidimensionalBorad();
        
        board.board = new Dictionary<Coord, InfoToken>();
        foreach( var x in this.board ) board.board.Add( x.Key.Clone(), x.Value.Clone() );

        board.TokenByPlayer = new Dictionary<Token, int>();
        foreach( var x in this.board ) board.board.Add( x.Key.Clone(), x.Value );

        board.maxIdOfToken = this.maxIdOfToken;
        return board;
    }
}