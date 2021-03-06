namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class Manager {
    public int MaxIdOfToken{ get; private set; } 
    public int[] IdOfPlayers{ get; private set; } = new int[0]; // Indice de los jugadores(esto corresponde con las propiedades de abajo)
    public int[] PassedOfPlayers{ get; private set; } = new int[0]; // Pases de los jugadores
    public int[] CountTokenByPlayers{ get; private set; } = new int[0]; // Contador de tokens por jugador
    public List<StatusCurrentPlay> StatusCurrentPlay{ get; private set; } = new List<StatusCurrentPlay>(); // Informacion publica de los jugadores

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
        
        // Actualizar el tamanno de las propiedades staticas
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

    public void StartGame( int MaxIdOfToken, int countTokens, ITokenValue CalculateValue, IMatch matcher ) {
        this.MaxIdOfToken = MaxIdOfToken;
        this.board.SetMatcher(matcher);
        List<Token> bTokens = this.board.BuildTokens( MaxIdOfToken, CalculateValue );
        List<Token>[] htokens = this.distributeTokens.DistributeTokens(bTokens, this.players.Length, countTokens);
        this.refery.MakeTokens(htokens, this.players);
    }
    
    // Realiza una jugada y devuelve informacion de la jugada
    public PlayInfo GamePlay() { 

        int idCurrentPlayer = this.nextPlayer.NextPlayer( this.refery.PlayerInformation );
        bool played = this.refery.Play(idCurrentPlayer);
        
        // Actualizar las propiedades staticas
        int indexCurrentPlayer = this.SearchPlayerIndex(idCurrentPlayer);
        this.CountTokenByPlayers[ indexCurrentPlayer ] -= ( played ? 1 : 0 );
        this.CountTokenByPlayers[ indexCurrentPlayer ] = Math.Max(0, this.CountTokenByPlayers[ indexCurrentPlayer ] );
        
        this.PassedOfPlayers[ indexCurrentPlayer ] += ( played ? 0 : 1 );

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

    public int SearchPlayerIndex(int ID) {
        for( int i = 0; i < this.IdOfPlayers.Length; i ++ ) {
            if( this.IdOfPlayers[i] == ID ) return i;
        }
        return -1;
    }
}
