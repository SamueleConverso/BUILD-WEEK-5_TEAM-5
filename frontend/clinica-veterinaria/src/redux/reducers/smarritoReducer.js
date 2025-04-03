const initialState = {
  animaliSmarriti: [],
  animaleSelezionato: null,
  loading: false,
  error: null,
  success: false,
};

const smarritoReducer = (state = initialState, action) => {
  switch (action.type) {
    case "GET_ANIMALI_SMARRITI_REQUEST":
      return {
        ...state,
        loading: true,
        error: null,
      };

    case "GET_ANIMALI_SMARRITI_SUCCESS":
      return {
        ...state,
        loading: false,
        animaliSmarriti: action.payload,
        error: null,
      };

    case "GET_ANIMALE_SMARRITO_BY_ID_REQUEST":
      return {
        ...state,
        loading: true,
        error: null,
      };

    case "GET_ANIMALE_SMARRITO_BY_ID_SUCCESS":
      return {
        ...state,
        loading: false,
        animaleSelezionato: action.payload,
        error: null,
      };

    default:
      return state;
  }
};

export default smarritoReducer;
