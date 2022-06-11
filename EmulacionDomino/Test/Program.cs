using Domino.Classes;
using Domino.Interfaces;

var board = new Board();
var distributeTokens = new RandomDistribution();
var finishGame = new Finish();
var WinGame = new WinGame();
var nextPlayer = new NextTurn();

RandomPlayer[] Players = new RandomPlayer[4];
for(int i = 0; i < 4; i ++) {
    Players[i] = new RandomPlayer();
    Players[i].IDPlayer = (i, "Juanitos");
}


var manager = new Manager(4, Players, board, distributeTokens, finishGame, WinGame, nextPlayer);

manager.StartGame(9);