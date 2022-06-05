namespace Domino.Classes;
using Domino.Interfaces;
public class Finish : IFinishGame {
    int pass = 0;
    public bool FinishGame( IBoard board, IEnumerable<IPlayer> players ) {
        if(this.pass == 4) return true;

        foreach( IPlayer item in players) {
            if( item.cant == 0) return true;
        }
        return false;
    }
    public void Pass() {
        this.pass ++;
    }
    public void notpass(){
        this.pass = 0;
    }
}