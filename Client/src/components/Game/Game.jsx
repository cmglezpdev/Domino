import React, { useEffect, useState } from 'react';
import { Token } from './Token';
import { BASE_URL } from '../../helpers/api.js';

import './game.scss';


export const Game = ({ settings }) => {

  const [players, setPlayers] = useState([]);
  const [currentPlay, setCurrentPlay] = useState({
                            CurrentPlayer: 0,
                            Passed: false,
                            TokensInBoard: [],
                            FinishGame: false,
                            Winners: []
                        });
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
        setPlayers(data);
      })
  }, []);

         
  const handleNextTurn = (e) => {
    // fetch( `${BASE_URL}/NextTurn` )
    //   .then(result => result.json())
    //   .then(play => {
    //     console.log(play);
    //   })
  }

  return (
    <div className='container-game'>
      <div className="container-game__board">
          <Token left={6} right={3} key={2} id={2} isBorad={true}/>
      </div>      

      <div className='player'>
        <div className='player__name'>{`Jugador #${1}`}</div>
        <button 
          className='next-turn'
          onClick={handleNextTurn}  
        >
            Next Turn
        </button>
      </div>

      <div className='list-tokens'>
        <div className='list-tokens__group'>
          {            
            players[ currentPlay?.CurrentPlayer ]?.handTokens?.map((token, index) => {
              return (<Token left={token.left} right={token.right} key={index} id={index}/>)
            }) 
          }
        </div>
      </div>
    </div>
  )
}