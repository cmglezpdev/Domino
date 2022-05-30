import React from 'react'

export const Game = ({ settings }) => {
  return (
    <>
      <pre>
        {
          JSON.stringify( settings, null , 3 )
        }
      </pre>
    </>
  )
}
