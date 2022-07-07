namespace Server.Data.Classes;

public class SubOfFaces : TokenValue {
    public override TokenValue Clone() => new SubOfFaces();

    public override int Value( Token token ) {
        int value = (int)(token.Left.Value - token.Right.Value);
        if( value < 0 ) value *= -1;
        return value;
    }
}