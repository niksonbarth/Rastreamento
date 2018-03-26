import React from 'react';
import Traker from './Tracker'

export default class Home extends React.Component {

    render() {
      return (
        <div class="container" style={{ paddingTop: '50px'}}>
          <h1 class="my-4">Home</h1>
          <Traker />
        </div>
      );
    }
  }
