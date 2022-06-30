# Domino

## Report

Este proyecto esta divido en dos secciones una Client, la cual es la encargada de la parte visual, y una Server, encargada de la logica del proyecto.

### Server

Dentro de Server el proyecto se divide en Controllers (encargado de controlar el ritmo de la partida), models(para la seleccion del modo de juego) y Data (la logica interna del proyecto).

**Data**

Data esta divida en Classes, Interfaces y SpecificGames (Implementaciones de cada interface, para modos de juego concreto)

**Abtracciones**

Interfaces:

- IBoard: Esta abtraccion viene generada por la necesidad de cambiar el tablero, dado que consideramos implementaciones donde se puede jugar por mas de un camino, como en el domino habitual (ejemplo la longana). Ademas ofrece funcionalidades utiles para el desarrollo del juego.

```csharp
    public List<Token> BuildTokens( int MaxIdOfToken, TokenValue CalculateValue );

    void PlaceToken( Token token, int IdPlayer );

    bool ValidPlay(Token token);

    public Token[,] TokensInBoard {
        get;
    }
    public Tuple<Token, int>[] OrderListOfTokensByPlayer {
        get;
    }
    public int MaxIdOfToken {
        get;
    } 
```

- IDistributeToken: Depende de como se quiera repartir las fichas a cada jugador. Solo debe devolver las fichas de cada jugador, la forma que las reparte es cosa del metodo elegido.

```Csharp
    Player[] DistributeTokens( List<Token> tokens, Player[] players, int countTokens );  
```

- IFinishGame: La condicion de finalizar el juego, la cual es una regla variable. Solo debe devolver si el juego se acabo.

```Csharp
    bool FinishGame( IBoard board, IEnumerable<Player> players );
```

- IWinGame: Debe devolver el orden en que acabo cada jugador, seleccionandolo segun su criterio de victoria.

```Csharp
    IEnumerable<Player> GetWinnersGame( IBoard board, IEnumerable<Player> players );
```

- INextPlayer: Debe devolver un entero que represente el siguiente jugador.

```Csharp
    int NextPlayer( Player[] players );
```

Clases:

- Manager: Encargado de llevar el flujo del juego, el cual sera invariante, ya que funciona para cualquier implementacion de las interfaces realizadas.

- Player: Clase abstracta la cual tiene una serie de metodos (virtual) y propiedades que seran comunes para varios tipos de jugadores, y otros (abstract) que seran especificos de cada uno.

- TokenValue: Una clase abstracta de cuya implementacion depende el valor de la ficha en dependencia de la regla seleccionada.
