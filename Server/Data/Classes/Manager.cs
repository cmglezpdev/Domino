namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class Manager {
    static public int MaxIdOfToken; 
    static public int[] IdOfPlayers = new int[0]; // Indice de los jugadores(esto corresponde con las propiedades de abajo)
    static public int[] PassedOfPlayers = new int[0]; // Pases de los jugadores
    static public int[] CountTokenByPlayers = new int[0]; // Contador de tokens por jugador
    static public List<StatusCurrentPlay> StatusCurrentPlay = new List<StatusCurrentPlay>(); // Informacion publica de los jugadores

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
        Manager.PassedOfPlayers = new int[players.Count()]; 
        Manager.CountTokenByPlayers = new int[players.Count()];
        Manager.IdOfPlayers = new int[players.Count()];

        List<Player> ply = new List<Player>();
        int idx = 0;
        foreach( var pl in players ) {
            ply.Add(pl);
            Manager.IdOfPlayers[idx ++] = pl.IDPlayer.Item1;
        }

        this.players = ply.ToArray();
    }

    public void StartGame( int MaxIdOfToken, int countTokens, TokenValue CalculateValue, IMatch matcher ) {
        Manager.MaxIdOfToken = MaxIdOfToken;
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
        int indexCurrentPlayer = Manager.SearchPlayerIndex(idCurrentPlayer);
        Manager.CountTokenByPlayers[ indexCurrentPlayer ] -= ( played ? 1 : 0 );
        Manager.CountTokenByPlayers[ indexCurrentPlayer ] = Math.Max(0, Manager.CountTokenByPlayers[ indexCurrentPlayer ] );
        
        Manager.PassedOfPlayers[ indexCurrentPlayer ] += ( played ? 0 : 1 );

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

    public static int SearchPlayerIndex(int ID) {
        for( int i = 0; i < Manager.IdOfPlayers.Length; i ++ ) {
            if( Manager.IdOfPlayers[i] == ID ) return i;
        }
        return -1;
    }
}
