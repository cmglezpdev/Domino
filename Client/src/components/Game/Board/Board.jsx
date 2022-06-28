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
      const width = (height > 0) ? tokens[0].length : 0;
      
      const standardHeight = 5;
      const board = BuildBoard(width, height, standardHeight, tokens);

      setBoard(board);
      
      setGridSettings({
          width: width,
          height: height,
          // gridTemplateRows: `repeat(${Math.max(height, standardHeight)}, 100px)`,
          // gridTemplateColumns: `repeat(${width}, 100px)`,
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
            direction = "vertical";
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
        <Grid rows={gridSettings.width} relaxed stackable={false}>
          {
            board.map((row, i) => {
              return (
                <Grid.Row key={i}>
                  {
                    row.map((cell, j) => {
                      return (
                        <Grid.Column 
                          key={j}
                          style={{
                            width: "100px",
                            height: "100px",
                          }}
                          >
                          {cell}
                        </Grid.Column>
                      )
                    }
                    )
                  }
                </Grid.Row>
              )
            })
          }
        </Grid>
    </div> 
  )
}
