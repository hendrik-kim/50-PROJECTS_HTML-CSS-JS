import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { Link } from 'react-router-dom';

function List(props) {
  const {} = props;

  useEffect(() => {}, []);

  return (
    <Container>
      <div className="container-card">
        <div className="card">
          <div className="card-category">Card Categ</div>
          <div className="card-title">Card Title</div>
          <div className="card-client">Client Name</div>
          <div className="card-content">Card Content</div>
          <div className="card-location">Card Location</div>
          <div className="card-tags">Card Tags</div>
          <div className="card-createOn">2020-06-20</div>
          <div className="card-view">12 view</div>
        </div>
        <div className="card">
          <div className="card-category">Card Categ</div>
          <div className="card-title">Card Title</div>
          <div className="card-client">Client Name</div>
          <div className="card-content">Card Content</div>
          <div className="card-location">Card Location</div>
          <div className="card-tags">Card Tags</div>
          <div className="card-createOn">2020-06-20</div>
          <div className="card-view">12 view</div>
        </div>
        <div className="card">
          <div className="card-category">Card Categ</div>
          <div className="card-title">Card Title</div>
          <div className="card-client">Client Name</div>
          <div className="card-content">Card Content</div>
          <div className="card-location">Card Location</div>
          <div className="card-tags">Card Tags</div>
          <div className="card-createOn">2020-06-20</div>
          <div className="card-view">12 view</div>
        </div>
        <div className="card">
          <div className="card-category">Card Categ</div>
          <div className="card-title">Card Title</div>
          <div className="card-client">Client Name</div>
          <div className="card-content">Card Content</div>
          <div className="card-location">Card Location</div>
          <div className="card-tags">Card Tags</div>
          <div className="card-createOn">2020-06-20</div>
          <div className="card-view">12 view</div>
        </div>
        <div className="card">
          <div className="card-category">Card Categ</div>
          <div className="card-title">Card Title</div>
          <div className="card-client">Client Name</div>
          <div className="card-content">Card Content</div>
          <div className="card-location">Card Location</div>
          <div className="card-tags">Card Tags</div>
          <div className="card-createOn">2020-06-20</div>
          <div className="card-view">12 view</div>
        </div>
        <div className="card">
          <div className="card-category">Card Categ</div>
          <div className="card-title">Card Title</div>
          <div className="card-client">Client Name</div>
          <div className="card-content">Card Content</div>
          <div className="card-location">Card Location</div>
          <div className="card-tags">Card Tags</div>
          <div className="card-createOn">2020-06-20</div>
          <div className="card-view">12 view</div>
        </div>
        <div className="card">
          <div className="card-category">Card Categ</div>
          <div className="card-title">Card Title</div>
          <div className="card-client">Client Name</div>
          <div className="card-content">Card Content</div>
          <div className="card-location">Card Location</div>
          <div className="card-tags">Card Tags</div>
          <div className="card-createOn">2020-06-20</div>
          <div className="card-view">12 view</div>
        </div>
      </div>
      {/* <PostItem>
        <Link to={'/post/detail/post1'}>
          <h1>Lorem ipsum dolor sit amet.</h1>
        </Link>
      </PostItem>
      <PostItem>
        <Link to={'/post/detail/post2'}>
          <h1>Lorem ipsum dolor sit amet.</h1>
        </Link>
      </PostItem>
      <PostItem>
        <Link to={'/post/detail/post3'}>
          <h1>Lorem ipsum dolor sit amet.</h1>
        </Link>
      </PostItem> */}
    </Container>
  );
}

const Container = styled.div`
  .container-card {
    display: flex;
    flex-wrap: wrap;
    padding: 20px;
    justify-content: center;
  }

  .card {
    flex-grow: 1;
    flex-basis: 33.333333%;
    max-width: 350px;
    border: 1px solid #dadada;
    border-radius: 4px;
    padding: 15px 20px;
    margin: 15px;
    background-color: #fff;
    text-align: left;
    cursor: pointer;
    * {
      margin-bottom: 10px;
    }
    &-category {
      margin: 10px 0;
      text-align: right;
    }

    &-title {
      font-size: 20px;
      font-weight: 600;
    }

    &-client {
      color: #909090;
    }

    &-location {
      color: #909090;
    }
    &-createOn {
      margin-top: 15px;
      font-size: 13px;
      color: #909090;
    }
    &-view {
      font-size: 13px;
      color: #909090;
    }

    &:hover {
      transform: translateY(-1px);
      box-shadow: 1px 4px 10px 1px rgba(0, 0, 0, 0.2);
      transition-duration: 0.2s;
    }

    @media screen and (max-width: 950px) {
      margin-right: 0;
      width: 100%;
    }
  }
`;

const PostItem = styled.div``;

export default List;
