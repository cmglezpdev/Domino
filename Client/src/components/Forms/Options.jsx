import React, { useEffect, useState } from 'react';
import { useFetch } from '../../Hooks/useFetch.js';
import { BASE_URL } from '../../helpers/api.js';

export const Options = () => {

    const [options, setOptions] = useState({});

    useEffect(() => {
        
        fetch( `${BASE_URL}/loader` )
            .then( response => response.json())
            .then( data => {
              setOptions(data);  
            })
     
    }, []);

    return (
        <div>
            <h1>Seleccionar el tipo de juego</h1>
            <pre>
                {
                    JSON.stringify( options, null, 3 )
                }
            </pre>
        </div>
    )

}
