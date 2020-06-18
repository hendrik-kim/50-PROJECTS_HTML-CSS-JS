import React, { useState, useEffect } from 'react';
// import { Link } from 'react-router-dom';
import styled from 'styled-components';

function NavBar(props) {
  const {} = props;
  return (
    <Container>
      <NavItem>sign Up</NavItem>
      <NavItem>sign In</NavItem>
      {/* <div>
        <nav className="navbar bg-dark">
          <h1>
            <Link to="/">
              <i className="fas fa-code"></i> Home
            </Link>
          </h1>
          <ul>
            <li>
              <Link to="/register">Register</Link>
            </li>
            <li>
              <Link to="/login">Login</Link>
            </li>
          </ul>
        </nav>
      </div> */}
    </Container>
  );
}

const Container = styled.div`
  display: flex;
`;

const NavItem = styled.div`
  height: 70px;
  display: flex;
  align-items: center;
  padding: 0 10px;
  text-transform: capitalize;
  cursor: pointer;
`;

export default NavBar;
