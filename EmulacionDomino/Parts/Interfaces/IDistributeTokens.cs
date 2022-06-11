namespace Domino.Interfaces;

public interface IDistributeTokens {
    IPlayer[] DistributeTokens( IToken[] tokens, IPlayer[] players );   
}