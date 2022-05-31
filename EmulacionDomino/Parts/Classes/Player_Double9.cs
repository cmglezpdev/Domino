namespace Domino.Classes;
using Domino.Interfaces;
public class Player_Double9 : IPlayer {
    List< IToken > hand = new List<IToken>();
    public void MakeTokens( IEnumerable< IToken > tokens ) {
        foreach(IToken item in tokens){
            hand.Add(item);
        }
    }    
    public void PlayToken( IBoard board ) {
        ValidNormalPlay a = new ValidNormalPlay();
        foreach( IToken item in board.AviableTokens) {
            for( int i = 0; i < hand.Count; i++){
                IEnumerable< int > aux = a.validplay ( hand[i], item.AviablePositions);
                if(aux.Count() != 0) {
                    foreach( int itemI in aux ){
                        board.PlaceToken(hand[i], itemI);
                        hand.RemoveAt(i);
                        return;
                    }
                }
            }
        }
    }
}