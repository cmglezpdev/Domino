import React from 'react'

import { namesPlayers } from '../../../helpers/dataPlayers';
import generateId from '../../../helpers/generateIds';
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
                    return (<span className='player' key={generateId()}>{ `${ namesPlayers[player.id] }: ${player.points} puntos.` }</span>)
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
