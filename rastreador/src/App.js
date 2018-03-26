import React from 'react';

import axios from 'axios';

const acesso = (pagina, data, email) => {
    this.pagina = pagina;
    this.data = data;
    this.visitanteEmail = email;
    return this;
}

var config = { headers: {'Content-Type': 'application/json'} };

export default class App extends React.Component{
   
    componentDidMount(){
        var email = localStorage.getItem("@Rastreador:email");

        if(email){
            const response = axios.post('http://localhost:55203/Acessos',
                JSON.stringify(new acesso(window.location.pathname, new Date().toLocaleString(), email)), config
            )
            .then(res => {
                console.log("enviado com sucesso")
            })
            .catch(error => {
                console.log(error.response.data)
            });
        }
    }
    
    render(){
        return("");
    }
}