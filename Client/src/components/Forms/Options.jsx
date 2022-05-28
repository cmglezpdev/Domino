import React, { useState } from 'react';
import { useFetch } from '../../Hooks/useFetch.js';
import { BASE_URL } from '../../helpers/api.js';

export const Options = () => {

    const state = useFetch( BASE_URL );

    return (
        <div>
            <h1>Seleccionar el tipo de juego</h1>
           
            <h3> Hola a todos </h3>
        </div>
    )

}
