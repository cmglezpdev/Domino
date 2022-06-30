import React from 'react'
import DotContainer from '../dotContainer/dotContainer';
import './token.scss';


export const Token = ({ left, right, id, direction, visible, positionGrid}) => {
  return (
    <div 
      className='token'
      style={positionGrid} 
      direction={direction} 
      visible={visible}
    >
      <DotContainer dotsNumber={left}/>
      <div className='divisor'></div>
      <DotContainer dotsNumber={right}/>
    </div>
  )
}
