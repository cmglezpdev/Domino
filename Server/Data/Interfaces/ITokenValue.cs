using Server.Data.Classes;
namespace Server.Data.Interfaces;

// Contrato a cumplir para crear una variacion de como se calcula el valor de una ficha
public interface ITokenValue {
    int Value( Token token );
    ITokenValue Clone();
}