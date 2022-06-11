namespace Server.Data;
using Server.Data.Interfaces;
using Server.Data.Classes;
public class Data {
    IPlayer[] Players = new IPlayer[] {
        new RandomPlayer(),
    };
    IDistributeTokens[] DistributeTokens = new IDistributeTokens[] {
        new RandomDistribution(),
    };
    IFinishGame[] FinishGames = new IFinishGame[] {
        new Finish(),
    };
    IWinGame[] WinGames = new IWinGame[] {
        new WinGame(),
    };
    INextPlayer[] NextPlayers = new INextPlayer[] {
        new NextTurn(),
    };
}



