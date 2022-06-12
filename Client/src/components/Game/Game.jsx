import React, { useEffect, useState } from 'react';
import { Token } from './Token';
import { BASE_URL } from '../../helpers/api.js';
import generateId from '../../helpers/generateIds';

import './game.scss';

export const Game = ({ settings }) => {

  const [currentPlay, setCurrentPlay] = useState(undefined);
  // const { Players, CurrentPlayer, Passed, TokensInBoard, FinishGame, Winners } = currentPlay; 

  useEffect(() => {
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
    fetch( `${BASE_URL}/NextTurn` )
      .then(result => result.json())
      .then(play => {
        console.warn(play);
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

      <div className='player'>
        <div className='player__name'>{`Jugador # ${ currentPlay?.currentPlayer }`}</div>
        <button 
          className='next-turn'
          onClick={handleNextTurn}  
        >
            { ( currentPlay?.finishGame ) ? 'New Game' : 'Next Turn'}
        </button>
      </div>

      <div className='list-tokens'>
        <div className='list-tokens__group'>
          {            
            currentPlay?.players[ currentPlay?.currentPlayer ]?.handTokens?.map((token, index) => {
              return (<Token left={token.left} right={token.right} key={ generateId() } id={index}/>)
            }) 
          }
        </div>
      </div>
    </div>
  )
}