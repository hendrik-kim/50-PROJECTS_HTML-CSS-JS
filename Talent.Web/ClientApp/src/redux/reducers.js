import { combineReducers } from 'redux';
import appReducer from './app/redux';
import userReducer from './user/redux';
import postReducer from './post/redux';

const reducers = combineReducers({
  app: appReducer,
  user: userReducer,
  post: postReducer,
});

export default reducers;
