import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { Link } from "react-router-dom";

function NavBar(props) {
  const { handlePopup } = props;
  return (
    <Container>
      <div
        onClick={() => {
          handlePopup((v) => !v);
        }}
      >
        Popup
      </div>
      <NavItem to={"/register"}>sign Up</NavItem>
      <NavItem to={"/login"}>sign In</NavItem>
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
    color: #3c9afd;
  }
`;

export default NavBar;
