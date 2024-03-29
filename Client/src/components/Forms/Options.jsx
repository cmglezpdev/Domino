import React, { useContext, useEffect, useState } from 'react';
import { BASE_URL } from '../../helpers/api.js';
import { DataOptions } from './DataOptions.jsx';
import './options.scss';
import { Button, Progress } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext.js';
import { toast } from 'react-toastify';
import generateId from '../../helpers/generateIds.js';
import { Selected } from './Selected.jsx';

export const Options = () => {

    const [progress, setProgress] = useState(0);
    const [settings, setSettings] = useState([]);
    const context = useContext(SettingsContext);

    useEffect(() => {
        // Se realiza la peticion al servidor de los tipos de juego que quiere mostrar
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                setSettings(
                    data.options
                ); 
            });
    }, []);
    
    // Metodo que se ejecuta al dar play al juego
    const handleStartGame = () => {
  
        // Comprobar si la seleccion de la cant fichas, judadores y id están bien
        const cantTokens = context.settings.maxIdTokens * (context.settings.maxIdTokens + 1) / 2;
        const maxCountTokensbyPlayers = Math.floor( cantTokens / context.settings.countPlayer );
       
        if( maxCountTokensbyPlayers < context.settings.countTokensByPlayer ) {
            toast.error("Seleccione menos jugadores o reparta menos fichas!!");
            return;
        }

        context.setSettings({
            ...context.settings,
            done: true
        });
    }
        
    // Antes de pasar a seleccionar otra opción se verifica que se seleccionó alguna opción en la actual
    const handleEvaluate = ( e ) => {
        
        const text = e.target.innerText; 

        if(text === "Anterior") {
            setProgress(progress - 1)
            return;
        }

        if(text === "Siguiente" ) {
            setProgress(progress + 1)
            return;
        }

        // Play
        handleStartGame();
    }

    // Devolver las opciones de un id específico
    const GetOptions = (id) => {
        const opt = settings.filter(option => option.id === id);
        return opt[0].nameOptions || [];
    }

    const selectedAllPlayers = () => {
        for(let i = 0; i < context.settings.countPlayers; i ++) {
            if( context.settings[`player_${i}`] === undefined ) return false;
        }
        return true;
    }


    return (
        <div className='container'>
                    
            <h1>Seleccionar el tipo de juego</h1>
            <Progress percent={100 / (settings.length - 1) * progress} precision={1} color='green' />
            
            {
                // Si ya se cargaron las opciones del juego
                settings.length !== 0 && (
                   <DataOptions 
                        titleOption={settings[progress].titleOption}
                        nameOptions={settings[progress].nameOptions}
                        id={settings[progress].id}
                        GetOptions={GetOptions}
                        value={ context.settings[ settings[progress]?.id ] }
                        key={generateId()}
                    />
                )
            }

            {/* Botones para avanzar o retroceder en las opciones */}
            <div className='buttons'>
                <Button
                    onClick={handleEvaluate}
                    color={'green'}
                    className={`btn-prev ${progress === 0 ? 'hidden' : ''}`} // ocultarlo cuando sea la primera opcion
                >
                    Anterior
                </Button>
                
                <Button
                    onClick={handleEvaluate}
                    color={'green'}
                    className={`btn-next`}
                    disabled={ 
                        ( settings[progress]?.id ) ? 
                            context.settings[ settings[progress]?.id ] === undefined :
                            !selectedAllPlayers() 
                    } // Deshabilitar el boton cuando no se selecciono nada
                >
                    {progress === settings.length - 1 ? 'Jugar' : 'Siguiente'} 
                </Button>
            </div>

            {/* Mustra la información seleccionada hasta el momento */}
            <Selected InfoOptions={settings} />

        </div>
    )

}
