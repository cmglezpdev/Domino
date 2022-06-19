import React, { useEffect, useState, useContext } from 'react';
import { Token } from './Token';
import { BASE_URL } from '../../helpers/api.js';
import generateId from '../../helpers/generateIds';
import { SettingsContext } from '../../helpers/SettingsContext';

import './game.scss';
import { PlayerTokens } from './PlayerTokens';

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
  }, []);

         
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
      <div className="container-game__board">
       {            
          currentPlay?.tokensInBoard.map((token, index) => {
            return (<Token left={token.left} right={token.right} key={ generateId() } id={index} isBorad={true}/>)
          }) 
        }
      </div> 



      {
        currentPlay?.finishGame && (<div className='alert-player-game finished'>
          <span className='alert'>El juego ha terminado...</span>
          <span className='alert'>Lista de Ganadores:</span>
          {
            currentPlay?.winners.map((player) => {
              return (<span className='player'>{ `Jugador #${player.id}: ${player.points} puntos.` }</span>)
            })
          }
        </div>)
      }
      {
        currentPlay?.passed && (<div className='alert-player-game passed'>
          <span>El jugador # { currentPlay?.currentPlayer } se paso!</span>
        </div>)
      }


      <PlayerTokens currentPlay={currentPlay} handleNextTurn={handleNextTurn}/>

    </div>
  )
}