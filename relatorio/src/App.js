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
        const response = axios.get('http://localhost:55203/Visitantes')
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
      <div className="App">
        <header className="App-header">
          <h1 className="App-title">Relatório de acesso</h1>
        </header>
        { !!this.state.errorMessage && <label>{ this.state.errorMessage }</label>}
        <ul>
          { this.state.visitantes.map((visitante) =>{
            return <Pages id={visitante.id} text={visitante.email} />
          })}
        </ul>
      </div>
    );
  }
}

export default App;
