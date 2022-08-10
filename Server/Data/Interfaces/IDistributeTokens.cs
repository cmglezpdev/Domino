namespace Server.Data.Interfaces;
using Server.Data.Classes;

// Reglas a cumplir para crear una variación de de como se distribuyen las fichas entre los jugadores
public interface IDistributeTokens {
    List<Token>[] DistributeTokens( List<Token> tokens,int numberofplayers, int countTokens );   
    IDistributeTokens Clone();
}