import React, { Component } from 'react';
import axios from 'axios';

export default class Pages extends Component{
    state = {
        errorMessage: null,
        acessos: []
      }
    
      componentDidMount(){
          try{
            const response = axios.get('https://webrastreamentoapi.azurewebsites.net/Acessos/' + String(this.props.id).replace(".com","").replace(".com.br",""))
            .then(res => {
                this.setState({ acessos: res.data})
            });
          }catch(response){
              this.setState({ errorMessage: response.data.errorMessage })
          }
      }
      
    render(){
        return(
            <li>
            { !!this.state.errorMessage && <label>{ this.state.errorMessage }</label>}
            {this.props.text}
                <ul>
                    {this.state.acessos.map((acesso) => 
                      <li>{acesso.pagina}</li>  
                    )}
                </ul>
            </li>
        )
    }
}