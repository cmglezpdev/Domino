namespace Domino.Classes;
using Domino.Interfaces;
public class NextTurn : INextPlayer {
    List< IPlayer > Players = new List<IPlayer>();
    int cursor = 0;
    public IPlayer NextPlayer( IEnumerable< IPlayer > players ) {
        if(Players.Count == 0) {
            foreach(IPlayer item in players){
                Players.Add(item);
            }
        }
        IPlayer aux = Players[cursor];
        cursor ++;
        return aux;
    }
}