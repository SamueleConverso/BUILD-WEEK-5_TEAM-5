const initialState = {
  isLoginError: "",
  isRegisterError: ""
};

const mainReducer = (state = initialState, action) => {
  switch (action.type) {
    case "LOGIN_ERROR":
      return (
        {
          ...state, isLoginError: action.payload
        });

    case "REGISTER_ERROR":
      return (
        {
          ...state, isRegisterError: action.payload
        });
    default:
      return state;
  }
};

export default mainReducer;
