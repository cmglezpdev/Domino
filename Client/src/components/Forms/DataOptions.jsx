import React from 'react';
import PropTypes from 'prop-types';
import { Dropdown } from 'semantic-ui-react';

export const DataOptions = ({ titleOption, nameValue }) => {

    const TypeOptions = GetTypeOptions(nameValue);
    console.log(nameValue);
    return (
    <div className='container__selected-option'>
        <h3>{ titleOption }</h3>
        <Dropdown
            placeholder='Selecciona una opcion'
            fluid
            selection
            options={ TypeOptions }
        />
    </div>
  )
}

DataOptions.prototype = {
    titleOption: PropTypes.string.isRequired,
    nameValue: PropTypes.array.isRequired
}


const GetTypeOptions = (nameValue) => {
    let options = [];

    nameValue.map((opt, index) => {
        options.push({
            key: opt,
            text: opt,
            value: index
        });
    });
    return options;
}
