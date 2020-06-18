import React, { useState, useEffect } from "react";
import styled from "styled-components";

function Detail(props) {
  const { match } = props;

  console.log("@@ props", props);

  const id = match.params.id;

  // useEffect(() => {
  //   // async communication
  //   }
  // }, [match])

  return <Container>{id}</Container>;
}

const Container = styled.div``;

export default Detail;
