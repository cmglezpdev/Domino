namespace Domino.Interfaces;

public interface IPlayer {
    void MakeTokens( IEnumerable< IToken > tokens );    
    void PlayToken( IBoard board ); 

}