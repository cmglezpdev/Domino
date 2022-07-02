import React, { useContext, useEffect, useState } from 'react';
import { BASE_URL } from '../../helpers/api.js';
import { DataOptions } from './DataOptions.jsx';
import './options.scss';
import { Button, Input, Progress } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext.js';
import { toast } from 'react-toastify';
import generateId from '../../helpers/generateIds.js';

export const Options = () => {

    const [progress, setProgress] = useState(0);
    const [settings, setSettings] = useState([]);
    const context = useContext(SettingsContext);

    useEffect(() => {
        // Se realiza la peticion al servidor de los tipos de juego que quiere mostrar
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                console.log(data.options);
                setSettings(
                    data.options
                ); 
            });
    }, []);
    
    // Metodo que se ejecuta al dar play al juego
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
            maxIdTokens: 4,
            countPlayer: 2,
            countTokensByPlayer: 2,
            done: true
        });
    }
        
    // Antes de pasar a seleccionar otra opcion se verifica que se selecciono alguna opcion en la actual
    const handleEvaluate = ( e ) => {
        
        const text = e.target.innerText; 

        if(text == "Anterior") {
            setProgress(progress - 1)
            // return;
        }
        else
        if(text == "Siguiente" ) {
            // console.log(context.settings[settings[progress].id])
            // if( context.settings[settings[progress].id] !== undefined ) {
                setProgress(progress + 1)
            // }
            return;
        }

        // console.log(progress);
    }

    // Devolver las opciones de un id especifico
    const GetOptions = (id) => {
        const opt = settings.filter(option => option.id === id);
        console.log(opt);
        return opt[0].nameOptions || [];
    }

    return (
        <div className='container'>
                    
            <h1>Seleccionar el tipo de juego</h1>
            <Progress percent={100 / (settings.length - 1) * progress} precision />
            
            {
                // Si ya se cargaron las opciones del juego
                settings.length !== 0 && (
                   <DataOptions 
                        key={generateId()}
                        titleOption={settings[progress].titleOption}
                        nameOptions={settings[progress].nameOptions}
                        id={settings[progress].id}
                        GetOptions={GetOptions}
                        value={ context.settings[ settings[progress]?.id ] }
                    />
                )
            }









            {/* Botones para avanzar o retroceder en las opciones */}
            <div className='buttons'>
                <Button
                    onClick={handleEvaluate}
                    color={'green'}
                    className={`btn-prev ${progress === 0 ? 'hidden' : ''}`} // oCultarlo cuando sea la primera opcion
                >
                    Anterior
                </Button>
                
                <Button
                    onClick={handleEvaluate}
                    color={'green'}
                    className={`btn-next`}
                    disabled={ context.settings[ settings[progress]?.id ] === undefined } // Deshabilitar el boton cuando no se selecciono nada
                >
                    {progress === settings.length - 1 ? 'Jugar' : 'Siguiente'} 
                </Button>
            </div>






            {
                JSON.stringify(progress, null, 3)
            }

        </div>
    )

}
