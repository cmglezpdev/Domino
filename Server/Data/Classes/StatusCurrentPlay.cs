namespace Server.Data.Classes;
using Server.Data.Interfaces;

public class StatusCurrentPlay {
    public int IDPlayerPlayed {get; set;}
    public bool Passed {get; set;}
    public Token? TokenPlayed {get; set;}
    public IBoard? StatusBoard {get; set;}
}