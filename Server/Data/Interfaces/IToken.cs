namespace Server.Data.Interfaces;

public interface IToken {
    (int, bool) right { get; }
    (int, bool) left { get; }
    int value { get; }
    void Played ( int ID);
    void SwapVertex();
    IToken Clone();
}