import { bindActionCreators } from 'redux';
import store from './store';

import { Action as appAction } from './app/redux';
import { Action as postAction } from './post/redux';
import { Action as userAction } from './user/redux';

const { dispatch } = store;

export const appActions = bindActionCreators(appAction, dispatch);
export const postActions = bindActionCreators(postAction, dispatch);
export const userActions = bindActionCreators(userAction, dispatch);
