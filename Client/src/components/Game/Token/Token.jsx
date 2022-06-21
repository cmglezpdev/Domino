import React from 'react'
import DotContainer from '../dotContainer/dotContainer';
import './token.scss';


export const Token = ({ left, right, id, direction, visible}) => {
  return (
    <div className='token' direction={direction} visible={visible}>
      <DotContainer dotsNumber={left}/>
      <div className='divisor'></div>
      <DotContainer dotsNumber={right}/>
    </div>
  )
}
