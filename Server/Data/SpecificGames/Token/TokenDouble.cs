namespace Server.Data.Classes;

public class TokenDouble : Token
{   
    protected bool DisponibilityUp;
    protected bool DisponibilityDown;
    public TokenDouble(int left, int right) : base(left, right)
    {
        this.DisponibilityDown = true;
        this.DisponibilityUp = true;
    }

    public (int, bool) up {
        get{
            return (this.left.Item1, this.DisponibilityUp);
        }
    }
    public (int, bool) down {
        get{
            return (this.left.Item1, this.DisponibilityDown);
        }
    }

    // /Left y Right se mantienen igual
    // Value se mantiene

    public override void Played (int ID) {
        if( ID == this.Left && this.DisponibilityLeft ) {
           this.DisponibilityLeft = false;
           return;
        }
        if( ID == this.Right && this.DisponibilityRight ) {
           this.DisponibilityRight = false;
           return;
        }
        
        if( ID == this.Left && this.DisponibilityUp ) {
           this.DisponibilityUp = false;
           return;
        }
        if( ID == this.Right && this.DisponibilityDown ) {
           this.DisponibilityDown = false;
           return;
        }   
    }

    // Swap se mantiene
    public override Token Clone() {
        Token CloneT = new TokenDouble(this.Left, this.Right){
            DisponibilityUp = this.DisponibilityUp,
            DisponibilityRight = this.DisponibilityRight,
            DisponibilityDown = this.DisponibilityDown,
            DisponibilityLeft = this.DisponibilityLeft
        };

        return CloneT;
    }

    public override bool CanPlayForToken() {
        return (base.CanPlayForToken() || this.DisponibilityUp || this.DisponibilityDown);
    }
}