namespace Server.Data.Classes;

public class SumOfFaces : TokenValue {
    public override TokenValue Clone() => new SumOfFaces();

    public override int Value( Token token ) {
        int value = (int)(token.Left.Value + token.Right.Value)!;
            if( value < 0 ) value *= -1;
            return value;        
    }
}