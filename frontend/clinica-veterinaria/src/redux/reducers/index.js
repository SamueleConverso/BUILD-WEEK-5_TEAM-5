const initialState = {
  isLoginError: "",
  isRegisterError: "",
  animali: [],
  animale: null,
};

const mainReducer = (state = initialState, action) => {
  switch (action.type) {
    case "LOGIN_ERROR":
      return {
        ...state,
        isLoginError: action.payload,
      };
    case "REGISTER_ERROR":
      return {
        ...state,
        isRegisterError: action.payload,
      };
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
