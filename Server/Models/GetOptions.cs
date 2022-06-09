using ServerApp.Models;


public class InterfaceOfOptions {

    GeneralOptions options;

    public InterfaceOfOptions() {
        this.options = new GeneralOptions() {
            CountOptions = 2,
            Options = new ChangeOptions[]{
                new ChangeOptions() {
                    titleOption = "Selecciona el tipo de Jugador",
                    id = "player",
                    nameOptions = new string[] {
                        "Aleatorio",
                        "Bota Gorda",
                        "Inteligente",
                        "Manual"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Cuando terminara el juego?",
                    id = "finishGame",
                    nameOptions = new string[] {
                        "Cuando nadie lleve fichas",
                        "Cuando alguien se pase por 3ra vez",
                        "En la ronda 5",
                    }
                },
                new ChangeOptions() {
                    titleOption = "Quien gana el juego?",
                    id = "winGame",
                    nameOptions = new string[] {
                        "El que menos puntos tenga",
                        "El que mas puntos tenga",
                        "En que menos fichas tenga",
                        "El que mas se ha pasado"
                    }
                },
                new ChangeOptions() {
                    titleOption = "Como se selecciona el proximo jugador?",
                    id = "nextPlayer",
                    nameOptions = new string[] {
                        "En orden, uno de tras del otro",
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
