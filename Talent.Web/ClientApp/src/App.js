import React from 'react';
import AppBar from './views/components/AppBar/AppBar';
import styled from 'styled-components';
import { Route, Switch } from 'react-router-dom';
import Register from './views/components/auth/Register';
import Login from './views/components/auth/Login';
import Home from './views/pages/Home/Home';
import Page404 from './views/pages/Result/Page404';
// import Landing from './views/components/layout/Lading';
// import './App.css';

const App = () => {
  return (
    <Container>
      <AppBar />
      <Switch>
        <Route exact path="/" component={Home} />
        <Route exact path="/register" component={Register} />
        <Route exact path="/login" component={Login} />
        <Route component={Page404} />
      </Switch>
    </Container>
  );
};

const Container = styled.div`
  height: 70px;
  border-bottom: 1px solid #ddd;
`;

export default App;
