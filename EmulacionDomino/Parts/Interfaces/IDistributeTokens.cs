namespace Domino.Interfaces;

public interface IDistributeTokens {
    IEnumerable<IPlayer> DistributeTokens( IEnumerable< IToken > tokens, IEnumerable<IPlayer> players );   
}