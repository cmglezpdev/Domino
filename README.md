# Domino

Proyecto de Programacion II

![Domino](./assets/screenshot.png)


[Orientacion del proyecto](https://github.com/matcom/domino)

[Lista de tareas](https://github.com/cmglezpdev/Domino/projects/1)

Esta aplicación es una simulación de un jugador de domino, en donde usted podra jugar diferentes variantes del juego de domino clásico, cambiando las reglas de juego a su gusto.

La aplicación está compuesta por una aplicación de cliente desarrollada en [React](https://es.reactjs.org/) y una aplicación de servidor con una API y toda la lógica del juego desarrollado en [C# .net6](https://docs.microsoft.com/en-us/dotnet/).


## Dependencias e instalación local

**Instalar Node, Yarn y .NET 6.0**

Para instalar .NET 6.0 visitar su [pagina oficial](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

Para instalar node.

```bash
curl -fsSL https://deb.nodesource.com/setup_18.x | sudo -E bash -
sudo apt-get install -y nodejs
```



Para instalar yarn:

```bash
#Instalar yarn
npm install -g yarn
```

**Dependencias del proyecto**

Entre las dependencias internas para la aplicación del lado del cliente, ademas de usar react tambien se usaron otras librerías:

1. [Electron](https://www.electronjs.org/)
2. [Semantic UI React](https://react.semantic-ui.com/)
3. [Sass](https://sass-lang.com/documentation)
4. [React Toastify](https://fkhadra.github.io/react-toastify/introduction)

Para instalar las dependencias de node se va a la carpeta `Client` y se ejecuta el comando:

```bash
#Instalar dependencias
yarn install
```

## Ejecucion de la aplicacion

En la carpeta `Server` ejecutamos el comando siguiente para levantar el servidor:

```bash
#Ejecutar servidor
dotnet run
```

Luego en la carpeta de Client podemos ejecutar la aplicacion como una aplicacion de escritorio o como una pagina web

``` bash
#Ejecutar como aplicacion de escritorio
yarn electron-dev

#Ejecutar como aplicacion web
yarn start
```

**Nota:** La aplicacion de escritorio actualmente tiene un pequeño error, por lo que recomiendo ejecutarlo como aplicacion web.


### Posible error al ejecutar la aplicacion

Si al ejecutar la aplicacion no te carga las opciones para seleccionar el tipo de juego es porque tu navegador esta bloqueando el acceso de la api a la url de la misma. Para eliminar este error, nos vamos a las herramientas de desarrollo del navegador( click derecho en cualquier lugar y despues en inspeccionar ).

Luego vas a la pestaña de `Network` y veras un listado con la palabra `loader` en rojo. Esta es la primera peticion que hace la app al server y es rechazada

![](./assets/error-1.png)

Si das doble click ahi aparecera al lado la informacion de la peticion y el link al cual se hizo. Le damos doble click al link y nos abrira una ventana con la cual estara bloqueada por el navegador.

Lo unico que tenemos que hacer es darle click a `Mostrar configuracion avanzada` y despues a `Acceder a localhost(sitio no seguro)`. Esto eliminara la restriccion y podras acceder sin problema a la informacion devuelta por la api.

![error](./assets/error-2.png)

Ya solo queda recargar la paguina del juego y ver que salgan las opciones.

## Anadir nueva variacion de una caracteristicas

Si tienes una nueva implementacion diferente de una de las caracteristicas que se pueden variar del juego sigues estos pasos:

**1. Crear la clase** 

En la carpeta `Data/SpecificGames` buscas la parte del juego que quieres crear nueva y creas una clase en un fichero.cs nuevo que herede la interfas corresponiente e implementas la variacion. Es recomendable que el nombre de la clase decriba o identifique el tipo de variacion correspondiente para poder diferenciarla con las demas implementaciones. 

**2. Anadir los datos**

En la carpeta `Data` modificas la clase `Data` y anades una nueva instancia al arreglo del tipo de variacion creada

**3. Anadir descripcion**

En la carpeta `Models` se modifica el fichero `GetOptions.cs` y se andade en el grupo de opciones correspondiente, en el array de `nameOptions` de ese grupo una descripcion identificadora de la implementacion desarrollada.

**Importante:** Es importante que las descripciones de las variaciones tengan el mismo orden que las instancias de las clases que identifican cada una de las descripciones anadidas, ya que estos se seleccionaran dinamicamente por el indice que ocupen en el array. Si no tiene un orden correcto, este puede traer errores en la ejecucion del juego.
