import React, { useState, useEffect } from 'react';
import { Route, Switch } from 'react-router-dom';
import { Action } from './redux/app/redux';
import { useDispatch, useSelector } from 'react-redux';

import AppBar from './views/components/AppBar/Index';
import styled from 'styled-components';
import Register from './views/components/auth/Register';
import Login from './views/components/auth/Login';
import Home from './views/pages/Home/Index';
import Page404 from './views/pages/Result/Page404';
import Post from './views/pages/Post/Index';
import Popup from './views/components/Popup/Index';
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
      <Switch>
        <Route exact path="/" component={Home} />
        <Route exact path="/register" component={Register} />
        <Route exact path="/login" component={Login} />
        <Route path="/post" component={Post} />

        <Route component={Page404} />
      </Switch>

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
