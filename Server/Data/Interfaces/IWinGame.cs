namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IWinGame {
    IEnumerable<PlayerInfo> GetWinnersGame( IBoard board, IEnumerable<PlayerInfo> players );
    IWinGame Clone();
}