# Domino

Proyecto de Programacion II

[Orientacion del proyecto](https://github.com/matcom/domino)

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
