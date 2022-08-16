using Server.Data.Classes;

public static class Game {

    // "Convertir" una lista de fichas a formato json
    public static List<FacesToken> TokenForJson( IEnumerable<Token> tokens ) {
        List<FacesToken> TokensJson = new List<FacesToken>();
        foreach( var t in tokens ) {
            TokensJson.Add( new FacesToken(){ Left = t[0].Value, Right = t[1].Value } );
        }
        return TokensJson;
    }


    // "Convertir" una lista de jugadores con su informacion a formato json
    public static List<ResPlayer> PlayersForJson( PlayerInfo[] players, Refery refery ) {
        List<ResPlayer> result = new List<ResPlayer>();
        int countPlayers = players.Length;

        for( int i = 0; i < countPlayers; i ++ ) {   
            var p = players[i];
            List<FacesToken> hand = Game.TokenForJson( refery.Hand(i) );
            result.Add(new ResPlayer() {
                Id = p.IDPlayer.Item1,
                Name = p.IDPlayer.Item2,
                Points = p.Points,
                HandTokens = hand.ToArray()
            });
        }
        return result;
    }

    // "Convertir" la informacion del tablero a formato json 
    public static List<List<FacesToken>> TokensInBoardJson ( (Token, string)[,] Tokens ) {
        
        List<List<FacesToken?>> TokensJson = new List<List<FacesToken>>()!;

        for( int i = 0; i < Tokens.GetLength(0); i ++ ) {
            TokensJson.Add( new List<FacesToken>()! );
            for( int j = 0; j < Tokens.GetLength(1); j ++ ) {
                (Token t, string d) = Tokens[i,j];
                if(t == null )
                    TokensJson.Last().Add(null);
                else
                TokensJson[ TokensJson.Count - 1 ].Add( new FacesToken(){ Left = t[0].Value, Right = t[1].Value, Direction = d } );
            }
        }

        return TokensJson!;
    }
}
