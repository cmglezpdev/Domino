import React, { useContext, useEffect, useState } from 'react';
import { BASE_URL } from '../../helpers/api.js';
import { DataOptions } from './DataOptions.jsx';
import './options.scss';
import { Button } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext.js';
import { toast } from 'react-toastify';

export const Options = () => {

    const [settings, setSettings] = useState([]);
    const context = useContext(SettingsContext);

    useEffect(() => {
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                setSettings(data.options); 
            });
    }, []);
    
    const handleStartGame = () => {
        const len = Object.keys( context.settings ).length - 1;
        if( len !== settings.length ) {
            toast.error("Por favor, seleccione todos los campos");
        } 
        else {
            context.setSettings({
                ...context.settings,
                done: true
            })
        }
    }

    return (
        <div className='container'>
            <h1>Seleccionar el tipo de juego</h1>
            {
                settings.map(({ titleOption, id, nameOptions }) => {
                    return (
                        <DataOptions 
                            key={id}
                            titleOption={titleOption} 
                            nameOptions={nameOptions}
                            id={id}
                        />
                    )
                })
            }
            
            <Button
                className='container__button-game'
                onClick={handleStartGame}
            >
                Jugar
            </Button>
        </div>
    )

}
