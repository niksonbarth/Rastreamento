import React from 'react';

import axios from 'axios';

const acesso = (pagina, data, email) => {
    this.pagina = pagina;
    this.data = data;
    this.visitanteEmail = email;
    return this;
}

var config = { headers: {'Content-Type': 'application/json'} };

export default class Tracker extends React.Component{
   
    componentDidMount(){
        localStorage.setItem("@Page-" + window.location.pathname, window.location.pathname + '|' + new Date())
        var email = localStorage.getItem("@Rastreador:email");

        if(email){
            for (var key in localStorage){
                if(key.includes("@Page")){
                    var page = localStorage.getItem(key).split('|');
                    const response = axios.post('http://localhost:55203/Acessos',
                        JSON.stringify(new acesso(page[0], new Date(page[1]), email)), config
                    )
                    .then(res => {
                        console.log("enviado com sucesso")
                    })
                    .catch(error => {
                        console.log(error)
                    });

                    localStorage.removeItem(key)
                }
            }
        }
    }
    
    render(){
        return("");
    }
}