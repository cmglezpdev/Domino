using Server.Models;


public class InterfaceOfOptions {

    GeneralOptions options;

    public InterfaceOfOptions() {
        this.options = new GeneralOptions() {
            Options = new ChangeOptions[]{
                new ChangeOptions() {
                    titleOption = "Selecciona el tipo de Jugador",
                    id = "player",
                    nameOptions = new string[] {
                        "Aleatorio",
                        "Bota Gorda",
                        "Basado en heuristicas"
                    }, 
                    descriptions = new string[] {
                        "El jugador juega cualquier ficha aleatoria que sea valida",
                        "El jugador juega la ficha con mas valor que sea valida",
                        "Basado en algunas condiciones y situaciones en el juego, el jugador realiza algunas jugadas inteligentemente"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Selecciona el tipo de tablero",
                    id = "board",
                    nameOptions = new string[] {
                        "Colocar fichas por los extremos del tablero",
                        "Jugar hasta 4 fichas por los dobles"
                    },
                    descriptions = new string[] {
                        "Las fichas se coloca por los extremos del tablero",
                        "Las fichas se pueden colocar tanto por los extremos del tablero como por los dobles"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Valor de una ficha",
                    id = "tokenValue",
                    nameOptions = new string[] {
                        "Suma de sus caras",
                        "Valor absoluto de la resta de sus caras"
                    },
                    descriptions = new string[] {
                        "Suma de sus caras",
                        "Valor absoluto de la resta de sus caras"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Dos fichas se pueden jugar si?",
                    id = "matcher",
                    nameOptions = new string[] {
                        "Tienen una misma cara",
                        "Cumplen algunas propiedades matematicas"
                    },
                    descriptions = new string [] {
                        "Las fichas tiene al menos una cara en comun",
                        "El doble juega con cualquier ficha, una cara es sucesora de la otra, una cara con sus multiplos"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Cuando terminara el juego?",
                    id = "finishGame",
                    nameOptions = new string[] {
                        "Cuando nadie lleve fichas o se pegue",
                        "Si la mitad se pasa al menos dos veces"
                    },
                    descriptions = new string[] {
                        "Si alguien se pega o todos se pasan",
                        "Si alguien se pega o la mayoria se pasa dos veces",
                    }
                },
                new ChangeOptions() {
                    titleOption = "Quien gana el juego?",
                    id = "winGame",
                    nameOptions = new string[] {
                        "El que menos puntos tenga",
                        "El que mas puntos tenga"
                    },
                    descriptions = new string[] {
                        "Al contar los puntos de las fichas que el jugador no jugo, gana el que menos puntos tenga",
                        "Al contar los puntos de las fichas que el jugador no jugo, gana el que mas puntos tenga",
                    }
                },
                new ChangeOptions() {
                    titleOption = "Como se selecciona el proximo jugador?",
                    id = "nextPlayer",
                    nameOptions = new string[] {
                        "Orden consecutivo",
                        "Orden aleatorio",
                        "Orden consecutivo, y si alguien se pasa se invierte el orden",
                        "Jugar todas las fichas hasta que no lleves"
                    },
                    descriptions = new string[] {
                        "Orden consecutivo, 0, 1, ...., n",
                        "El orden no esta definido, siempre es uno aleatorio",
                        "Orden consecutivo, 0, 1, ...., n, y si alguien se pasa se invierte el orden",
                        "Cada jugador juega todas las fichas posibles hasta que no lleve mas"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Distribucion de las fichas",
                    id = "distributeTokens",
                    nameOptions = new string[] {
                        "Aleatorio",
                        "Cada uno recibe todas las fichas que se puedan del mismo numero"
                    },
                    descriptions = new string[] {
                        "Las fichas son distribuidas aleatoriamente a cada jugador",
                        "Cada jugador recibe todas las fichas del mismo tipo, y las que les falte se le asignan aleatoriamente"
                    }
                 }
            }
        };
    }


    public GeneralOptions GetGeneralOptions() {
        return this.options;
    }

}
