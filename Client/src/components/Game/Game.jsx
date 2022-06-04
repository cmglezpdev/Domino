import React from 'react'
import { Token } from './Token'

import './game.scss';


export const Game = ({ settings }) => {
  return (
    <div className='container-game'>

      <div className="container-game__board">
          <Token left={6} right={3} key={2} id={2} isBorad={true}/>
          {/* <Token left={3} right={5} key={3} id={3} isBorad={true}/> */}
      </div>      

      <div className='list-tokens'>
        <div className='list-tokens__group'>
        <Token left={5} right={4} key={1} id={1} />
        <Token left={6} right={3} key={2} id={2} />
        <Token left={3} right={5} key={3} id={3} />
        <Token left={7} right={7} key={4} id={4} />
        <Token left={1} right={0} key={5} id={5} />
        </div>
      </div>
      {/* <pre>
        {
          JSON.stringify( settings, null , 3 )
        }
      </pre> */}
    </div>
  )
}
