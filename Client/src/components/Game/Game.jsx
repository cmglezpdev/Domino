import React, { useEffect, useState, useContext } from 'react';
import { Token } from './Token';
import { BASE_URL } from '../../helpers/api.js';
import generateId from '../../helpers/generateIds';
import { SettingsContext } from '../../helpers/SettingsContext';

import './game.scss';
import { PlayerTokens } from './PlayerTokens';
import { MessageGame } from './MessageGame';
import { Board } from './Board';

export const Game = () => {
  
  const { settings, setSettings } = useContext(SettingsContext);
  const [currentPlay, setCurrentPlay] = useState(undefined);

  useEffect(() => {
    console.log(settings); 
    fetch(`${BASE_URL}/TypeGame`, {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json'
      },
      body: JSON.stringify( settings )
    }).then(result => result.json())
      .then( data => {
        setCurrentPlay({
          players: data,
          currentPlayer: 0,
          passed: false,
          tokensInBoard: [],
          finishGame: false,
          winners: []
      });
      })
  }, [] );

         
  const handleNextTurn = (e) => {
    const btnText = e.target.innerText;
    if( btnText === 'New Game'.toUpperCase() ) {
      setSettings({
        done: false
      });
      return;
    }

    fetch( `${BASE_URL}/NextTurn` )
      .then(result => result.json())
      .then(play => {
        setCurrentPlay(play);
      })
  }




  return (

    <div className='container-game'>
      {/* Muestra las fuchas del tablero */}
      <Board currentPlay={currentPlay}/>

      {/* Mensaje que se muestra cuando alguien se pasa o termina el juego */}
     <MessageGame currentPlay={currentPlay}/>
      

        {/* Muestra al jugador actual y a la lista de fichas del jugador */}
      <PlayerTokens currentPlay={currentPlay} handleNextTurn={handleNextTurn}/>

    </div>
  )
}