import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';

function List(props) {
    const {} = props;
    return <Container > 
        <PostItem>
            <Link to={"/post/detail/post1"}>
                <h1>Lorem ipsum dolor sit amet.</h1>
            </Link>
        </PostItem> 
        </Container>;
}

const Container = styled.div ``;

const PostItem = styled.div ``;

export default List;