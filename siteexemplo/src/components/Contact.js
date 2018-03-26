import React, { Component } from 'react';
import axios from 'axios';

const data = (email) => {
  this.email = email;
  return this;
}

export default class Contact extends Component {
      constructor(props){
        super(props);
        
        this.state={
          contato: '',
          resultMessage: ''
        };

        this.Enviar = this.Enviar.bind(this);
        this.handleTextChange = this.handleTextChange.bind(this);
    }
    

    Enviar(e){
      var config = { headers: {'Content-Type': 'application/json'} };

      const response = axios.post('http://localhost:55203/Visitantes',
            JSON.stringify(new data(this.state.contato)), config
          )
          .then(res => {
              this.setState({ resultMessage: 'E-mail enviado com sucesso' })
          })
          .catch(error => {
              this.setState({ resultMessage: error.response.data})
          });

      localStorage.setItem('@Rastreador:email', this.state.contato);

      e.preventDefault();
    }

    handleTextChange(e){
      this.setState({ contato: e.target.value })
    }

    render() {
      return (
        <div>
            <h2>Contato</h2>
            <form onSubmit={this.Enviar}>
                <input onChange={this.handleTextChange}/>
                <button type="submit">Enviar</button> 
            </form>
            { !!this.state.resultMessage && <label>{ this.state.resultMessage }</label>}
            </div>
      );
    }
  }