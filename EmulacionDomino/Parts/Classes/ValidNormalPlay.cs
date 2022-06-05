namespace Domino.Classes;
using Domino.Interfaces;
public class ValidNormalPlay : IValidPlay {
    public IEnumerable< int > validplay(IToken token, IEnumerable< int > AvalPlay) {
        //recibe donde se puede jugar y revisa si es valido colocar la ficha
        List< int > aux = new List<int>();
        foreach( int item in token.IDs){
            foreach( int item2 in AvalPlay){
                if(item == item2) aux.Add(item);
            }
        }
        return aux;
    }
}