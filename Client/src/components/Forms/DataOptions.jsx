import React, { useState, useContext, useEffect } from 'react';
import PropTypes from 'prop-types';
import { Dropdown, Input } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext';

export const DataOptions = ({ titleOption, nameOptions, id, value }) => {

    const { settings, setSettings } = useContext( SettingsContext );
    const TypeOptions = GetTypeOptions(nameOptions);
    const [optionsNumbers, setOptionsNumbers] = useState({
        maxIdTokens: 4,
        countPlayer: 2,
        countTokensByPlayer: 2
    });



    const handleChange = (e, result) => {
        setSettings({
            ...settings,
            [id]: result.value
        });
    }

    useEffect(() => {
   
    })


    return (
        
        <div className='container__selected-option'>
            <h3>{ titleOption }</h3>

            {
            id == 'player' ? (
                <>
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

                    {
                        optionsNumbers.countPlayer.map(indexPlayer => {
                           return  <Dropdown
                                placeholder={`Tipo de jugador ${indexPlayer}`}
                                fluid
                                selection
                                options={ TypeOptions }
                                onChange={handleChange}
                                value={value}
                            />
                        })
                    }
                </>




            ) : (<Dropdown
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

