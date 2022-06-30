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
                    }
                },
                new ChangeOptions() {
                    titleOption = "Selecciona el tipo de tablero",
                    id = "board",
                    nameOptions = new string[] {
                        "Clasico, colocar fichas solo a las esquinas",
                        "Para jugar la longana"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Valor de una ficha",
                    id = "tokenValue",
                    nameOptions = new string[] {
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
                    }
                },
                new ChangeOptions() {
                    titleOption = "Cuando terminara el juego?",
                    id = "finishGame",
                    nameOptions = new string[] {
                        "Cuando nadie lleve fichas o se pegue",
                        "Si la mitad se pasa al menos dos veces"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Quien gana el juego?",
                    id = "winGame",
                    nameOptions = new string[] {
                        "El que menos puntos tenga",
                        "El que mas puntos tenga"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Como se selecciona el proximo jugador?",
                    id = "nextPlayer",
                    nameOptions = new string[] {
                        "En orden, uno de tras del otro",
                        "Orden aleatorio",
                        "Orden consecutivo, y si alguien se pasa se invierte el orden",
                        "Jugar todas las fichas hasta que no lleves"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Distribucion de las fichas",
                    id = "distributeTokens",
                    nameOptions = new string[] {
                        "Aleatorio",
                        "Cada uno recibe todas las fichas que se puedan del mismo numero"
                    }
                }
            }
        };
    }


    public GeneralOptions GetGeneralOptions() {
        return this.options;
    }

}
