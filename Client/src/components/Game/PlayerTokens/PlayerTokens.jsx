import React from 'react'
import { Token } from '../Token/Token';

import generateId from '../../../helpers/generateIds';
import './playerTokens.scss';

import { iconsPlayers, namesPlayers } from '../../../helpers/dataPlayers';


export const PlayerTokens = ({ currentPlay, handleNextTurn }) => {


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
                <button 
                    className='next-turn'
                    onClick={handleNextTurn}  
                >
                    { ( currentPlay?.finishGame ) ? 'New Game' : 'Next Turn'}
                </button>
                <button
                    className='next-turn'
                >
                    Reset Game
                </button>
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
        </div>

    </>
  )
}
