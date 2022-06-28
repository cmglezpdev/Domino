namespace Server.Data.Classes;

public class SubOfFaces : TokenValue {
    public override int Value( Token token ) {
        int value = token.left.Item1 - token.right.Item1;
        if( value < 0 ) value *= 0;
        return value;
    }
}