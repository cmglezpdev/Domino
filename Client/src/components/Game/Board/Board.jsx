import React, { useEffect, useState } from 'react'
import generateId from '../../../helpers/generateIds';
import { Token } from '../Token/Token';
import './board.scss';

export const Board = ({ currentPlay }) => {

  const [gridSettings, setGridSettings] = useState({});
  const [board, setBoard] = useState([]);

  useEffect(() => {
    if( currentPlay?.tokensInBoard ) {
      const tokens = currentPlay?.tokensInBoard;
      
      // count of rows and columns
      const height = tokens.length;
      const width = (height > 0) ? tokens[0].length : 0;
      
      const standardHeight = 5;
      const board = BuildBoard(width, height, standardHeight, tokens);

      setBoard(board);
      
      setGridSettings({
          gridTemplateRows: `repeat(${Math.max(height, standardHeight)}, 100px)`,
          gridTemplateColumns: `repeat(${width}, 100px)`,
      });
    }
  }, [currentPlay])
  
  const BuildBoard = ( width, height, standardHeight, tokens ) => {
     let board = [];
    
      const voidCell = <div style={{
        backgroundColor: "green",
      }}>Vacio</div>;
      

      for(let i = 0; i < height; i ++) {
        let row = [];
        for(let j = 0; j < width; j ++) {

          if( tokens[i][j] == null ) {
            row.push(voidCell);
            continue;
          }

          // Decidir direccion del token
          let direction = "";
          if( tokens[i][j - 1] !== null || tokens[i][j + 1] !== null ) {
            if( tokens[i][j].left === tokens[i][j].right ) direction = "vertical";
            else direction = "horizontal";
          } else {
            direction = "horizontal";
          }
          console.log(generateId());
          row.push(<Token
            left={tokens[i][j].left}
            right={tokens[i][j].right}
            key={ generateId() }
            id={ generateId() }
            direction={ direction }
            visible="true"
            />);             
        }
        board.push(row);
      }

      if( height < standardHeight ) {
        let extra = (standardHeight - height) / 2;
        // Fill the front cell in board
        for(let i = 0; i < extra; i ++) {
          board.unshift(new Array(width).fill(voidCell));
        }

        for(let i = 0; i < extra; i ++) {
          board.push(new Array(width).fill(voidCell));
        }

      }

      return board;
  }

  
    return (
    <div className="container-game__board" >
      <div className='board__matrix' style={gridSettings}>
      
        {            
          board  
        }
      </div>
   </div> 


  )
}
