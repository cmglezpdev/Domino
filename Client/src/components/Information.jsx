import React, {useEffect, useState, useContext} from 'react'
import { SettingsContext } from './../helpers/SettingsContext'
import { Modal, Image, Button, Icon } from 'semantic-ui-react'

import { BASE_URL } from '../helpers/api.js';
import './information.scss';
import { namesPlayers } from '../helpers/dataPlayers';

export const Information = () => {
    
    // Context que tiene las opciones del juego  seleccionadas por el usuario
    const { settings } = useContext(SettingsContext);
    // tiene las opciones renderizadas por el serividor
    const [ initialOptions, setInitialOptions ] = useState([]); 


     useEffect(() => {
        // Se realiza la peticion al servidor de los tipos de juego que quiere mostrar
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                console.log(data.options);
                setInitialOptions(
                    data.options
                ); 
            });
    }, []);


    const getInfo = (id, propertie, index) => {
        console.log(initialOptions);
        const opt = initialOptions.filter(option => option.id === id);
        if( propertie == "titleOption" )  return opt[0][propertie] || "";
        
        return opt[0][propertie][index];
    }

    const setOpen = () => {

    }


    return (
        <>
    {/* <Modal
      open={true}
    //   onClose={() => setOpen(false)}
    //   onOpen={() => setOpen(true)}
    //   trigger={<Button>Scrolling Content Modal</Button>}
    >
      <Modal.Header>Profile Picture</Modal.Header>
      <Modal.Content scrolling>

        <Modal.Description>
          <p>
            This is an example of expanded content that will cause the modal's
            dimmer to scroll.
          </p>

          <Image
            src='/images/wireframe/paragraph.png'
            style={{ marginBottom: 10 }}
          />
          <Image
            src='/images/wireframe/paragraph.png'
            style={{ marginBottom: 10 }}
          />
          <Image
            src='/images/wireframe/paragraph.png'
            style={{ marginBottom: 10 }}
          />
          <Image
            src='/images/wireframe/paragraph.png'
            style={{ marginBottom: 10 }}
          />
          <Image
            src='/images/wireframe/paragraph.png'
            style={{ marginBottom: 10 }}
          />
          <Image
            src='/images/wireframe/paragraph.png'
            style={{ marginBottom: 10 }}
          />
          <Image
            src='/images/wireframe/paragraph.png'
            style={{ marginBottom: 10 }}
          />
          <Image src='/images/wireframe/paragraph.png' />
        </Modal.Description>
      </Modal.Content>
      <Modal.Actions>
        <Button onClick={() => setOpen(false)} primary>
          Proceed <Icon name='chevron right' />
        </Button>
      </Modal.Actions>
    </Modal>

 */}


        {/* <div className='information-game'>
            {
                Object.keys(settings).map( (option, index) => {
                    if( option !== "done" ) {
                        if( option === 'player' ) return null;
                        return (
                            <div className='options-of-game'>
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
                                <span className='option_type'>{`Jugador ${namesPlayers[i]}: ${getInfo("player", "nameOptions", type)}`}</span>
                            )
                        })
                    }
                </div>
            )
            }
        </div> */}
        </>
  )
}
