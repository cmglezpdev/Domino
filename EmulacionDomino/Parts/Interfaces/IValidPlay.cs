namespace Domino.Interfaces;

public interface IValidPlay {
    IEnumerable< int > validplay(IToken token, IEnumerable< int > AvaliblePositions); 
    
}