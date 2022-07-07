namespace Server.Data.Interfaces;
using Server.Data.Classes;

public interface IDistributeTokens {
    List<Token>[] DistributeTokens( List<Token> tokens,int numberofplayers, int countTokens );   
    IDistributeTokens Clone();
}