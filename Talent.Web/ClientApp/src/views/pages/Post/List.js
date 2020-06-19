import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { Link } from 'react-router-dom';

function List(props) {
  const {} = props;

  useEffect(() => {}, []);

  return (
    <Container>
      <PostItem>
        <Link to={'/post/detail/post1'}>
          <h1>Lorem ipsum dolor sit amet.</h1>
        </Link>
      </PostItem>
      <PostItem>
        <Link to={'/post/detail/post2'}>
          <h1>Lorem ipsum dolor sit amet.</h1>
        </Link>
      </PostItem>
      <PostItem>
        <Link to={'/post/detail/post3'}>
          <h1>Lorem ipsum dolor sit amet.</h1>
        </Link>
      </PostItem>
    </Container>
  );
}

const Container = styled.div``;

const PostItem = styled.div``;

export default List;
