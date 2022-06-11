namespace Domino.Classes;
using Domino.Interfaces;
public class Token : IToken {

    // id de la cara, true si esta disponible pa jugarla
    int Right;
    bool DisponibilityRight;
    int Left;
    bool DisponibilityLeft;

    public Token(int left, int right){
        (this.Left, this.DisponibilityLeft) = (left, true);
        (this.Right, this.DisponibilityRight) = (right, true);
    }
    public (int, bool) right {
        get{
            return (this.Right, this.DisponibilityRight);
        }
    }
    public (int, bool) left {
        get{
            return (this.Left, this.DisponibilityLeft);
        }
    }
    public int value {
        get {
            return this.Right + this.Left;
        }
    }
    // Marca como true la cara de la ficha que se jugo
    public void Played (int ID) {
         if( ID == this.Left && this.DisponibilityLeft ) {
           this.DisponibilityLeft = false;
           return;
        }
        if( ID == this.Right && this.DisponibilityRight ) {
           this.DisponibilityRight = false;
           return;
        }

    }

    public void SwapVertex () {
        int aux = this.Right;
        this.Right = this.Left;
        this.Left = aux;

        bool aux2 = this.DisponibilityRight;
        this.DisponibilityRight = this.DisponibilityLeft;
        this.DisponibilityLeft = aux2;
    }

    public IToken Clone() {
        IToken CloneT = new Token(this.Left, this.Right);
        if( !this.DisponibilityLeft ) CloneT.Played( this.Left );
        if( !this.DisponibilityRight ) CloneT.Played( this.Right );

        return CloneT;
    }

}
