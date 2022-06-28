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
      console.log(height, width);
      
      const standardHeight = 5;
      let auxBoard = new Array( Math.max(standardHeight, height) );
      
      let h = 0;
      if( height < standardHeight ) {
        let dif = (standardHeight - height) / 2;
        
        for(h = 0; h < dif; h ++) {
          auxBoard[h] = new Array(width);
          for(let j = 0; j < width; j ++) {
            auxBoard[h][j] = <div>Vacio</div>;
          }
        }
      }


      for(let i = 0; i < height; i ++, h ++) {
        auxBoard[h] = new Array(width);
      
        for(let j = 0; j < width; j ++) {  
          if( tokens[i][j] !== null ) {

              let direction = "";
              if( tokens[i][j - 1] !== null || tokens[i][j + 1] !== null ) {
                if( tokens[i][j].left === tokens[i][j].right ) direction = "vertical";
                else direction = "horizontal";
              } else {
                direction = "horizontal";
              }

            auxBoard[h][j] = <Token 
                left={tokens[i][j].left} 
                right={tokens[i][j].right} 
                key={ generateId() } 
                id={ generateId() } 
                direction={ direction }
                visible="true"
                style={{
                  marginLeft: `${j === 0 ? "20px" : "0"}`
                }}
              />
          } else {
            auxBoard[h][j] = <div style={{
              marginLeft: `${j === 0 ? "200px" : "0"}`
            }}>Vacio</div>
          }
        }
      }
      
      for( ; h < Math.max(standardHeight, height); h ++) {
        auxBoard[h] = new Array(width);
        for(let j = 0; j < width; j ++) {
          auxBoard[h][j] = <div>Vacio</div>;
        }
      }

      setBoard(auxBoard);
      
      setGridSettings({
          gridTemplateRows: `repeat(${Math.max(height, standardHeight)}, 100px)`,
          gridTemplateColumns: `repeat(${width}, 100px)`,
      });
    }
  }, [currentPlay])
  
  
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
