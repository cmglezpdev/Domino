import React, { useEffect, useState } from 'react'
import generateId from '../../../helpers/generateIds';
import { Token } from '../Token/Token';
import './board.scss';

export const Board = ({ currentPlay }) => {

  const [gridSettings, setGridSettings] = useState({});

  useEffect(() => {
    if( currentPlay?.tokensInBoard ) {
      const tokens = currentPlay?.tokensInBoard;
      console.log(tokens);
      // count of rows and columns
      const height = tokens.length;
      const width = (height > 0) ? tokens[0].length : 0;
      console.log(height, width);

      setGridSettings({
          gridTemplateRows: `repeat(${height}, 100px)`,
          gridTemplateColumns: `repeat(${width}, 100px)`
      });

    }
  }, [currentPlay])
  
  
    return (
    <div className="container-game__board" style={gridSettings}>
 
    {            
      currentPlay?.tokensInBoard.map((level) => {
        const row = level.map((token, index) => {
          return (
            <Token 
              left={token.left} 
              right={token.right} 
              key={ generateId() } 
              id={index} 
              direction={( token.left !== token.right ) ? "horizontal" : "vertical"}
              visible="true"
            />)
          }) 
          return row;
      })
     }
   </div> 


  )
}
