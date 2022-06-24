import React, { useContext } from 'react';
import PropTypes from 'prop-types';
import { Dropdown } from 'semantic-ui-react';
import { SettingsContext } from '../../helpers/SettingsContext';

export const DataOptions = ({ titleOption, nameOptions, id }) => {

    const { settings, setSettings } = useContext( SettingsContext );
    const TypeOptions = GetTypeOptions(nameOptions);

    const handleChange = (e, result) => {
        setSettings({
            ...settings,
            [id]: result.value
        });
    }

    return (
        <div className='container__selected-option'>
            <h3>{ titleOption }</h3>
            <Dropdown
                placeholder='Selecciona una opcion'
                fluid
                selection
                options={ TypeOptions }
                onChange={handleChange}
            />
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

