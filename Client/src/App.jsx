import React, { useState, useEffect } from "react";
import { Options } from "./components/Forms/Options";
import { Game } from "./components/Game/Game";

function App() {
  
  const [typeGame, setTypeGame] = useState({
      // Indices en el array de cada tipo de juego
      token: 0,
      player: 0, 
      buildTokens: 0,
      winGame: 0,
      finishGame: 0,
      nextPlayer: 0,
      distributeTokens: 0,
      done: false
  });



  
  return (

    <>
      {  
        !typeGame.done ? ( <Options typeGame={typeGame} setTypeGame={setTypeGame}/> ) : ( <Game /> )  
      }
    </>

  );
}

export default App;
