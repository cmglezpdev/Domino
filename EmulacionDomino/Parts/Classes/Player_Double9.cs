namespace Domino.Classes;
using Domino.Interfaces;
public class Player_Double9 : IPlayer {
    List< IToken > hand = new List<IToken>();
    public void MakeTokens( IEnumerable< IToken > tokens ) {
        foreach(IToken item in tokens){
            hand.Add(item);
        }
    }    
    public void PlayToken( IBoard board, IFinishGame finish ) {
        ValidNormalPlay a = new ValidNormalPlay();
        //revisa por todas las fichas donde esposible jugar si alguna de las que posee coincide
        foreach( IToken item in board.AviableTokens) {
            for( int i = 0; i < hand.Count; i++){
                //reciba un enumerable con las posiciones donde se puede jugar
                IEnumerable< int > aux = a.validplay ( hand[i], item.AviablePositions);
                if(aux.Count() != 0) {
                    foreach( int itemI in aux ){
                        board.PlaceToken(hand[i], itemI, finish);
                        hand.RemoveAt(i);
                        return;
                    }
                }
            }
        }
        finish.Pass();
    }
    public int cant {
        get { return hand.Count; }
    }
    public int points {
        get {
            int total = 0;
            for( int i = 0; i < hand.Count; i++ ) {
                foreach( int item in hand[i].IDs){
                    total += item;
                }
            }
            return total;
        }
    }
}