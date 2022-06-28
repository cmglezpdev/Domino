namespace Server.Data.Classes;

using System.Collections.Generic;
using Server.Data.Interfaces;

public class MultidimensionalBorad : IBoard
{

    private class Info {
        public Token? token{get; set;}
        public List<Token>? UpToken{get; set;}
        public List<Token>? DownToken{get; set;}
    }



    private int maxIdOfToken;

    // private List< Info > board = new List<Info>();
    Dictionary< Token, int > TokenByPlayer = new Dictionary<Token, int>();
    private Token[,] board = new Token[15,15];
    List< Tuple<int, int> > aviablePositions = new List<Tuple<int, int>>();
    private int middle = 8;

    public List<Token> BuildTokens(int MaxIdOfToken, TokenValue calcValue)
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

        System.Console.WriteLine("Placing token: " + token.left.Item1 + " " + token.right.Item1);
        // The board is clean
        if( TokenByPlayer.Count == 0 ) {
            TokenByPlayer[ token ] = IdPlayer;
            this.board[ middle, middle ] = token;
            this.aviablePositions.Add(new Tuple<int, int>(middle, middle));
            return;
        }

        bool ok = false;
        // pasar por las posiciones validas para jugar
        for(int i = 0; i < aviablePositions.Count && !ok; i ++) {
            int x = aviablePositions[i].Item1;
            int y = aviablePositions[i].Item2;
    
            if( !ValidPlay(token, this.board[x, y]) ) continue;

            // Revisar por que costado jugarla
            var item = this.board[x, y];
            System.Console.WriteLine(item.left.Item1 + " " + item.right.Item1);
  
            //* Si tiene fichas por la izquierda
            // if( !ok &&  board[x, y - 1] != null ) {
                // Si la ficha no es un doble, entonces solo se puede colocar a la derecha de esta
                if( board[x, y + 1] == null ) {
                    // si se puede jugar la ficha
                    if( item.right.Item1 == token.left.Item1 ) {
                        board[x, y + 1] = token;
                        // System.Console.WriteLine(board[x, y + 1]);
                        board[x, y + 1].Played(token.left.Item1);
                        board[x, y].Played(token.left.Item1);
                        ok = true;
                    } else 
                    if( item.right.Item1 == token.right.Item1 ) {
                        board[x, y + 1] = token;
                        board[x, y + 1].Played(token.right.Item1);
                        board[x, y].Played(token.left.Item1);
                        board[x, y + 1].SwapVertex();
                        ok = true;
                    }
                }

                if( ok ) {
                    // Anadir la ficha actual a la lista de aviabletokens 
                    this.aviablePositions.Add(new Tuple<int, int>(x, y + 1));
                    // Borrar por donde se jugo
                    if( !item.CanPlayForToken() )
                        aviablePositions.RemoveAt(i);
                    break;
                }
                
                // Si es un doble considerar arriba y abajo
                if( item.left.Item1 == item.right.Item1 ) {
                    ok = PlaceUpOrDownDobule(x, y, token);
                }   
            // }
            // else
            //* Si tiene fichas por derecha
            // if( !ok &&  board[x, y + 1] != null ) {
                // Si la ficha no es un doble, entonces solo se puede colocar a la izquierda de esta
                if( board[x, y - 1] == null ) {
                    // si se puede jugar la ficha
                    if( token.left.Item1 == item.left.Item1 ) {
                        board[x, y - 1] = token;
                        board[x, y - 1].SwapVertex();
                        board[x, y - 1].Played(token.left.Item1);
                        board[x, y].Played(token.left.Item1);
                        ok = true;
                    } else 
                    if( token.right.Item1 == item.left.Item1 ) {
                        board[x, y - 1] = token;
                        board[x, y - 1].Played(token.right.Item1);
                        board[x, y].Played(token.left.Item1);
                        ok = true;
                    }
                }
                // Si es un doble considerar arriba y abajo
                if( item.left.Item1 == item.right.Item1 ) {
                    ok = PlaceUpOrDownDobule(x, y, token);
                }

                if( ok ) {
                    // Anadir la ficha actual a la lista de aviabletokens 
                    this.aviablePositions.Add(new Tuple<int, int>(x, y - 1));
                    // Borrar por donde se jugo
                    if( !item.CanPlayForToken() )
                            aviablePositions.RemoveAt(i);
                    break;
                }
            // }
            // else
            //* Si tiene fichas por arriba
            // if( !ok &&  board[x - 1, y] != null ) {
                // Si la ficha no es un doble, entonces solo se puede colocar abajo de esta
                if( board[x + 1, y] == null ) {
                    // si se puede jugar la ficha
                    if( item.left.Item1 == token.left.Item1 ) {
                        board[x + 1, y] = token;
                        board[x + 1, y].SwapVertex();
                        board[x + 1, y].Played(token.left.Item1);
                        board[x, y].Played(token.left.Item1);
                        ok = true;
                    } else 
                    if( item.left.Item1 == token.right.Item1 ) {
                        board[x + 1, y] = token;
                        board[x + 1, y].Played(token.right.Item1);
                        board[x, y].Played(token.left.Item1);
                        ok = true;
                    }
                }
                // Si es un doble considerar a la derecha e izquierda
                if( item.left.Item1 == item.right.Item1 ) {
                    ok = PlaceLeftOrRightDobule(x, y, token);
                }

                if( ok ) {
                    // Anadir la ficha actual a la lista de aviabletokens 
                    this.aviablePositions.Add(new Tuple<int, int>(x + 1, y));
                    // Borrar por donde se jugo
                    if( !item.CanPlayForToken() )
                            aviablePositions.RemoveAt(i);
                    break;
                }

            // }
            // else
            //* Si tiene fichas por abajo
            // if( !ok && board[x + 1, y] != null ) {
                // Si la ficha no es un doble, entonces solo se puede colocar arriba de esta
                if( board[x - 1, y] == null ) {
                    // si se puede jugar la ficha
                    if( item.right.Item1 == token.left.Item1 ) {
                        board[x - 1, y] = token;
                        board[x - 1, y].Played(token.left.Item1);
                        board[x, y].Played(token.left.Item1);
                        ok = true;
                    } else 
                    if( item.right.Item1 == token.right.Item1 ) {
                        board[x - 1, y] = token;
                        board[x - 1, y].SwapVertex();
                        board[x - 1, y].Played(token.right.Item1);
                        board[x, y].Played(token.left.Item1);
                        ok = true;
                    }
                }
                // Si es un doble considerar a la derecha e izquierda
                if( item.left.Item1 == item.right.Item1 ) {
                    ok = PlaceLeftOrRightDobule(x, y, token);
                }   
                
                if( ok ) {
                    // Anadir la ficha actual a la lista de aviabletokens 
                    this.aviablePositions.Add(new Tuple<int, int>(x - 1, y));
                    // Borrar por donde se jugo
                    if( !item.CanPlayForToken() )
                            aviablePositions.RemoveAt(i);
                    break;
                }
            // }
            
        }
    }
    private bool PlaceUpOrDownDobule(int x, int y, Token token) {
        Token item = board[x, y];

        // Arriba
        if( board[x - 1, y] == null ) {
            // si se puede jugar la ficha
            if( token.left.Item1 == item.left.Item1 ) {
                board[x - 1, y] = token;
                board[x - 1, y].Played(token.left.Item1);
                board[x, y].Played(token.left.Item1);
                
                this.aviablePositions.Add(new Tuple<int, int>(x - 1, y));
                return true;
            } else 
            if( token.right.Item1 == item.left.Item1 ) {
                board[x - 1, y] = token;
                board[x - 1, y].Played(token.right.Item1);
                board[x, y].Played(token.left.Item1);
                board[x - 1, y].SwapVertex();

                  this.aviablePositions.Add(new Tuple<int, int>(x - 1, y));
                return true;
            }
        }
        // Abaj0
        if( board[x + 1, y] == null ) {
            // si se puede jugar la ficha
            if( token.left.Item1 == item.left.Item1 ) {
                board[x + 1, y] = token;
                board[x + 1, y].Played(token.left.Item1);
                board[x, y].Played(token.left.Item1);
                board[x + 1, y].SwapVertex();

                this.aviablePositions.Add(new Tuple<int, int>(x + 1, y));
                return true;
            } else 
            if( token.right.Item1 == item.left.Item1 ) {
                board[x + 1, y] = token;
                board[x + 1, y].Played(token.right.Item1);
                board[x, y].Played(token.left.Item1);

                this.aviablePositions.Add(new Tuple<int, int>(x + 1, y));
                return true;
            }
        }
        return false;
    }
    private bool PlaceLeftOrRightDobule(int x, int y, Token token) {
        Token item = board[x, y];

        // Izquierda
        if( board[x, y - 1] == null ) {
            // si se puede jugar la ficha
            if( token.left.Item1 == item.left.Item1 ) {
                board[x, y - 1] = token;
                board[x, y - 1].SwapVertex();
                board[x, y - 1].Played(token.left.Item1);
                board[x, y].Played(token.left.Item1);
                 this.aviablePositions.Add(new Tuple<int, int>(x, y - 1));
                return true;
            } else 
            if( token.right.Item1 == item.left.Item1 ) {
                board[x, y - 1] = token;
                board[x, y - 1].Played(token.right.Item1);
                board[x, y].Played(token.left.Item1);
                this.aviablePositions.Add(new Tuple<int, int>(x, y - 1));
                return true;
            }
        }
        // Derecha
        if( board[x, y + 1] == null ) {
            // si se puede jugar la ficha
            if( token.left.Item1 == item.right.Item1 ) {
                board[x, y + 1] = token;
                board[x, y + 1].Played(token.left.Item1);
                this.aviablePositions.Add(new Tuple<int, int>(x, y + 1));
                board[x, y + 1].SwapVertex();
                return true;
            } else 
            if( token.right.Item1 == item.right.Item1 ) {
                board[x, y + 1] = token;
                board[x, y].Played(token.left.Item1);
                board[x, y + 1].Played(token.right.Item1);
                board[x, y].Played(token.left.Item1);
                this.aviablePositions.Add(new Tuple<int, int>(x, y + 1));
                return true;
            }
        }
        return false;
    }
    bool ValidPlay(Token token, Token item) {

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
        
        // Si la ficha del tablero es una doble
        if( item.left.Item1 == item.right.Item1 ) {
            int faceToken = item.left.Item1;
            
            if( ((TokenDouble)item).up.Item2 ) {
                if( token.left.Item2 ) 
                    if( token.left.Item1 == faceToken ) return true;
                if( token.right.Item2 ) 
                    if( token.right.Item1 == faceToken ) return true;
            }

            if( ((TokenDouble)item).down.Item2 ) {
                if( token.left.Item2 ) 
                    if( token.left.Item1 == faceToken ) return true;
                if( token.right.Item2 ) 
                    if( token.right.Item1 == faceToken ) return true;
            }

        }   

        return false;
    }
    public bool ValidPlay(Token token)
    {
        if( TokenByPlayer.Count == 0 ) return true;

        foreach(var x in aviablePositions) {
            if( ValidPlay(token, board[x.Item1, x.Item2]) )
                return true;
        }
        return false;
    }
    public Token[,] TokensInBoard {
        get {

            for( int i = 0; i < board.GetLength(0); i++ ) {
                for( int j = 0; j < board.GetLength(1); j++ ) {
                    if( board[i, j] == null )
                        Console.Write("(-,-)");
                    else
                        Console.Write("({0},{1})", board[i, j].left.Item1, board[i, j].right.Item1);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();



            return this.board;
        }
    }
    public Tuple<Token, int>[] OrderListOfTokensByPlayer {
       get {
            
            List<Tuple<Token, int>> response = new List<Tuple<Token, int>>();
            foreach( var x in this.TokenByPlayer ) {
                response.Add(new Tuple<Token, int>(x.Key, x.Value));
            }
            return response.ToArray();
       }
    }
    public int MaxIdOfToken {
        get{
            return this.maxIdOfToken;
        }
    }
}