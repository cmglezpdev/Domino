using Server.Data.Classes;

public static class Parsers {

    // "Convertir" una lista de fichas a formato json
    #region Token's Parsers

    // Convertir una lista de fichas a Json
    public static List<FacesToken> GetTokensToJson( IEnumerable<Token> tokens ) {
        List<FacesToken> TokensJson = new List<FacesToken>();
        foreach( var t in tokens ) {
            TokensJson.Add( new FacesToken(){ Left = t[0].Value, Right = t[1].Value } );
        }
        return TokensJson;
    }


    // "Convertir la informacion del tablero a un template json de informacion general
    public static List<List<FacesToken>>  GetTokenInBoardToJson( TokenInBoard[,] Tokens ) {
        
        List<List<FacesToken?>> TokensJson = new List<List<FacesToken>>()!;

        for( int i = 0; i < Tokens.GetLength(0); i ++ ) {
            TokensJson.Add( new List<FacesToken>()! );
            for( int j = 0; j < Tokens.GetLength(1); j ++ ) {
                Token t = Tokens[i, j].token!;
                string d = Tokens[i, j].Direction!;
                if(t == null )
                    TokensJson.Last().Add(null);
                else
                TokensJson[ TokensJson.Count - 1 ].Add( new FacesToken(){ Left = t[0].Value, Right = t[1].Value, Direction = d } );
            }
        }

        return TokensJson!;
    }

    // Convertir la informacion del tablero a un template de informacion general
    public static TokenInBoard?[,]  GetTokenInBoardTemplate( (Token, string)[,] Tokens ) {
        
        TokenInBoard?[,] TokensTemplate = new TokenInBoard[ Tokens.GetLength(0), Tokens.GetLength(1) ];

        for( int i = 0; i < Tokens.GetLength(0); i ++ ) {
            for( int j = 0; j < Tokens.GetLength(1); j ++ ) {
                (Token t, string d) = Tokens[i, j];
                if(t == null )
                    TokensTemplate[i, j] = null;
                else
                TokensTemplate[ i, j ] = new TokenInBoard(){ token = t, Direction = d };
            }
        }

        return TokensTemplate!;
    }


    #endregion




    #region Players's Parsers

    // Convertir la informacion de los jugadores a un template json de informacion general
    public static List<ResPlayerJson> GetPlayersToJson( IEnumerable<ResPlayer> players ) {

        List<ResPlayerJson> playersJson = new List<ResPlayerJson>();
        foreach( var p in players ) {
            playersJson.Add(new ResPlayerJson(){
                Id = p.Id,
                Name = p.Name,
                Points = p.Points,
                HandTokens = Parsers.GetTokensToJson(p.HandTokens!).ToArray()
            });
        }
        return playersJson;
    }

    // Convertir la informacion de los jugadores a un template de informacion general
    public static List<ResPlayer> GetPlayersTemplate( PlayerInfo[] players, Refery refery ) {
        List<ResPlayer> result = new List<ResPlayer>();
        int countPlayers = players.Length;

        for( int i = 0; i < countPlayers; i ++ ) {   
            var p = players[i];
            
            result.Add(new ResPlayer() {
                Id = p.IDPlayer.Item1,
                Name = p.IDPlayer.Item2,
                Points = p.Points,
                HandTokens = refery.Hand(i)
            });
        }
        return result;
    }


    #endregion

}
