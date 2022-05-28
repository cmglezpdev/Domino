import { useEffect, useRef, useState } from "react";


export const useFetch = ( url ) => {

    const isMounted = useRef( true );

    const [state, setState] = useState({
        data: null,
        loading: true,
        error: null
    });


    useEffect(() => {
        return() => {
            isMounted.current = false;
        }
    }, [])


    useEffect(() => {

        setState({data:null, loading:true, error:null});

        fetch( url )
            .then(response => response.json())
            .then(data => {
                                    
                if( isMounted ) {
                    setState({
                        data,
                        loading:false,
                        error: null
                    })
                } else {
                    console.log("setState no se llamo");    
                }


            });

    }, [url]);

    return state;
}