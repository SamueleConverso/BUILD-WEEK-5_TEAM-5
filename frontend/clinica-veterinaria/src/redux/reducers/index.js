const initialState = {
  animali: [],
  animale: null,
};

const mainReducer = (state = initialState, action) => {
  switch (action.type) {
    case "GET_ANIMALI":
      return {
        ...state,
        animali: action.payload,
      };
    case "GET_ANIMALE_BY_ID":
      return {
        ...state,
        animale: action.payload,
      };
    default:
      return state;
  }
};

export default mainReducer;
