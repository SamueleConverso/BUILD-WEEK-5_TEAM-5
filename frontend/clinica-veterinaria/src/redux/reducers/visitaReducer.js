const initialState = {
  visite: [],
};

const visitaReducer = (state = initialState, action) => {
  switch (action.type) {
    case "GET_VISITE":
      return {
        ...state,
        visite: action.payload,
      };
    default:
      return state;
  }
};

export default visitaReducer;
