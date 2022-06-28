namespace Server.Data.Classes;

public class SumOfFaces : TokenValue {
    public override int Value( Token token ) {
        return token.left.Item1 + token.right.Item1;
    }
}