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
    const [optionsNumbers, setOptionsNumbers] = useState({
        maxIdTokens: 4,
        countPlayer: 2,
        countTokensByPlayer: 2
    });

    useEffect(() => {
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                setSettings(
                    data.options
                ); 
            });
    }, []);
    
    const handleStartGame = () => {
        // Comprobar si se llenaron todos los campos
        const len = Object.keys( context.settings ).length - 1; // le resto las 3 de los numeros
        if( len !== settings.length ) {
            toast.error("Por favor, seleccione todos los campos");
            return;
        } 
        
        // Comprobar si la seleccion de la cant fichas, judaores y id esta bien
        const cantTokens = context.settings.maxIdTokens * (context.settings.maxIdTokens + 1) / 2;
        const maxCountTokensbyPlayers = Math.floor( cantTokens / context.settings.countPlayer );
       
        if( maxCountTokensbyPlayers < context.settings.countTokensByPlayer ) {
            toast.error("Seleccione menos jugadores o reparta menos fichas!!");
            return;
        }

        context.setSettings({
            ...context.settings,
            ...optionsNumbers,
            done: true
        });
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
                    value={optionsNumbers.maxIdTokens}
                    min={4}
                    max={9}
                    onChange={
                        (e) => setOptionsNumbers({
                                    ...optionsNumbers,
                                    maxIdTokens: parseInt(e.target.value) 
                                })
                        }
                />

                <Input 
                    label="Cantidad de jugadores"
                    type='number'
                    value={optionsNumbers.countPlayer}
                    min={2}
                    // max={10}
                    onChange={
                        (e) => setOptionsNumbers({
                                    ...optionsNumbers,
                                    countPlayer: parseInt(e.target.value) 
                                })
                        }
                />

                <Input 
                    label="Fichas por jugador"
                    type='number'
                    value={optionsNumbers.countTokensByPlayer}
                    min={2}
                    // max={10}
                    onChange={
                        (e) => setOptionsNumbers({
                                    ...optionsNumbers,
                                    countTokensByPlayer: parseInt(e.target.value) 
                                })
                        }
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
