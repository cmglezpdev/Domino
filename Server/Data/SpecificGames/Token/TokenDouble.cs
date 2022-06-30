namespace Server.Data.Classes;

public class TokenDouble : Token
{   
    public InfoFace Up;
    public InfoFace Down;
    public TokenDouble(int left, int right, TokenValue calculateValue) : base(left, right, calculateValue)
    {
        this.Up = new InfoFace(){
            IdFace = left,
            Face = "up",
            Played = false,
            Value = left
        };
        this.Down = new InfoFace(){
            IdFace = right,
            Face = "down",
            Played = false,
            Value = right
        };
    }

    public override InfoFace this[int index]
    {
        get
        {
            if (index == 0)
            {
                return this.Left;
            }
            else if (index == 1)
            {
                return this.Right;
            }
            else if (index == 2)
            {
                return this.Left;
            }
            else if (index == 3)
            {
                return this.Right;
            }
            else
            {
                throw new System.Exception("Indice fuera de rango");
            }
        }
    }
    public override Token Clone() {
        Token CloneT = new TokenDouble(this.Left.Value, this.Right.Value, this.CalculateValue);
        CloneT.Left = new InfoFace(){
            IdFace = this.Left.Value,
            Face = this.Left.Face,
            Played = this.Left.Played,
            Value = this.Left.Value
        };
        CloneT.Right = new InfoFace(){
            IdFace = this.Right.Value,
            Face = this.Right.Face,
            Played = this.Right.Played,
            Value = this.Right.Value
        };
        ((TokenDouble)CloneT).Up = new InfoFace(){
            IdFace = this.Left.Value,
            Face = this.Left.Face,
            Played = this.Left.Played,
            Value = this.Left.Value
        };
        ((TokenDouble)CloneT).Down = new InfoFace(){
            IdFace = this.Right.Value,
            Face = this.Right.Face,
            Played = this.Right.Played,
            Value = this.Right.Value
        };

        return CloneT;
    }
   public override void Played(int face, int valueFace)
    {
        if (face == 0 && this.Left.Value == valueFace && !this.Left.Played)
        {
            this.Left.Played = true;
        }
        else if (face == 1 && this.Right.Value == valueFace && !this.Right.Played)
        {
            this.Right.Played = true;
        }
        else if (face == 2 && this.Up.Value == valueFace && !this.Up.Played)
        {
            this.Up.Played = true;
        }
        else if (face == 3 && this.Down.Value == valueFace && !this.Down.Played)
        {
            this.Down.Played = true;
        }
        else
        {
            throw new System.Exception("Error: No se puede jugar la cara");
        }
    }

    public override void Played(int face) {
        if (face == 0 && !this.Left.Played)
        {
            this.Left.Played = true;
        }
        else if (face == 1 && !this.Right.Played)
        {
            this.Right.Played = true;
        }
        else if (face == 2 && !this.Up.Played)
        {
            this.Up.Played = true;
        }
        else if (face == 3 && !this.Down.Played)
        {
            this.Down.Played = true;
        }
        else
        {
            throw new System.Exception("Error: No se puede jugar la cara");
        }
    }

}