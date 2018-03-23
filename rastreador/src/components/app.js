import React from 'react';

import api from '../services/api';

export default class App extends React.Component{
    state = {
        user: '',
        id: 0,
    }

    singIn = async () =>{
        const user = 'C#';
        try{
            const response = await api.post('https://jsonplaceholder.typicode.com/users',{user})
            .then(res => {
                console.log(res);
                console.log(res.data);
                this.setState(res.data);
            });
        }catch(error){
            console.error(error);
        }

        await localStorage.setItem('@Rastreador:user', this.state.user);
        await localStorage.setItem('@Rastreador:id', this.state.id);

    }

    
    
    render(){
        return(
            <div>
                <button onClick={this.singIn}>teste</button>
            </div>
        );
    }
}