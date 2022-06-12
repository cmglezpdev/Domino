namespace Server.Models;

public class GeneralOptions {
    public ChangeOptions[]? Options { get; set; }

}

public class ChangeOptions {
    public string? titleOption { get; set; }
    public string? id { get; set; }
    public string[]? nameOptions { get; set; }
}
