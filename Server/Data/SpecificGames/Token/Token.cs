namespace Server.Data.Classes;

// * Ficha 
public class Token {

    // id de la cara, true si esta disponible pa jugarla
    protected int Right;
    protected bool DisponibilityRight;
    protected int Left;
    protected bool DisponibilityLeft;

    public Token(int left, int right){
        (this.Left, this.DisponibilityLeft) = (left, true);
        (this.Right, this.DisponibilityRight) = (right, true);
    }
    public virtual (int, bool) right {
        get{
            return (this.Right, this.DisponibilityRight);
        }
    }
    public virtual (int, bool) left {
        get{
            return (this.Left, this.DisponibilityLeft);
        }
    }
    public virtual int value {
        get {
            return this.Right + this.Left;
        }
    }
    // Marca como true la cara de la ficha que se jugo
    public virtual void Played (int ID) {
         if( ID == this.Left && this.DisponibilityLeft ) {
           this.DisponibilityLeft = false;
           return;
        }
        if( ID == this.Right && this.DisponibilityRight ) {
           this.DisponibilityRight = false;
           return;
        }

    }

    public virtual void SwapVertex () {
        int aux = this.Right;
        this.Right = this.Left;
        this.Left = aux;

        bool aux2 = this.DisponibilityRight;
        this.DisponibilityRight = this.DisponibilityLeft;
        this.DisponibilityLeft = aux2;
    }

    public virtual Token Clone() {
        Token CloneT = new Token(this.Left, this.Right);
        if( !this.DisponibilityLeft ) CloneT.Played( this.Left );
        if( !this.DisponibilityRight ) CloneT.Played( this.Right );

        return CloneT;
    }

}
