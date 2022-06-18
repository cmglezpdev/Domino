namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IDistributeTokens {
    IPlayer[] DistributeTokens( List<Token> tokens, IPlayer[] players, int countTokens );   
}