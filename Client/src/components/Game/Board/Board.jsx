import React, { useEffect } from 'react'
import generateId from '../../../helpers/generateIds';
import { Token } from '../Token/Token';
import './board.scss';

export const Board = ({ currentPlay }) => {
  
//   useEffect(() => {
//     if( currentPlay?.tokensInBoard ) {
//         const tokens = currentPlay.tokensInBoard;
//         const width = tokens.length;
//         let height = 0;
        
//         // calcular el tamano de la matrix
//         for(let i = 0; i < tokens.width; i ++) {
//             if( tokens[i].length > 0 )  
//                 height = Math.max(height, tokens[i].length);
//         }
//         height = Math.max(1, height);

//         // Crear la matrix
//         let board = new Array(height);
        
//         tokens.forEach((token) => {
//             if( token.length > 0 ) {

//             } else {
//                 board.push(token);
//             }
//         })



//     }
//   }, [currentPlay])
  
  
    return (
    <div className="container-game__board">
    {/* {

    } */}
    
    {            
       currentPlay?.tokensInBoard.map((token, index) => {
         return (
           <Token 
             left={token.left} 
             right={token.right} 
             key={ generateId() } 
             id={index} 
             direction={"horizontal"}
             visible="true"
           />)
       }) 
     }
   </div> 


  )
}
