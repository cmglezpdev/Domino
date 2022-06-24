import React from 'react'

import { namesPlayers } from '../../../helpers/dataPlayers';
import './messageGame.scss'

export const MessageGame = ({ currentPlay }) => {
  return (
    <>
        {
          currentPlay?.finishGame &&  (<div className='alert-player-game finished'>
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
            <span>{  namesPlayers[ currentPlay?.currentPlayer ] } se ha pasado!</span>
            </div>)
        }
    </>
  );
}
