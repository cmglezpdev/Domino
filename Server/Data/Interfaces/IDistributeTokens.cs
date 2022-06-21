namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IDistributeTokens {
    Player[] DistributeTokens( List<Token> tokens, Player[] players, int countTokens );   
}