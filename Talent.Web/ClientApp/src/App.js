import React, { useState, useEffect } from 'react';
import { Route, Switch } from 'react-router-dom';
import { Action } from './redux/app/redux';
import { useDispatch, useSelector } from 'react-redux';

import AppBar from './views/components/appBar/Index';
import styled from 'styled-components';
import Register from './views/pages/auth/Register';
import Login from './views/pages/auth/Login';
import Home from './views/pages/home/Index';
import Page404 from './views/pages/result/Page404';
import Post from './views/pages/post/Index';
import Popup from './views/components/popup/Index';
// import Landing from './views/components/layout/Lading';
// import './App.css';

function App() {
  const dispatch = useDispatch();
  const app = useSelector((state) => state.app);

  const [showPopup, handlePopup] = useState(false);

  console.log('@@ app', app);

  return (
    <Container>
      <AppBar handlePopup={handlePopup} />
      <section className="container">
        <Switch>
          <Route exact path="/" component={Home} />
          <Route exact path="/register" component={Register} />
          <Route exact path="/login" component={Login} />
          <Route path="/post" component={Post} />

          <Route component={Page404} />
        </Switch>
      </section>

      {showPopup && <Popup onClose={() => handlePopup(false)} />}

      {app.popup.title && (
        <Popup
          onClose={() =>
            dispatch(
              Action.Creator.updateState({
                popup: {
                  title: '',
                },
              })
            )
          }
          title={app.popup.title}
        />
      )}
    </Container>
  );
}

const Container = styled.div`
  height: 70px;
  border-bottom: 1px solid #ddd;
`;

export default App;
