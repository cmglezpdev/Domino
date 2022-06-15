namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IDistributeTokens {
    IPlayer[] DistributeTokens( Token[] tokens, IPlayer[] players );   
}