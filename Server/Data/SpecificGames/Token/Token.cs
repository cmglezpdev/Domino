namespace Server.Data.Classes;
using Server.Data.Interfaces;

// * Ficha 
public class Token {

    // id de la cara, true si esta disponible pa jugarla
    public InfoFace Left;
    public InfoFace Right;
    protected ITokenValue CalculateValue;

    public Token(int left, int right, ITokenValue calculateValue ){
        this.CalculateValue = calculateValue;
        this.Left = new InfoFace(){
            IdFace = 0,
            Face = "left",
            Played = false,
            Value = left
        };

        this.Right = new InfoFace(){
            IdFace = 0,
            Face = "right",
            Played = false,
            Value = right
        };
    }
    public virtual InfoFace this[int index]{
        get{
            if( index > 1 ) throw new System.Exception("Indice fuera de rango");
            return index == 0 ? this.Left : this.Right;
        }
    }

    public virtual InfoFace[] Faces{
        get{
            return new InfoFace[]{
                this.Left,
                this.Right
            };
        }
    }

    public int Value => this.CalculateValue.Value(this);
    public virtual void Played (int face, int valueFace) {
        if(face == 0 && this.Left.Value == valueFace && !this.Left.Played){
            this.Left.Played = true;
        }
        else if(face == 1 && this.Right.Value == valueFace && !this.Right.Played){
            this.Right.Played = true;
        } else {
            throw new System.Exception("Error: No se puede jugar la cara");
        }
    }

    public virtual void Played(int face) {
        if(face == 0 && !this.Left.Played){
            this.Left.Played = true;
        }
        else if(face == 1 && !this.Right.Played){
            this.Right.Played = true;
        } else {
            throw new System.Exception("Error: No se puede jugar la cara");
        }
    }

    public virtual void SwapFaces() {
        InfoFace aux =  new InfoFace(){
            IdFace = 1,
            Face = "right",
            Played = this.Left.Played,
            Value = this.Left.Value
        };

        this.Left =  new InfoFace(){
            IdFace = 0,
            Face = "left",
            Played = this.Right.Played,
            Value = this.Right.Value
        };

        this.Right = aux.Clone();
    }
    public virtual Token Clone() {
        Token CloneT = new Token(this.Left.Value, this.Right.Value, this.CalculateValue);
        CloneT.Left = this.Left.Clone();
        CloneT.Right = this.Right.Clone();
        return CloneT;
    }
}

public class InfoFace {
    public int Value {get; set;}
    public bool Played {get; set;}
    public string? Face {get;set;}
    public int IdFace {get;set;}

    public InfoFace Clone() {
        return new InfoFace(){
            IdFace = this.IdFace,
            Face = this.Face,
            Played = this.Played,
            Value = this.Value
        };
    }
}