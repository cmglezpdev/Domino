import React, { useContext } from 'react';
import PropTypes from 'prop-types';
import { Dropdown } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext';
import generateId from '../../helpers/generateIds';
import { namesPlayers } from '../../helpers/dataPlayers';
import { toast } from 'react-toastify';

export const DataOptions = ({ titleOption, nameOptions, id, value, GetOptions }) => {

    const { settings, setSettings } = useContext( SettingsContext );
    const TypeOptions = GetTypeOptions(nameOptions);
    

    // Maneja los cambios que ocurren en los formularios
    const handleChange = (e, result) => {
        
        let aux = settings.player;
        
        // Manejar que la cantidad maxima de fichas posibles a crear se puedan repartir entre todos los jugadores
        if( id === "countPlayers" ) {
            
            // Si ya se seleccionarion las fichas y los jugadores comprobar si sale una cantidad correcta
            const maxIdTokens = parseInt(GetOptions("maxIdTokens")[settings.maxIdTokens]);          
            const countPlayer = parseInt(GetOptions("countPlayers")[result.value]);
            const countTokens = parseInt(GetOptions("countTokens")[settings.countTokens]);

            const cantTokens = maxIdTokens * (maxIdTokens + 1) / 2;
            const maxCountTokensbyPlayers = Math.floor( cantTokens / countPlayer );
            
            if( maxCountTokensbyPlayers < countTokens ) {
                toast.error("Seleccione menos jugadores o reparta menos fichas!!");
                return;
            }
            
            aux = new Array(parseInt(GetOptions("countPlayers")[result.value])).fill(0);
        }
        
        // Actualizar el estado con los nuevos valores
        setSettings({
            ...settings,
            [id]: result.value,
            player: aux
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
                            <div key={generateId()}>
                                <h4>Jugador: { namesPlayers[player] }</h4>
                                <Dropdown
                                    key={generateId()}
                                    placeholder='Seleccionar'
                                    fluid
                                    selection
                                    options={TypeOptions}
                                    onChange={(e, result) => {
                                        let aux = settings.player;
                                        aux[player] = result.value;
                                        setSettings({
                                            ...settings,
                                            player: aux,
                                        });
                                    }}
                                    value={ settings[id][player] }
                                />
                            </div>
                        )
                    })
                : // Mostrar los campos que le corresponden
                    (<Dropdown
                        placeholder='Selecciona una opcion'
                        fluid
                        key={generateId()}
                        selection
                        options={ TypeOptions }
                        onChange={handleChange}
                        value={value}
                    />)

            }

        </div>
    )
}



// Protopype del componente
DataOptions.prototype = {
    titleOption: PropTypes.string.isRequired,
    nameOptions: PropTypes.array.isRequired,
    id: PropTypes.string.isRequired
}


// Construir la información necesaria para los Dropdown
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

