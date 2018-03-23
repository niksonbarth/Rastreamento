import React from 'react';
import ReactDOM from 'react-dom';
import App from './components/app';
import Api from './services/api';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();
