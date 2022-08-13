import React from 'react'
import { useContext } from 'react'
import { namesPlayers } from '../../helpers/dataPlayers';
import { SettingsContext } from '../../helpers/SettingsContext';
import generateId from '../../helpers/generateIds';
import './selected.scss';


// Componente para renderizar toda la información que se va seleccionando
export const Selected = ({ InfoOptions }) => {
  
    const { settings } = useContext( SettingsContext );
  

    const getInfo = (id, propertie, index) => {
        const opt = InfoOptions.filter(option => option.id === id);
        if( propertie === "titleOption" )  return opt[0][propertie];
        return opt[0][propertie][index];
    }


    return (
    <div className='current-options'>
        {
            Object.keys(settings).map( (option) => {
                if( option !== "done" ) {
                    if( option === 'player' ) return null;
                    return (
                        <div className='selected-option'  key={generateId()}>
                            <span>{getInfo(option, "titleOption")}</span>
                            <span>{ getInfo(option, "nameOptions", settings[option]) }</span>
                        </div>
                    )
                }
            })
            
        }
        {
        settings["player"] && (
            <div className='selected-option players'>
                <span>{getInfo("player", "titleOption")}</span>
                {
                    settings["player"]?.map((type, i) => {
                        return (
                            <span key={generateId()} >{`Jugador ${namesPlayers[i]}: ${getInfo("player", "nameOptions", type)}`}</span>
                        )
                    })
                }
            </div>
        )
        }
    </div>
  )
}