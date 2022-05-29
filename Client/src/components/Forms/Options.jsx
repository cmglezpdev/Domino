import React, { useEffect, useState } from 'react';
import { BASE_URL } from '../../helpers/api.js';
import { DataOptions } from './DataOptions.jsx';
import './options.scss';
import { Button } from 'semantic-ui-react';

export const Options = () => {

    const [settings, setSettings] = useState([]);

    useEffect(() => {
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
                setSettings(data.options);  
            });
        
    }, []);
    

    return (
        <div className='container'>
            <h1>Seleccionar el tipo de juego</h1>
            {   
                settings.map(({ titleOption, nameValue }, index) => {
                    // console.log({titleOption, nameValue});
                    return (
                        <DataOptions 
                            key={index}
                            titleOption={titleOption} 
                            nameValue={nameValue}
                        />
                    )
                })
            }
            
            <Button
                className='container__button-game'
            >
                Jugar
            </Button>
        </div>
    )

}
