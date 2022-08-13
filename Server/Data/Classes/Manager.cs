namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class Manager {
    public int MaxIdOfToken{ get; private set; } // Máximo número que puede tener una ficha
    public int[] IdOfPlayers{ get; private set; } = new int[0]; // Índice de los jugadores(esto corresponde con las propiedades de abajo)
    public int[] PassedOfPlayers{ get; private set; } = new int[0]; // Pases de los jugadores
    public int[] CountTokenByPlayers{ get; private set; } = new int[0]; // Contador de tokens por jugador
    public List<StatusCurrentPlay> StatusCurrentPlay{ get; private set; } = new List<StatusCurrentPlay>(); // Información pública de los jugadores

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
        this.PassedOfPlayers = new int[players.Count()]; 
        this.CountTokenByPlayers = new int[players.Count()];
        this.IdOfPlayers = new int[players.Count()];

        List<Player> ply = new List<Player>();
        int idx = 0;
        foreach( var pl in players ) {
            ply.Add(pl);
            this.IdOfPlayers[idx ++] = pl.IDPlayer.Item1;
        }

        this.players = ply.ToArray();
    }

    // Inicializa el juego creando las fichas y repartiéndolas
    public void StartGame( int MaxIdOfToken, int countTokens, ITokenValue CalculateValue, IMatch matcher ) {
        this.MaxIdOfToken = MaxIdOfToken;
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
        bool played = this.refery.Play(idCurrentPlayer);
        
        // Actualizar las propiedades estáticas
        int indexCurrentPlayer = this.SearchPlayerIndex(idCurrentPlayer);
        this.CountTokenByPlayers[ indexCurrentPlayer ] -= ( played ? 1 : 0 );
        this.CountTokenByPlayers[ indexCurrentPlayer ] = Math.Max(0, this.CountTokenByPlayers[ indexCurrentPlayer ] );
        this.PassedOfPlayers[ indexCurrentPlayer ] += ( played ? 0 : 1 );

        // Construir la información de la jugada y retornarla
        PlayInfo CurrInfo = new PlayInfo() {
            Players = Game.PlayersForJson( this.refery.PlayerInformation, this.refery.Clone() ),
            CurrentPlayer = idCurrentPlayer,
            points = this.refery.Points(idCurrentPlayer),
            Passed = !played,
            TokensInBoard = Game.TokensInBoardJson( this.board.Clone().TokensInBoard ),
            FinishGame = this.finishGame.FinishGame( this.board.Clone(), this.refery.PlayerInformation ),
            Winners = Game.PlayersForJson( this.winnersGame.GetWinnersGame(this.board.Clone(), this.refery.PlayerInformation).ToArray<PlayerInfo>(), this.refery.Clone() ),
        };

        return CurrInfo;
    }

    // Buscar el índice en el arreglo de jugadores del jugador con el ID
    public int SearchPlayerIndex(int ID) {
        for( int i = 0; i < this.IdOfPlayers.Length; i ++ ) {
            if( this.IdOfPlayers[i] == ID ) return i;
        }
        return -1;
    }
}
