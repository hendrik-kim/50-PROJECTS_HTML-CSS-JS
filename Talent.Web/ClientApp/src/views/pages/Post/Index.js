import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { Route, Switch } from 'react-router-dom';
import List from './List';
import Detail from './Detail';
import Write from './Write';
import Modify from './Modify';

function Post(props) {
  const {} = props;

  useEffect(() => {
    console.log('@@ change popup state');
    return () => {
      console.log('@@ Leave post page');
    };
  }, []);

  return (
    <Container>
      <Switch>
        <Route exact path={'/post'} component={List} />
        <Route path={'/post/detail/:id'} component={Detail} />
        <Route path={'/post/write'} component={Write} />
        <Route path={'/post/modify'} component={Modify} />
      </Switch>
    </Container>
  );
}

const Container = styled.div``;

export default Post;
