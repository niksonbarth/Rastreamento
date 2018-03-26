import React, { Component } from 'react';
import axios from 'axios';

export default class Pages extends Component{
    state = {
        errorMessage: null,
        acessos: []
      }
    
      componentDidMount(){
          try{
            const response = axios.get('http://localhost:55203/Acessos/' + this.props.id)
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