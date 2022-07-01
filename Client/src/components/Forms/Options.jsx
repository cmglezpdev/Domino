import React, { useContext, useEffect, useState } from 'react';
import { BASE_URL } from '../../helpers/api.js';
import { DataOptions } from './DataOptions.jsx';
import './options.scss';
import { Button, Input, Progress } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext.js';
import { toast } from 'react-toastify';

export const Options = () => {

    const [progress, setProgress] = useState({
        percent: 0,
        option: 0
    });
    
    const [settings, setSettings] = useState([]);
    const context = useContext(SettingsContext);
    const [optionsNumbers] = useState({
        maxIdTokens: 4,
        countPlayer: 2,
        countTokensByPlayer: 2
    });

    useEffect(() => {
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                console.log(data.options);
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
        

    const handleEvaluate = ( e ) => {
        
        const text = e.target.innerText; 

        if(text == "Anterior") {
            setProgress({
                percent : 100 / settings.length * (progress.option + 1),
                option: progress.option - 1
            })
            // return;
        }
        else
        if(text == "Siguiente" ) {
            // if( context[settings.id] !== null ) {
                setProgress({
                    percent : 100 / settings.length * (progress.option + 1),
                    option: progress.option + 1
                })
            // }
            // return;
        }

        console.log(progress);
    }


    return (
        <div className='container'>
            
            
            <h1>Seleccionar el tipo de juego</h1>
            <Progress percent={progress.percent} precision />
            
            {
                settings.length !== 0 && 
                (<DataOptions 
                    titleOption={settings[progress.option].titleOption}
                    nameOptions={settings[progress.option].nameOptions}
                    id={settings[progress.option].id}
                />)
            }

            <div className='buttons'>
                <Button
                    onClick={handleEvaluate}
                    color={'green'}
                    className={`btn-prev ${progress.option === 0 ? 'hidden' : ''}`}
                >
                    Anterior
                </Button>
                
                <Button
                    onClick={handleEvaluate}
                    color={'green'}
                    className={`btn-next ${progress.option === settings.length ? 'hidden' : ''}`}
                >
                    Siguiente
                </Button>
            </div>


{/* 
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
            </div> */}



            {/* <Button
                className='container__button-game'
                onClick={handleStartGame}
            >
                Jugar
            </Button> */}
        </div>
    )

}
