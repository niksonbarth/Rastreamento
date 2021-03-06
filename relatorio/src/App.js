import React, { Component } from 'react';
import axios from 'axios';

import Pages from './Pages';

class App extends Component {
  state = {
    errorMessage: null,
    visitantes: []
  }

  componentDidMount(){
      try{
        const response = axios.get('https://webrastreamentoapi.azurewebsites.net/Visitantes')
        .then(res => {
            this.setState({ visitantes: res.data})
        });
      }catch(response){
          this.setState({ errorMessage: response.data.errorMessage })
      }
  }

  render() {
    //window.onload = this.buscar
    return (
      <div class="panel-body">
        <header className="App-header">
          <h1 className="App-title">Relatório de acesso</h1>
        </header>
        { !!this.state.errorMessage && <label>{ this.state.errorMessage }</label>}
        <ul>
          { this.state.visitantes.map((visitante) =>{
            return <Pages id={visitante.email} text={visitante.email} />
          })}
        </ul>
      </div>
    );
  }
}

export default App;
