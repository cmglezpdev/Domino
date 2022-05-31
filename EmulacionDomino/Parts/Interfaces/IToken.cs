namespace Domino.Interfaces;

public interface IToken {
    IEnumerable< int > IDs{ get; } 
    int value { get; }
    IEnumerable< int > AviablePositions { get; }
    void Play ( int ID);
}