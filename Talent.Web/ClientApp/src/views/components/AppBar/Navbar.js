import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { Link } from 'react-router-dom';
import { appActions } from '../../../redux/createActions';

function NavBar(props) {
  const { handlePopup } = props;
  return (
    <Container>
      <NavItem to={'/register'}>sign Up</NavItem>
      <NavItem to={'/login'}>sign In</NavItem>
    </Container>
  );
}

const Container = styled.div`
  display: flex;
`;

const NavItem = styled(Link)`
  height: 70px;
  display: flex;
  align-items: center;
  padding: 0 10px;
  text-transform: capitalize;
  cursor: pointer;
  color: #333;
  &:hover {
    border-bottom: #28a745 2px solid;
    transition: 0.1s;
  }
`;

export default NavBar;
