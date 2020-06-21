import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import NavBar from './Navbar';
import { Link } from 'react-router-dom';

function AppBar(props) {
  const { handlePopup } = props;
  return (
    <Container>
      <Logo to={'/'}>
        <span className="text-primary">
          <i className="fas fa-handshake"></i> Talent
        </span>
        Exchange
      </Logo>
      <NavBar handlePopup={handlePopup} />
    </Container>
  );
}

const Container = styled.div`
  background: #fff;
  height: 70px;
  border-bottom: 1px solid #ddd;
  display: flex;
  justify-content: space-between;
  padding: 0 50px;
`;

const Logo = styled(Link)`
  display: flex;
  align-items: center;
  font-size: 22px;
  cursor: pointer;
  color: #333;
  &-text-primary {
    color: #28a745;
  }
  &:hover {
    transition-duration: 0.3s;
    color: #28a745;
  }
`;

export default AppBar;
