namespace Domino.Interfaces;

public interface IValidPlay {
    IEnumerable< int > Validplay(IToken token, IBoard board); 
    
}