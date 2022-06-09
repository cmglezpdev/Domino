import React, { useState } from 'react'
import { Token } from './Token'

import './game.scss';


export const Game = ({ settings }) => {

    // const [board, setBoard] = useState([]);

    // // Para representar algun dato de prueba
    // setBoard([
    //   <Token left={6} right={3} key={2} id={2} isBorad={true}/>,
    //   <Token left={3} right={5} key={3} id={3} isBorad={true}/>,
    //   <Token left={4} right={1} key={4} id={4} isBorad={true}/>,
    //   <Token left={6} right={4} key={5} id={5} isBorad={true}/>,
    //   <Token left={9} right={7} key={6} id={6} isBorad={true}/>,
    //   <Token left={0} right={8} key={7} id={7} isBorad={true}/>,
    //   <Token left={2} right={6} key={8} id={8} isBorad={true}/>,
    //   <Token left={1} right={3} key={9} id={9} isBorad={true}/>,
    //   <Token left={1} right={3} key={10} id={10} isBorad={true}/>,
    //   <Token left={1} right={3} key={11} id={11} isBorad={true}/>,
    //   <Token left={1} right={3} key={12} id={12} isBorad={true}/>
    // ])

  return (
    <div className='container-game'>

      <div className="container-game__board">

          <div className="board-row row-1"></div>
          <div className="board-row row-2"></div>
          <div className="board-row row-3"></div>
          <div className="board-row row-4"></div>
          <div className="board-row row-5"></div>
          <div className="board-row row-6"></div>
          <div className="board-row row-7"></div>

          <Token left={6} right={3} key={2} id={2} isBorad={true}/>
          <Token left={3} right={5} key={3} id={3} isBorad={true}/>
          <Token left={4} right={1} key={4} id={4} isBorad={true}/>
          <Token left={6} right={4} key={5} id={5} isBorad={true}/>
          <Token left={9} right={7} key={6} id={6} isBorad={true}/>
          <Token left={0} right={8} key={7} id={7} isBorad={true}/>
          <Token left={2} right={6} key={8} id={8} isBorad={true}/>
          <Token left={1} right={3} key={9} id={9} isBorad={true}/>
          <Token left={1} right={3} key={10} id={10} isBorad={true}/>
          <Token left={1} right={3} key={11} id={11} isBorad={true}/>

          <Token left={6} right={3} key={12} id={2} isBorad={true}/>
          <Token left={3} right={5} key={13} id={3} isBorad={true}/>
          <Token left={4} right={1} key={14} id={4} isBorad={true}/>
          <Token left={6} right={4} key={15} id={5} isBorad={true}/>
          <Token left={9} right={7} key={16} id={6} isBorad={true}/>
          <Token left={0} right={8} key={17} id={7} isBorad={true}/>
          <Token left={2} right={6} key={18} id={8} isBorad={true}/>
          <Token left={1} right={3} key={19} id={9} isBorad={true}/>
          <Token left={1} right={3} key={20} id={10} isBorad={true}/>
          <Token left={1} right={3} key={21} id={11} isBorad={true}/>
          <Token left={1} right={3} key={22} id={12} isBorad={true}/>

          <Token left={3} right={5} key={23} id={3} isBorad={true}/>
          <Token left={4} right={1} key={24} id={4} isBorad={true}/>
          <Token left={6} right={4} key={25} id={5} isBorad={true}/>
          <Token left={9} right={7} key={26} id={6} isBorad={true}/>
          <Token left={0} right={8} key={27} id={7} isBorad={true}/>
          <Token left={2} right={6} key={28} id={8} isBorad={true}/>
          <Token left={1} right={3} key={29} id={9} isBorad={true}/>
          <Token left={1} right={3} key={30} id={10} isBorad={true}/>
          <Token left={1} right={3} key={31} id={11} isBorad={true}/>
          <Token left={1} right={3} key={32} id={12} isBorad={true}/>

          <Token left={3} right={5} key={33} id={3} isBorad={true}/>
          <Token left={4} right={1} key={34} id={4} isBorad={true}/>
          <Token left={6} right={4} key={35} id={5} isBorad={true}/>
          <Token left={9} right={7} key={36} id={6} isBorad={true}/>
          <Token left={0} right={8} key={37} id={7} isBorad={true}/>
          <Token left={2} right={6} key={38} id={8} isBorad={true}/>
          <Token left={1} right={3} key={39} id={9} isBorad={true}/>
          <Token left={1} right={3} key={40} id={10} isBorad={true}/>

          <Token left={3} right={5} key={43} id={3} isBorad={true}/>
          <Token left={4} right={1} key={44} id={4} isBorad={true}/>
          <Token left={6} right={4} key={45} id={5} isBorad={true}/>
          <Token left={9} right={7} key={46} id={6} isBorad={true}/>
          <Token left={0} right={8} key={47} id={7} isBorad={true}/>
          <Token left={2} right={6} key={48} id={8} isBorad={true}/>
          <Token left={1} right={3} key={49} id={9} isBorad={true}/>
          <Token left={1} right={3} key={50} id={10} isBorad={true}/>

          <Token left={3} right={5} key={53} id={3} isBorad={true}/>
          <Token left={4} right={1} key={54} id={4} isBorad={true}/>
          <Token left={6} right={4} key={55} id={5} isBorad={true}/>
          <Token left={9} right={7} key={56} id={6} isBorad={true}/>
          <Token left={0} right={8} key={57} id={7} isBorad={true}/>
          <Token left={2} right={6} key={58} id={8} isBorad={true}/>
          <Token left={1} right={3} key={59} id={9} isBorad={true}/>
          <Token left={1} right={3} key={60} id={10} isBorad={true}/>

          <Token left={3} right={5} key={63} id={3} isBorad={true}/>
          <Token left={4} right={1} key={64} id={4} isBorad={true}/>
          <Token left={6} right={4} key={65} id={5} isBorad={true}/>
          <Token left={9} right={7} key={66} id={6} isBorad={true}/>
          <Token left={0} right={8} key={67} id={7} isBorad={true}/>
          <Token left={2} right={6} key={68} id={8} isBorad={true}/>
          <Token left={1} right={3} key={69} id={9} isBorad={true}/>
          <Token left={1} right={3} key={70} id={10} isBorad={true}/>

          <Token left={3} right={5} key={73} id={3} isBorad={true}/>
          <Token left={4} right={1} key={74} id={4} isBorad={true}/>
          <Token left={6} right={4} key={75} id={5} isBorad={true}/>
          <Token left={9} right={7} key={76} id={6} isBorad={true}/>
          <Token left={0} right={8} key={77} id={7} isBorad={true}/>
          <Token left={2} right={6} key={78} id={8} isBorad={true}/>
          <Token left={1} right={3} key={79} id={9} isBorad={true}/>

          <Token left={3} right={5} key={83} id={3} isBorad={true}/>
          <Token left={4} right={1} key={84} id={4} isBorad={true}/>
          <Token left={6} right={4} key={85} id={5} isBorad={true}/>
          <Token left={9} right={7} key={86} id={6} isBorad={true}/>
          <Token left={0} right={8} key={87} id={7} isBorad={true}/>
          <Token left={2} right={6} key={88} id={8} isBorad={true}/>
          <Token left={1} right={3} key={89} id={9} isBorad={true}/>
          <Token left={1} right={3} key={80} id={10} isBorad={true}/>

          <Token left={3} right={5} key={93} id={3} isBorad={true}/>
          <Token left={4} right={1} key={94} id={4} isBorad={true}/>
          <Token left={6} right={4} key={95} id={5} isBorad={true}/>
          <Token left={9} right={7} key={96} id={6} isBorad={true}/>
          <Token left={0} right={8} key={97} id={7} isBorad={true}/>
          <Token left={2} right={6} key={98} id={8} isBorad={true}/>
          <Token left={1} right={3} key={99} id={9} isBorad={true}/>
          <Token left={1} right={3} key={90} id={10} isBorad={true}/>

          <Token left={3} right={5} key={103} id={3} isBorad={true}/>
          <Token left={4} right={1} key={104} id={4} isBorad={true}/>
          <Token left={6} right={4} key={105} id={5} isBorad={true}/>
          <Token left={9} right={7} key={106} id={6} isBorad={true}/>
          <Token left={0} right={8} key={107} id={7} isBorad={true}/>
          <Token left={2} right={6} key={108} id={8} isBorad={true}/>
          <Token left={1} right={3} key={109} id={9} isBorad={true}/>
          <Token left={1} right={3} key={100} id={10} isBorad={true}/>

          <Token left={3} right={5} key={113} id={3} isBorad={true}/>
          <Token left={4} right={1} key={114} id={4} isBorad={true}/>
          <Token left={6} right={4} key={115} id={5} isBorad={true}/>
          <Token left={9} right={7} key={116} id={6} isBorad={true}/>
          <Token left={0} right={8} key={117} id={7} isBorad={true}/>
          <Token left={2} right={6} key={118} id={8} isBorad={true}/>
          <Token left={1} right={3} key={119} id={9} isBorad={true}/>
          <Token left={1} right={3} key={110} id={10} isBorad={true}/>


          
      </div>      

      <div className='list-tokens'>
        <div className='list-tokens__group'>
        <Token left={5} right={4} key={1} id={1} />
        <Token left={6} right={3} key={2} id={2} />
        <Token left={3} right={5} key={3} id={3} />
        <Token left={7} right={7} key={4} id={4} />
        <Token left={1} right={0} key={5} id={5} />
        </div>
      </div>
      {/* <pre>
        {
          JSON.stringify( settings, null , 3 )
        }
      </pre> */}
    </div>
  )
}
