namespace ServerApp.Models;

public class GeneralOptions {
    public int CountOptions {get; set;} // Cantidad de opciones a modificar en el juego
    public ChangeOptions[]? Options { get; set; }

}

public class ChangeOptions {
    public string? titleOption { get; set; }
    public string? id { get; set; }
    public string[]? nameOptions { get; set; }
}
