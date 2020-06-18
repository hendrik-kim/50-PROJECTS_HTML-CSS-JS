import React, { useState, useEffect } from "react";
import styled from "styled-components";

function Popup(props) {
  const { onClose } = props;
  return (
    <Container onClick={onClose}>
      <Content>Pop-up</Content>
    </Container>
  );
}

const Container = styled.div`
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: 1000;
  background: rgba(0, 0, 0, 0.25);
  display: flex;
  align-items: center;
  justify-content: center;
`;

const Content = styled.div`
  width: 300px;
  height: 200px;
  background: #fff;
`;

export default Popup;
