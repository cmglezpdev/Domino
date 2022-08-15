namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class Manager {

    // Información publica
    // public int MaxIdOfToken{ get; private set; } // Máximo número que puede tener una ficha
    // public int[] IdOfPlayers{ get; private set; } // Índice de los jugadores(esto corresponde con las propiedades de abajo)
    // public int[] PassedOfPlayers{ get; private set; } // Pases de los jugadores
    // public int[] CountTokenByPlayers{ get; private set; } // Contador de tokens por jugador
    // private List<StatusCurrentPlay> StatusCurrentPlay{ get; set; } // Información pública de los jugadores
    PublicInformation Information = new PublicInformation();

    // Intancias de las variaciones
    Player[] players;
    IBoard board;
    IDistributeTokens distributeTokens;
    IFinishGame finishGame;
    IWinGame winnersGame;
    INextPlayer nextPlayer;
    Refery refery;

    public Manager( IEnumerable<Player> players, IBoard board, 
                    IDistributeTokens distributeTokens, IFinishGame finishGame, 
                    IWinGame winnersGame, INextPlayer nextPlayer, Refery refery ) {

        this.board = board;
        this.distributeTokens = distributeTokens;
        this.finishGame = finishGame;
        this.winnersGame = winnersGame;
        this.nextPlayer = nextPlayer;
        this.refery = refery;
        
        // Actualizar el tamaño de las propiedades generales
        Information.PassedOfPlayers = new int[players.Count()]; 
        Information.CountTokenByPlayers = new int[players.Count()];
        Information.IdOfPlayers = new int[players.Count()];

        List<Player> ply = new List<Player>();
        int idx = 0;
        foreach( var pl in players ) {
            ply.Add(pl);
            Information.IdOfPlayers[idx ++] = pl.IDPlayer.Item1;
        }

        this.players = ply.ToArray();
    }

    // Inicializa el juego creando las fichas y repartiéndolas
    public void StartGame( int MaxIdOfToken, int countTokens, ITokenValue CalculateValue, IMatch matcher ) {
        Information.MaxIdOfToken = MaxIdOfToken;
        this.board.SetMatcher(matcher);
        List<Token> bTokens = this.board.BuildTokens( MaxIdOfToken, CalculateValue );
        List<Token>[] htokens = this.distributeTokens.DistributeTokens(bTokens, this.players.Length, countTokens);
        // Le da las fichas al refery para que las reparta
        this.refery.MakeTokens(htokens, this.players);
    }
    
    // Realiza una jugada y devuelve información de la jugada
    public PlayInfo GamePlay() { 

        // seleccionar el jugador y realizar la jugada
        int idCurrentPlayer = this.nextPlayer.NextPlayer( this.refery.PlayerInformation );
        StatusCurrentPlay currentPlay = this.refery.Play(idCurrentPlayer, Information);
        Information.StatusCurrentPlay.Add(currentPlay);
        bool played = !currentPlay.Passed;

        // Actualizar las propiedades estáticas
        int indexCurrentPlayer = this.SearchPlayerIndex(idCurrentPlayer);
        Information.CountTokenByPlayers[ indexCurrentPlayer ] -= ( played ? 1 : 0 );
        Information.CountTokenByPlayers[ indexCurrentPlayer ] = Math.Max(0, Information.CountTokenByPlayers[ indexCurrentPlayer ] );
        Information.PassedOfPlayers[ indexCurrentPlayer ] += ( played ? 0 : 1 );

        // Construir la información de la jugada y retornarla
        PlayInfo CurrInfo = new PlayInfo() {
            Players = Game.PlayersForJson( this.refery.PlayerInformation, this.refery.Clone() ),
            CurrentPlayer = idCurrentPlayer,
            points = this.refery.Points(idCurrentPlayer),
            Passed = !played,
            TokensInBoard = Game.TokensInBoardJson( this.board.Clone().TokensInBoard ),
            FinishGame = this.finishGame.FinishGame( this.board.Clone(), this.refery.PlayerInformation, Information.Clone() ),
            Winners = Game.PlayersForJson( this.winnersGame.GetWinnersGame(this.board.Clone(), this.refery.PlayerInformation).ToArray<PlayerInfo>(), this.refery.Clone() ),
        };

        return CurrInfo;
    }

    // Buscar el índice en el arreglo de jugadores del jugador con el ID
    public int SearchPlayerIndex(int ID) {
        for( int i = 0; i < Information.IdOfPlayers.Length; i ++ ) {
            if( Information.IdOfPlayers[i] == ID ) return i;
        }
        return -1;
    }

}
