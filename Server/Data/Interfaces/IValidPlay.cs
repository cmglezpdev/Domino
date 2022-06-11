namespace Server.Data.Interfaces;

public interface IValidPlay {
    IEnumerable< int > Validplay(IToken token, IBoard board); 
    
}