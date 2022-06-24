import React, { useContext, useEffect, useState } from 'react';
import { BASE_URL } from '../../helpers/api.js';
import { DataOptions } from './DataOptions.jsx';
import './options.scss';
import { Button, Input } from 'semantic-ui-react';
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
            console.log(context.settings);
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
            
            <div className='data-numbers'>
                <Input 
                label="Id max Fichas"
                    type='number'
                    value={4}
                    min={5}
                    max={9}
                />

                <Input 
                label="Cantidad de jugadores"
                    type='number'
                    value={2}
                    min={2}
                    max={10}
                />

                <Input 
                label="Fichas por jugador"
                    type='number'
                    value={2}
                    min={2}
                    max={10}
                />
            </div>

            <Button
                className='container__button-game'
                onClick={handleStartGame}
            >
                Jugar
            </Button>
        </div>
    )

}
