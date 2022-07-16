namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class SubOfFaces : ITokenValue {
    public ITokenValue Clone() => new SubOfFaces();

    public int Value( Token token ) {
        int value = (int)(token.Left.Value - token.Right.Value);
        if( value < 0 ) value *= -1;
        return value;
    }
}