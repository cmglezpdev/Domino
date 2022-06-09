import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';

import './index.scss';
import 'semantic-ui-css/semantic.min.css';
import { DataOptions } from './components/Forms/DataOptions';

const root = ReactDOM.createRoot(document.getElementById('root'));

// root.render( <DataOptions titleOption={"Hola mundo"} nameValue={["Hola", "Mundo"]} /> );
root.render( <App /> );
