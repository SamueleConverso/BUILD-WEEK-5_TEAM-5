const initialState = {
    loading: false,
    success: false,
    error: null
  };
  
  const animaleSmarritoReducer = (state = initialState, action) => {
    switch (action.type) {
      case 'CREATE_ANIMALE_SMARRITO_REQUEST':
        return {
          ...state,
          loading: true,
          success: false,
          error: null
        };
        
      case 'CREATE_ANIMALE_SMARRITO_SUCCESS':
        return {
          ...state,
          loading: false,
          success: true,
          error: null
        };
        
      default:
        return state;
    }
  };
  
  export default animaleSmarritoReducer;