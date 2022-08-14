namespace Server.Data.Classes;
using Server.Data.Interfaces;
public class HeuristicPlayer : RandomPlayer {
    List<int> InHand = new List<int>();
    public override int PlayToken(IBoard board, Token[] hand)
    {
        // Hago una llamada al metodo Organize, el cual almacena en la propiedad InHand cunatas fichas de cada valor posee el jugador en estae turno
        Organize((int)Game.manager?.MaxIdOfToken!, hand);
        // Sino se ha jugado niguna jugada, es decir le toca empezar al jugado, se llamaal metodo start
        if(board.TokensInBoard.Length == 0){
            int start = Start(hand);
            return start;
        }

        // Selecciono la ficha cuyas caras mas veces tengo repetida y la juego, en la dupla el primer termino es el valor de la ficha y el segundo la cantidad de veces que la tengo

        //Nota: este metodo no es muy util en un modo de juego donde se necesite quedarsecon fichas, ues la logica es tratar de siempre tener una ficha para jugar
        (int,int) aux = (0,0);
        for(int i = 0; i < hand.Length; i++) {
            int a = InHand[hand[i][0].Value] + InHand[hand[i][1].Value];
            if(board.ValidPlay(hand[i]) && a > aux.Item2){
                aux = (i, a);
            }
        }
        // Si la cantdad de fichas es 0, es decir que no tengo jugada valida
        if(aux.Item2 != 0){
            return aux.Item1;
        }
        return -1;
    }
    public override Player Clone() {
        HeuristicPlayer clone = new HeuristicPlayer();
        clone.IDPlayer = this.IDPlayer;
        clone.InHand = this.InHand;
        return clone;
    }

    // Metodo utilizado si el tablero esta vacio, trata de seleccioar e doble con mas repetciones, y  en su defecto la ficha con mas repeticiones
    private int Start(Token[] hand) {
        // Llamo al metodo Double que devuelve una lista con todos los dobles
        List<(Token,int)> doubles = Double(hand);
        if(doubles.Count == 0) { 
            int maxtokenindex = 0; 
            for(int i = 0; i < InHand.Count; i++) {
                if(InHand[i] > InHand[maxtokenindex])
                    maxtokenindex = i;
            }
            (int,int) auxindex = (0,0);
            for(int i = 0; i < hand.Length; i++) {
                if(hand[i][1].Value == maxtokenindex && InHand[hand[i][0].Value] > auxindex.Item2 ) {
                    auxindex = (i,InHand[hand[i][0].Value]);
                }
                else if(hand[i][0].Value == maxtokenindex && InHand[hand[i][1].Value] > auxindex.Item2) {
                    auxindex = (i,InHand[hand[i][1].Value]);
                }
            }
            return auxindex.Item1;
        }
        (Token,int) aux = doubles[0];
        for(int i = 0; i < doubles.Count; i++) {
            int aux1 = doubles[i].Item1[1].Value;
            int aux2 = aux.Item1[1].Value;
            if((InHand[aux1] > InHand[aux2]) || (InHand[aux1] == InHand[aux2] && aux2 > aux1))
                aux = doubles[i];
        }
        return aux.Item2;
    }
    private void Organize(int maxidtoken, Token[] hand) {
        InHand.Clear();
        int cant = 0;
        for(int i = 0; i < maxidtoken + 1; i++) {
            for(int j = 0; j < hand.Length; j++) {
                if(i == hand[j][1].Value || i == hand[j][0].Value) {
                    cant++;
                }
            }
            InHand.Add(cant);
            cant = 0;
        }
    }
    private List<(Token,int)> Double(Token[] hand) {
        List<(Token,int)> aux = new List<(Token,int)>();
        for(int i = 0; i < hand.Length; i++) {
            if(hand[i][1].Value == hand[i][0].Value)
                aux.Add((hand[i],i));
        }
        return aux;
    }
}