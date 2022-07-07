namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface INextPlayer {
    int NextPlayer( PlayerInfo[] players );
    INextPlayer Clone();
}