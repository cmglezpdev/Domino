namespace Server.Data;
using Server.Data.Interfaces;
using Server.Data.Classes;
public class Data {

    // Datos correspondientes a la cantidad de jugadores posibles a seleccionar
    public int[] countPlayers = new int[] {
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10
    };
    // Datos correspondientes al maximo numero que se le podra poner a una ficha
    public int[] maxIdTokens = new int[] {
        3,
        4,
        5,
        6,
        7,
        8,
        9,
    };
    // Cantidad de fichas que se seleccionará por jugador
    public int[] countTokens = new int[] {
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
    };
    // varaiciones de los jugadores
    public Player[] Players = new Player[] {
        new RandomPlayer(),
        new BotaGordaPlayer(),
        new HeuristicPlayer(),
    };
    // Variaciones del tablero
    public IBoard[] Boards = new IBoard[] {
        new UnidimensionalBoard(),
        new MultidimensionalBorad(),
    };
    // Variaciones de como se calcula el valor de una ficha
    public ITokenValue[] TokensValue = new ITokenValue[] {
        new SumOfFaces(),
        new SubOfFaces(),
        new RareProperties(),
    };
    // Variaciones de como se pueden colocar dos fichas en el tablero
    public IMatch[] Matches = new IMatch[] {
        new EqualFace(),
        new RareEquivalence(),
    };
    // Variaciones de como se distribuye las fichas entre los jugadores
    public IDistributeTokens[] DistributeTokens = new IDistributeTokens[] {
        new RandomDistribution(),
        new AllforOneDistribution(),
    };
    // Variaciones de como se finaliza el juego 
    public IFinishGame[] FinishGames = new IFinishGame[] {
        new AllPassFinish(),
        new APassFinish()
    };
    // variaciones de como se gana el juego
    public IWinGame[] WinGames = new IWinGame[] {
        new FewPoints(),
        new ALotPoints()
    };
    // Variaciones de como se selecciona el proximo jugador
    public INextPlayer[] NextPlayers = new INextPlayer[] {
        new OrderTurn(),
        new RandomTurn(),
        new InvertedTurn(),
        new NextPlayerLongana(),
    };
}
