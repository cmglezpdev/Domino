import { useEffect, useState } from 'react'
import { Grid } from 'semantic-ui-react'
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
      const width = ( height == 0 ) ? 0 : tokens[0].length;
      console.log(height,width);
      
      setGridSettings({
        width: width,
        height: height,
      });

      const board = BuildBoard(width, height, tokens);

      setBoard(board);
      
    }
  }, [currentPlay])
  
  const BuildBoard = ( width, height, tokens ) => {
     let board = [];
    
      for(let i = 0; i < height; i++) {
        for(let j = 0; j < width; j ++) {
          const token = tokens[i][j];
          if( token == null ) continue;
          
          const direction = getDirection(tokens, i, j);

          board.push(
              <Token
                left={token.left}
                right={token.right}
                key={ generateId() }
                id={ generateId() }
                direction={ direction }
                visible="true"
                positionGrid = {{
                  gridColumn: `${j+1}/${j+2}`,
                  gridRow: `${i+1}/${i+2}`,
                }}
              />);
        }
      }

      return board;
  }

  const getDirection = (tokens, i, j) => {
      const token = tokens[i][j];
      const height = tokens.length;
      const width = tokens[0].length;

      console.log(token);
      return token.direction;

      // let direction = (token.left == token.right) ? "vertical" : "horizontal";
            
      // if( ( i - 1 >= 0 && tokens[i - 1][j] != null) || (i + 1 < height && tokens[i + 1][j] != null) )
      //   direction  = ( token.left != token.right ) ? "vertical" : "horizontal";
      
      // if( (j - 1 >= 0 && tokens[i][j - 1] != null) || (j + 1 < width && tokens[i][j + 1] != null) )
      //   direction  = ( token.left != token.right ) ? "horizontal" : "vertical";

    // return direction;
  
  }


    return (
      <div className="container-game__board" >
        <div 
          style={{
            display: 'grid',
            gridTemplateColumns: `repeat(${gridSettings.width}, 100px)`,
            gridTemplateRows: `repeat(${gridSettings.height}, 100px)`,
            position: "absolute",
            inset: '0', 
            width: `calc(${gridSettings.width * 100}px)`,
            height: `calc(${gridSettings.height * 100}px)`,
            margin: 'auto',
          }}
          className="board__tokens"
        >
          {board}
        </div>
      </div>
    )
}
 