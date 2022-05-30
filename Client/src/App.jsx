import React, { useState, useEffect } from "react";
import { Options } from "./components/Forms/Options";
import { Game } from "./components/Game/Game";
import { SettingsContext } from './helpers/SettingsContext';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './index.scss';


function App() {
  
  const [settings, setSettings] = useState({
      done: false
  });
  
  return (

    <>
      <ToastContainer
        position="top-center"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss={false}
        draggable={false}
        pauseOnHover={false}
        theme={"colored"}
      />
      {
        ( !settings.done ) ?
        (
          <SettingsContext.Provider value={{
            settings,
            setSettings
          }}>
            <Options />
          </SettingsContext.Provider>
        )
        :
        (
          <Game settings={settings}/>
        )
      }

    </>
  );
}

export default App;
