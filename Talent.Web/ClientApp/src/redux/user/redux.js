const initialState = {
  isLoggedIn: false,
  info: null,
};

export const Action = {
  Types: {
    UPDATE_STATE: '@@USER/UPDATE_STATE',
  },

  Creators: {
    updateState: (props) => ({
      type: Action.Types.UPDATE_STATE,
      props,
    }),
  },
};

Action.Creators.updateState();

const reducer = (state = initialState, action) => {
  switch (action.type) {
    default:
      return state;
    case Action.Types.UPDATE_STATE: {
      return {
        ...state,
        ...action.props,
      };
    }
  }
};

export default { reducer, Action };
