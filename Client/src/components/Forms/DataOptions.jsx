import React, { useState, useContext, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Dropdown, Input } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext';
import generateId from '../../helpers/generateIds';

export const DataOptions = ({ titleOption, nameOptions, id, value, GetOptions }) => {

    const { settings, setSettings } = useContext( SettingsContext );
    const TypeOptions = GetTypeOptions(nameOptions);
    
    const handleChange = (e, result) => {

        setSettings({
            ...settings,
            [id]: result.value,
        });
    }


    // devuelve un array de 0, 1, .... , length
    const getArrayPlayers = (length) => Array.from({length : length}, (v, i) => i);

    return (
        
        <div className='container__selected-option'>
            <h3>{ titleOption }</h3>
            {
            // Si son las opciones de los jugadores, mostrar las opciones por jugador
                id === "player" ? 
                // Mostrar los diferentes jugadores
                getArrayPlayers( parseInt(GetOptions("countPlayers")[settings.countPlayers]) ).map(player => {
                    return (
                        <>
                            <h4>Jugador {player}</h4>
                            <Dropdown
                                placeholder='Seleccionar'
                                fluid
                                key={generateId()}
                                selection
                                options={TypeOptions}
                                onChange={(e, result) => {
                                    setSettings({
                                        ...settings,
                                        [`player_${player}`]: result.value,
                                    });
                                }}
                                value={ settings[`player_${player}`] }
                            />
                        </>
                    )
                })
                :
                (<Dropdown
                    placeholder='Selecciona una opcion'
                    fluid
                    selection
                    options={ TypeOptions }
                    onChange={handleChange}
                    value={value}
                />)

            }

        </div>
    )
}




DataOptions.prototype = {
    titleOption: PropTypes.string.isRequired,
    nameOptions: PropTypes.array.isRequired,
    id: PropTypes.string.isRequired
}


const GetTypeOptions = (nameValue) => {
    let options = [];

    nameValue.map((opt, index) => {
        options.push({
            key: opt,
            text: opt,
            value: index
        });
        return undefined;
    });

    return options;
}

