namespace Server.Data;
using Server.Data.Interfaces;
using Server.Data.Classes;
public class Data {
    public IPlayer[] Players = new IPlayer[] {
        new RandomPlayer(),
    };
    public IDistributeTokens[] DistributeTokens = new IDistributeTokens[] {
        new RandomDistribution(),
    };
    public IFinishGame[] FinishGames = new IFinishGame[] {
        new Finish(),
    };
    public IWinGame[] WinGames = new IWinGame[] {
        new WinGame(),
    };
    public INextPlayer[] NextPlayers = new INextPlayer[] {
        new NextTurn(),
    };
}

public static class Game {
    public static Manager? manager;
}

