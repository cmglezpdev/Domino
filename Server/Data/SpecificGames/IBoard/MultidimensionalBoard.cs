namespace Server.Data.Classes;

using System;
using System.Collections.Generic;
using Server.Data.Interfaces;

public class MultidimensionalBorad : IBoard
{
    private class InfoToken {
        public Token token {get;set;} // token
        public string direction {get;set;} // direccion de los tokens anteriores a el
    }

    private class Coord {
        public int x{get; set;}
        public int y{get; set;}
    }

    private IMatch matcher;
    private int maxIdOfToken;

    // private List< Info > board = new List<Info>();
    Dictionary< Token, int > TokenByPlayer = new Dictionary<Token, int>();
    private Dictionary< Coord, InfoToken > board = new Dictionary<Coord, InfoToken>();

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

        // The board is clean
        if( board.Count == 0 ) {
            TokenByPlayer[ token ] = IdPlayer;
            this.board[ new Coord(){x = 0, y = 0} ] = new InfoToken(){ 
                                                            token = token.Clone(), 
                                                            direction = "start"
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


                // Si el token del board es un doble entonces comprobar si puedo jugar por arriba y por abajo
                if( tok[0].Value == tok[1].Value ) {
                    System.Console.WriteLine("Estoy evaluando un doble");
                    if( !tok[2].Played && !board.ContainsKey(new Coord(){x = coords.x, y = coords.y - 1}) ) {
                        if( matcher.ValidateMatch(token, 0, tok, 2) ) {
                            tok.Played(2);
                            token.Played(0);
                            this.board[ new Coord(){x = coords.x, y = coords.y - 1} ] = new InfoToken(){token = token.Clone() , direction = "down"};
                            return;
                        }
                        
                        if( matcher.ValidateMatch(token, 1, tok, 2) ) {
                            tok.Played(2);
                            token.Played(1);
                            token.SwapFaces();
                            this.board[ new Coord(){x = coords.x, y = coords.y - 1} ] = new InfoToken(){token = token.Clone() , direction = "down"};
                            return;
                        }
                    }
                    // Comrpobar si se puede jugar por la parte de abajo
                    if( !tok[3].Played && !board.ContainsKey(new Coord(){x = coords.x, y = coords.y + 1}) ) {
                        if( matcher.ValidateMatch(token, 0, tok, 3) ) {
                            tok.Played(3);
                            token.Played(0);
                            token.SwapFaces();
                            this.board[ new Coord(){x = coords.x, y = coords.y + 1} ] = new InfoToken(){token = token.Clone() , direction = "up"};
                            return;
                        }
                        
                        if( matcher.ValidateMatch(token, 1, tok, 3) ) {
                            tok.Played(3);
                            token.Played(1);
                            this.board[ new Coord(){x = coords.x, y = coords.y + 1} ] = new InfoToken(){token = token.Clone() , direction = "up"};
                            return;
                        }
                    }
                }



            // Si el direccion es start compruebo si se puede jugar por todos lados
            // if( item.direction == "start" ) {
                // Jugar por el lado derecho de la ficha si es que se puede
                if( !tok[0].Played && !board.ContainsKey(new Coord(){x = coords.x - 1, y = coords.y}) ) {
                    if( matcher.ValidateMatch(token, 0, tok, 0) ) {
                        tok.Played(0); // marcar la cara del token de la mesa como jugada
                        token.Played(0); // marcar la cara del token a jugar como jugada
                        token.SwapFaces(); // Invertir las caras
                        this.board[ new Coord(){x = coords.x - 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "right"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                    
                    if( matcher.ValidateMatch(token, 1, tok, 0) ) {
                        tok.Played(0); // marcar la cara del token de la mesa como jugada
                        token.Played(1); // marcar la cara del token a jugar como jugada
                        this.board[ new Coord(){x = coords.x - 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "right"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                }
                
                // Comprobar si se puede jugar por la izquierda
                if( !tok[1].Played && !board.ContainsKey(new Coord(){x = coords.x + 1, y = coords.y}) ) {
                    if( matcher.ValidateMatch(token, 0, tok, 1) ) {
                        tok.Played(1); // marcar la cara del token de la mesa como jugada
                        token.Played(0); // marcar la cara del token a jugar como jugada
                        this.board[ new Coord(){x = coords.x + 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "left"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }
                    
                    if( matcher.ValidateMatch(token, 1, tok, 1) ) {
                        tok.Played(1); // marcar la cara del token de la mesa como jugada
                        token.Played(1); // marcar la cara del token a jugar como jugada
                        token.SwapFaces(); // Invertir las caras
                        this.board[ new Coord(){x = coords.x + 1, y = coords.y} ] = new InfoToken(){token = token.Clone() , direction = "left"}; // guardar el nuevo token
                        TokenByPlayer[ token ] = IdPlayer; // guardar el jugador que juega el token
                        return;
                    }                    
                }


            // }
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
    public int MaxIdOfToken => this.MaxIdOfToken;
    public Token[,] TokensInBoard {
        get {
            
            (int left, int top, int right, int bottom) = BordersBoard(); // Extremos del tablero
            NormalizeBoard(top, left); // Normalizar el tablero
            right -= left; // Calcular el ancho del tablero
            bottom -= top; // Calcular el alto del tablero

            Token [,] tokens = new Token[bottom + 1, right + 1]; // Crear el tablero de tokens
            foreach( var info in board ) {
                Coord coords = info.Key;
                InfoToken item = info.Value;
                Token tok = item.token;
                tokens[ coords.y, coords.x ] = tok; // Guardar el token en el tablero
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

}