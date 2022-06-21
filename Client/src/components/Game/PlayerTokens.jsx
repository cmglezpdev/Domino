import React from 'react'
import { Token } from './Token';
import generateId from '../../helpers/generateIds';

export const PlayerTokens = ({ currentPlay, handleNextTurn }) => {
  return (
    <>
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
    </>
  )
}
