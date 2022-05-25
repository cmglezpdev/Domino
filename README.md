# Domino

Proyecto de Programaciom II


## Dependencias

**Instalar Node, Yarn y .NET 6.0**

Para instalar node visitar su [pagina oficial](https://nodejs.org/).

Para instalar .NET 6.0 visitar su [pagina oficial](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

Para instalar yarn:

```bash
#Instalar yarn
npm install -g yarn
```

**Dependencias del proyecto**

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
