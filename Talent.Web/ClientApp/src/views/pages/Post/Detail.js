import React, { useState, useEffect } from 'react';
import styled from 'styled-components';

function Detail(props) {
  const { match } = props;

  console.log('@@ props', props);

  const id = match.params.id;

  useEffect(() => {
    // 비동기 통신 id를 이용해서
  }, [match]);

  if (!id) {
    return 'loading...';
  }

  return <Container>{id}</Container>;
}

const Container = styled.div``;

export default Detail;
