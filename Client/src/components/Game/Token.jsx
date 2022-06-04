import React from 'react'

import './token.scss';


export const Token = ({ left, right, id, isBorad }) => {
  return (
    <div className={`token--${ isBorad ? 'board' : 'hand' } token-${id}`}>
        <div className='left vertex'><span>{left}</span></div>
        <div className='right vertex'><span>{right}</span></div>
    </div>
  )
}
