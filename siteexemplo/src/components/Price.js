import React, { Component } from 'react';
import Traker from './Tracker'

export default class Price extends Component {
    render() {
      return (
        <div class="container" style={{ paddingTop: '50px'}}>
        <h1 class="my-4">Price</h1>
         <Traker />
        </div>
      );
    }
  }