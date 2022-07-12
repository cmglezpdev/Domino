# Report

La aplicacion esta dividida en dos partes: El `Client`, que no es mas que una aplicacion de [React](https://es.reactjs.org/) para poder manejar la parte visual de nuestra aplicacion, y el `Server`, que no es mas que una API desarrollada en [C# .Net 6](https://dotnet.microsoft.com/en-us/) que contiene toda la logica y funcionalidad de la aplicacion.

- [Report](#report)
  - [Client](#client)
  - [Server](#server)
    - [Controllers y Models](#controllers-y-models)
    - [Data](#data)
    - [Vista general de la Abstracciones](#vista-general-de-la-abstracciones)
    - [Abstracciones especificas](#abstracciones-especificas)
    - [Tablero](#tablero)
      - [Tablero clasico](#tablero-clasico)
      - [Tablero con mas caminos](#tablero-con-mas-caminos)
    - [Estrategia de un jugador](#estrategia-de-un-jugador)
      - [Random Player](#random-player)
      - [Bota Gorda Player](#bota-gorda-player)
      - [Heuristic Player](#heuristic-player)
    - [Distribution de las fichas por los jugadores](#distribution-de-las-fichas-por-los-jugadores)
      - [Random Distribution](#random-distribution)
      - [Todas las fichas del mismo tipo](#todas-las-fichas-del-mismo-tipo)
    - [Valor de las fichas](#valor-de-las-fichas)
      - [Suma de caras](#suma-de-caras)
      - [Resta de caras](#resta-de-caras)
      - [Calculo raro y aleatorio](#calculo-raro-y-aleatorio)
    - [Final de la partida](#final-de-la-partida)
      - [No se puede seguir jugando](#no-se-puede-seguir-jugando)
      - [Todos se pasan](#todos-se-pasan)
    - [Siguiente Jugador](#siguiente-jugador)
      - [Orden del domino clasico](#orden-del-domino-clasico)
      - [Orden aleatorio](#orden-aleatorio)
      - [Invirtiendo el orden](#invirtiendo-el-orden)
      - [Todas las fichas](#todas-las-fichas)
    - [Ganador](#ganador)
      - [Mas puntos](#mas-puntos)
      - [Menos puntos](#menos-puntos)
    - [Conexion de Fichas](#conexion-de-fichas)
      - [Caras iguales](#caras-iguales)
      - [Conexiones raras](#conexiones-raras)
  
## Client

## Server

En el `Server` tenemos los controladores de la API(`Controllers`), los modelos(`Models`) que son clases bases para el envio y recivimiento de los request del Cliente, y la parte de `Data` que contriene toda la logica de la aplicacion.

### Controllers y Models

**LoaderController**: Este controlador carga la clase `InterfaceOfOptions` que esta dentro de los `Models` que tiene un conjunto de informaciones relacionadas con las diferentes variaciones ya desarrolladas del juego.

**TypeGameController**: Una vez que el usuario en la interfaz grafica termina de seleccionar los diferentes aspectos para generar una variacion del juego, esta informacion es mandada al `server` y este `controller` lo que hace es inicializar las clases generales y construir nuestro `Manager`(Clase que controla el flujo del juego) con las respectivas variaciones que el usuario selecciono.

**NextTurnController**: Este `controller` se ejecuta cada vez que en el juego corresponde a un nuevo turno, en donde este se encarga de ejecutar los metodos necesarios del `Manager` para realizar la proxima jugada, y devuelve la informacion correspondiente de esa jugada que se realizo.

### Data

La seccion de la `Data` tiene una clase principal `Data` que tiene varios arrays de instancias de las variaciones que tenemos implementadas en el juego, asi como varios metodos que 'parsean' algunas informaciones del juego en una estructura especifica para que sea mas facil usar esa informacion en el `Client`(usando JSON);

Ademas de esto tenemos una estructura de directorios formada por:
`Classes`: Contiene las clases generales del juego o que no necesitan de una interfaz.
`Interfaces`: Representa una parte de la abstraccion del juego, en donde cada interfaz representa una posible variacion de una caracteristica del juego, las cueales son las seleccionadas desde el `Client`.
`SpecificGames`: Esta tiene mas directorios dentro con las implementaciones de las variaciones respectivas de todas las funcionalidades del juego que son variables.

### Vista general de la Abstracciones

Dentro de la seccion `Classes` las principales clases son: `Manager`, el cual es el encargado de controlar el flujo de la partida, y posee todas las caracteristicas(reglas) seleccionadas por el usuario en la partida. La otra clase importante es `Refery` la cual tiene la tarea de controlar las jugadas de cada jugador(esta clase la implementamos como forma de evitar el surgimiento de jugadores que incumplieran las reglas preestablecidas de la partida), ademas posee las fichas de todos los  jugadores y les ordena a los mismos elegir que ficha jugar, revisando si la elegida es valida, y finalmente colocandola en el tablero.

### Abstracciones especificas

Dentro de los aspectos especificos variables del juego tenemos:

### Tablero

#### Tablero clasico

#### Tablero con mas caminos

<hr />

### Estrategia de un jugador

Abstraido en una clase abtracta `Player` que posee un metodo abtracto `PlayToken`(en teoria deberia devolver la posicion en el array que se le pasa de la ficha que desee jugar, si imcumple este principio devolviendo un numero de una posicion invalida en la partida, se considera un turno perdido).

~~~C#
public abstract int PlayToken( IBoard board, Token[] hand);
~~~

#### Random Player

Selecciona una ficha al azar auxiliandose del tipo `Random`.

#### Bota Gorda Player

Selecciona entre todas sus fichas la de mas valor, si es valida la juega, sino busca la siguiente de mas valor, siempre basandose en la implementacion de valor seleccionada en la partida.

#### Heuristic Player

Jugador basado en unas heuristas simples, siempre intenta salir con un doble, y jugar la ficha cuyas caras esten mas repetidas en su mano.

[Indice](#report)

<hr />

### Distribution de las fichas por los jugadores

Abstraido en una interface `IDistributeTokens` con un metedo `DistributeTokens` el cual debe ser implementado devolviendo la distribucion de las fichas para la partida que el implementador desee.

~~~C#
List<Token>[] DistributeTokens(List<Token> tokens,int numberofplayers,int countTokens);   
~~~

#### Random Distribution

Reparte las fichas de forma aleatoria auxiliandose del tipo `Random`

#### Todas las fichas del mismo tipo

Reparte las fichas siguiendo la primicia de dar tantas fichas con igual representacion en una de sus caras como se pueda, cuando no se puedan dar mas se completan aleatoriamente.

[Indice](#report)

<hr />

### Valor de las fichas

Abstraido en una Interface `ITokenValue` con un metodo `Value` que recibe un `Token` y debe devolver un entero que represente el valor de esa ficha en la implementacion concreta.

#### Suma de caras

El valor de las fichas clasico del domino, la suma de ambas caras.

#### Resta de caras

El valor viene dado por la diferencia de las caras de la ficha.

#### Calculo raro y aleatorio

Auxiliandonos del tipo `Func` y `Random` creamos varias formas de calcular el valor de la ficha y aleatoriamente aplicamos una en la ficha dada.

[Indice](#report)

<hr />

### Final de la partida

Abstraido en una interface `IFinishGame` con un metodo booleano `FinishGame` que recibiendo el estado del tablero y la informacion de cada jugador debe decidr si eljuego termino.

~~~C#
bool FinishGame( IBoard board, IEnumerable<PlayerInfo> players );
~~~

#### No se puede seguir jugando

Regla del domino clasico si alguien puso todas sus fichas o nadie tiene una ficha valida para jugar

#### Todos se pasan

Al igual que en el domino clasico si alguien se queda sin fichas, o si todos se pasan una x cantidad de veces.

[Indice](#report)

<hr />

### Siguiente Jugador

Abstraido en una interface `INextPlayer` esta interface debe ser implementada de forma tal que devuelva el indice del jugador que le toca jugar.

~~~C#
int NextPlayer( PlayerInfo[] players );
~~~

#### Orden del domino clasico

El orden clasico, fijo donde se preestablece un orden al iniciar la partida y ese se mantiene hasta el final de la partida.

#### Orden aleatorio

El siguiente jugador es seleccionado de forma aleatoria.

#### Invirtiendo el orden

El juego comienza con un orden establecido, pero si alguien se pasa este orden es invertido.

#### Todas las fichas

El mismo jugador repite su turno hasta que no le queden jugadas validas por jugar.

[Indice](#report)

<hr />

### Ganador

Abstraido en una inteface `IWinGame` el cual debe devolver un `IEnumerable` con el orden en que quedan los jugadores al finalizar la partida.

~~~C#
IEnumerable<PlayerInfo> GetWinnersGame( IBoard board, IEnumerable<PlayerInfo> players );
~~~

#### Mas puntos

Gana el jugador con mayor valor en sus fichas.

#### Menos puntos

Regla del domino clasica donde gana el jugador cuyas fichas tengan un valor menor.

[Indice](#report)

<hr />

### Conexion de Fichas

Abstraido en una interface `IMatch` cuya implementacion debe devolver si dos fichas se pueden conectar(es decir si se puede jugar cierta ficha X, donde ya halla otra ficha Y)

#### Caras iguales

Implementacion del domino clasica donde dos fichas coinciden si alguna de sus caras son iguales.

#### Conexiones raras

La fichas se pueden jugar siguiendo ciertas reglas, como por ejemplo si alguna cara de la ficha X es sucesora de alguna de la ficha Y, o si alguna cara es 0, siempre combina con cualquier cara.

[Indice](#report)

<hr />

<!-- TODO: Seguir aqui con las demas cosas variables del juego -->

<!-- TODO: Escribir una breve descripcion de lo que hace cada clase -->
<!-- TODO: Crear un link por cada variacion para poder volver al menu -->