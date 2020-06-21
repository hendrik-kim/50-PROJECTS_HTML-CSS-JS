import React from 'react';
import styled from 'styled-components';
import PostList from '../post/List';

function Home() {
  return (
    <Container>
      <PostList />
    </Container>
  );
}

const Container = styled.div``;

export default Home;
