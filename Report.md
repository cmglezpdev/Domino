# Report

La aplicacion esta dividida en dos partes: El `Client`, que no es mas que una aplicacion de [React](https://es.reactjs.org/) para poder manejar la parte visual de nuestra aplicacion, y el `Server`, que no es mas que una API desarrollada en [C# .Net 6](https://dotnet.microsoft.com/en-us/) que contiene toda la logica y funcionalidad de la aplicacion.

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

...Escribir que es el manager y el Refery

### Abstracciones especificas

Dentro de los aspectos especificos variables del juego tenemos: 

- [Estrategia de un jugador](#estrategia-de-un-jugador)
    * [Random](#random-player)
    * [Bota Gorda](#bota-gorda-player)
    * [Heristic PLayer](#heuristic-player)
- [Distribucion de las fichas](#distribution-de-las-fichas-por-los-jugadores)
    * [Random](#random-distribution)
    * [AllEquivalsTokens](#todas-las-fichas-del-mismo-tipo)
- [Propiedades de la ficha](#distribution-de-las-fichas-por-los-jugadores)
    * [Random](#random-distribution)
    * [AllEquivalsTokens](#todas-las-fichas-del-mismo-tipo)
- [Valor de las fichas](#valor-de-las-fichas)
    * [Suma de sus caras](#suma-de-caras)
    * [Resta de sus caras](#resta-de-caras)
    * [Calculo Raro](#calculo-raro-y-aleatorio)

<!-- TODO: Seguir aqui con las demas cosas variables del juego -->



<!-- TODO: Escribir una breve descripcion de lo que hace cada clase -->
<!-- TODO: Crear un link por cada variacion para poder volver al menu -->
### Estrategia de un jugador

#### Random Player
#### Bota Gorda Player
#### Heuristic Player




### Distribution de las fichas por los jugadores

#### Random Distribution
#### Todas las fichas del mismo tipo




### Valor de las fichas
#### Suma de caras
#### Resta de caras
#### Calculo raro y aleatorio