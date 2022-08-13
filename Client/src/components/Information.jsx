import React, {useEffect, useState, useContext} from 'react'
import { SettingsContext } from './../helpers/SettingsContext'
import { Modal, Button } from 'semantic-ui-react'

import { BASE_URL } from '../helpers/api.js';
import './information.scss';
import { namesPlayers } from '../helpers/dataPlayers';
import generateId from '../helpers/generateIds';

// Muestra el modal con la configuración del juego
export const Information = ({ open, setOpen }) => {
    
    // Context que tiene las opciones del juego  seleccionadas por el usuario
    const { settings } = useContext(SettingsContext);
    // tiene las opciones renderizadas por el serividor
    const [ initialOptions, setInitialOptions ] = useState([]); 

     useEffect(() => {
        // Se realiza la peticion al servidor de los tipos de juego que quiere mostrar
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                    setInitialOptions(
                    data.options
                ); 
            });
    }, []);


    const getInfo = (id, propertie, index) => {
        const opt = initialOptions.filter(option => {
          return option.id === id
        });

        if(opt.length === 0) return;

        if( propertie === "titleOption" )  return opt[0][propertie];
        
        return opt[0][propertie][index];
    }

    return (
      <Modal
        open={open}
        onClose={() => setOpen(false)}
      >
        <Modal.Header>Game Information</Modal.Header>
        <Modal.Content scrolling className='information-game'>
            {
                Object.keys(settings).map( (option, index) => {
                    if( option !== "done" ) {
                        if( option === 'player' ) return null;
                        return (
                            <div className='options-of-game' key={generateId()}>
                                <span className='option_title'>{getInfo(option, "titleOption")}</span>
                                <span className='option_type'>{ getInfo(option, "nameOptions", settings[option]) }</span>
                            </div>
                        )
                      }
                })
                
              }
            {
              settings["player"] && (
                <div className='options-of-game players'>
                    <span className='option_title'>{getInfo("player", "titleOption")}</span>
                    {
                      settings["player"]?.map((type, i) => {
                        return (
                          <span className='option_type' key={generateId()}>{`Jugador ${namesPlayers[i]}: ${getInfo("player", "nameOptions", type)}`}</span>
                          )
                        })
                    }
                </div>
            )
            }

        </Modal.Content>
        <Modal.Actions>
          <Button onClick={() => setOpen(false)} primary>
            OK
          </Button>
        </Modal.Actions>
      </Modal>
  )
}
