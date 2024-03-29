import React, { useEffect, useState, useContext } from 'react';
import { Confirm, Icon } from 'semantic-ui-react'
import { Board } from './Board/Board';
import { MessageGame } from './MessageGame/MessageGame';
import { PlayerTokens } from './PlayerTokens/PlayerTokens';

import { SettingsContext } from '../../helpers/SettingsContext';
import { BASE_URL } from '../../helpers/api.js';
import getBackground from '../../helpers/backgroundBoard';

import './game.scss';
import { Information } from '../Information';

// Lógica general del juego(visual)
export const Game = () => {
  
  const { settings, setSettings } = useContext(SettingsContext);
  const [currentPlay, setCurrentPlay] = useState(undefined);
  const [background, setBackground] = useState(getBackground());
  const [open, setOpen] = useState(false);
  const [openInformation, setOpenInformation] = useState(false);
         
  // Controla las acciones de los botones de Next Turn y New Game
  const handleNextTurn = (e) => {
    const btnText = e.target.innerText;
    // Reiniciar las configuraciones a cero
    if( btnText === 'New Game'.toUpperCase() ) {
      setSettings({
        done: false
      });
      return;
    }

    // Fetch a la api para obtener la información de la próxima partida
    fetch( `${BASE_URL}/NextTurn` )
      .then(result => result.json())
      .then(play => {
        setCurrentPlay(play);
      })
  }

  // Manda configuraciones al server y obtiene datos iniciales
  const handleStartGame = () => {
    fetch(`${BASE_URL}/TypeGame`, {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json'
      },
      body: JSON.stringify( settings )
    }).then(result => result.json())
      .then( data => {
        setCurrentPlay({
          players: data,
          currentPlayer: 0,
          passed: false,
          tokensInBoard: [],
          finishGame: false,
          winners: []
      });
      })
  }

  useEffect(() => {
    handleStartGame();
  }, [] );

  const showAlert = () => {
      setOpen(true);
  } 

  return (

    <div 
      className='container-game'
      style={{
        background: `url(${background})`
      }}
    >
      <div className="controls">
        <button 
          className="change-background"
          onClick={() => {
            setBackground( getBackground() );
          }}
        > 
          background
        </button>
          <Icon
            name='info circle'
            className='info-icon'
            onClick={() => setOpenInformation(true)}
        />
      </div>
  
      <Confirm
        open={open}
        onCancel={ () => setOpen(false) }
        onConfirm={ () => {
          setOpen(false);
          handleStartGame();
        } }
      />

        <Information open={openInformation} setOpen={setOpenInformation} />


      {/* Muestra las fuchas del tablero */}
      <Board currentPlay={currentPlay}/>

      {/* Mensaje que se muestra cuando alguien se pasa o termina el juego */}
     <MessageGame currentPlay={currentPlay}/>
      

        {/* Muestra al jugador actual y a la lista de fichas del jugador */}
      <PlayerTokens currentPlay={currentPlay} handleNextTurn={handleNextTurn} handleResetGame={ showAlert }/>

    </div>
  )
}