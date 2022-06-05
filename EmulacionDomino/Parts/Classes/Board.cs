namespace Domino.Classes;
using Domino.Interfaces;
public class Board : IBoard {

    List<IToken> board = new List<IToken>();
    List<IToken> Aviabletoken = new List<IToken>();
    //las pocisiones donde es posible jugar
    public IEnumerable< IToken > BuildTokens( int MaxIdOfToken ) {
        List<Token> tokens = new List<Token>();

        for(int i = 0; i <= MaxIdOfToken; i++){
            for(int j = i + 1; j <= MaxIdOfToken; j++){
                tokens.Add(new Token(new int[]{i , j}));
            }
        }
        return tokens;
    }
    public void PlaceToken( IToken token, int ID, IFinishGame finish ) {
        ValidNormalPlay valid = new ValidNormalPlay();
        for(int i = 0; i < Aviabletoken.Count; i++) {
            //recibo las posiciones donde se puede jugar la ficha recibida
            IEnumerable< int > validplays = valid.validplay(token,this.Aviabletoken[i].AviablePositions);
            foreach(int itemI in validplays){
                //si es valido jugar por la posicion solicitada se juega
                if(itemI == ID){
                    //juego la ficha
                    board.Add(token);
                    //marco la ficha jugada
                    token.Play(ID);
                    finish.notpass();
                }
            }
        }
        for( int i = 0; i < Aviabletoken.Count; i++){
            foreach(int item in Aviabletoken[i].AviablePositions){
                //marco la ficha que jugue en las que hay en la mesa
                if(item == ID) {
                    Aviabletoken[i].Play(ID);
                    //si no se puede jugar mas por esa ficha se elimina de las disponiles
                    if(Aviabletoken[i].AviablePositions.Count() == 0)
                        Aviabletoken.RemoveAt(i);
                }
            }
        }
        if(token.AviablePositions.Count() != 0){
            Aviabletoken.Add(token);
        }
    }
    public IEnumerable< IToken > AviableTokens {
        get{ 
            return Aviabletoken;
            }
    }
}
