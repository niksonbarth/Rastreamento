import React, { Component } from 'react';
import axios from 'axios';
import Traker from './Tracker'

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
        <div class="container" style={{ paddingTop: '50px'}}>
            <h1 class="my-4">Contato</h1>
            { !!this.state.resultMessage && <div class="alert alert-info">{ this.state.resultMessage }</div>}
            <form onSubmit={this.Enviar}>
                <input class="form-control" placeholder="E-mail" onChange={this.handleTextChange}/>
                <br/>
                <button type="submit" class="btn btn-default">Enviar</button> 
            </form>
            <Traker />
        </div>
      );
    }
  }