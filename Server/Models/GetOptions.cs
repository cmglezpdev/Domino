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
                    }
                },
                new ChangeOptions() {
                    titleOption = "Quien gana el juego?",
                    id = "winGame",
                    nameOptions = new string[] {
                        "El que menos puntos tenga",
                    }
                },
                new ChangeOptions() {
                    titleOption = "Como se selecciona el proximo jugador?",
                    id = "nextPlayer",
                    nameOptions = new string[] {
                        "En orden, uno de tras del otro",
                    }
                },
                new ChangeOptions() {
                    titleOption = "Distribucion de las fichas",
                    id = "distributeTokens",
                    nameOptions = new string[] {
                        "Aleatorio",
                    }
                }
            }
        };
    }


    public GeneralOptions GetGeneralOptions() {
        return this.options;
    }

}
