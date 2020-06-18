import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import NavBar from './Navbar';

function AppBar(props) {
  const {} = props;
  return (
    <Container>
      <Logo>logo</Logo>
      <NavBar />
    </Container>
  );
}

const Container = styled.div`
  height: 70px;
  border-bottom: 1px solid #ddd;
  display: flex;
  justify-content: space-between;
  padding: 0 50px;
`;

const Logo = styled.div`
  display: flex;
  align-items: center;
  font-size: 22px;
  text-transform: uppercase;
  cursor: pointer;
`;

export default AppBar;
