using Server.Data.Classes;
namespace Server.Data.Interfaces;

public interface ITokenValue {
    int Value( Token token );
    ITokenValue Clone();
}