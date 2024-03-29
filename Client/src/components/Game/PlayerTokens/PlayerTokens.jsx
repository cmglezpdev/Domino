import React from 'react'
import { Token } from '../Token/Token';

import generateId from '../../../helpers/generateIds';
import './playerTokens.scss';

import { iconsPlayers, namesPlayers } from '../../../helpers/dataPlayers';

// Renderiza la información del jugador
export const PlayerTokens = ({ currentPlay, handleNextTurn, handleResetGame }) => {


return (
    <>
        <div className="container-info-player">
        
            <div className='player-info'>
                <div className='player__data'>
                    <img src={iconsPlayers[currentPlay?.currentPlayer]} alt="player" />
                    <span>
                        {`${ namesPlayers[currentPlay?.currentPlayer] }: ${currentPlay?.points || 0}`}
                    </span>
                </div>
            </div>

            <div className='list-tokens'>
                {            
                    currentPlay?.players[ currentPlay?.currentPlayer ]?.handTokens?.map((token, index) => {
                    return (
                        <Token 
                            left={token.left}
                            right={token.right}
                            key={ generateId() }
                            id={index}
                            direction={"vertical"}
                            visible={"true"}
                        />)
                    }) 
                }
            </div>

            <div className="buttons">
                <button 
                        className='next-turn'
                        onClick={handleNextTurn}  
                    >
                        { ( currentPlay?.finishGame ) ? 'New Game' : 'Next Turn'}
                    </button>
                    <button
                        className='next-turn'
                        onClick={handleResetGame}
                    >
                        Reset Game
                </button>
            </div>

        </div>

    </>
  )
}
