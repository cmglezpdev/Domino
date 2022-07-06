namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IWinGame {
    IEnumerable<Player> GetWinnersGame( IBoard board, IEnumerable<PlayerInfo> players );

}