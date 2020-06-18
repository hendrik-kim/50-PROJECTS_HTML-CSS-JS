import React, { useState, useEffect } from "react";
import styled from "styled-components";
import NavBar from "./Navbar";
import { Link } from "react-router-dom";

function AppBar(props) {
  const { handlePopup } = props;
  return (
    <Container>
      <Logo to={"/"}>logo</Logo>
      <NavBar handlePopup={handlePopup} />
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

const Logo = styled(Link)`
  display: flex;
  align-items: center;
  font-size: 22px;
  text-transform: uppercase;
  cursor: pointer;
  color: #333;
  &:hover {
    color: #3c9afd;
  }
`;

export default AppBar;
