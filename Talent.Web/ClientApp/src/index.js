import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './scss/style.scss';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import store from './redux/store';
// import 'bootstrap/dist/css/bootstrap.css';

const state = store.getState();

store.dispatch({ type: '@@APP/UPDATE_STATE', props: {} });

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);
