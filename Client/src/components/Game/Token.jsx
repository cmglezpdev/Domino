import React from 'react'

import './token.scss';


export const Token = ({ left, right }) => {
  return (
    <div className='token'>
        <div className='token--left vertex'><span>{left}</span></div>
        <div className='token--right vertex'><span>{right}</span></div>
    </div>
  )
}
