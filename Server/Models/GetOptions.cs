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
                    }
                },
                new ChangeOptions() {
                    titleOption = "Selecciona el tipo de tablero",
                    id = "board",
                    nameOptions = new string[] {
                        "Clasico, colocar fichas solo a las esquinas",
                    }
                },
                new ChangeOptions() {
                    titleOption = "Cuando terminara el juego?",
                    id = "finishGame",
                    nameOptions = new string[] {
                        "Cuando nadie lleve fichas o se pegue",
                        "Cuando alguien se pase por primera vez"
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
                        "Orden consecutivo, y si alguien se pasa se invierte el orden"
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
