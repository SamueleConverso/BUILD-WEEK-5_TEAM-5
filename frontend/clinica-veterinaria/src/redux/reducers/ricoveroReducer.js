const initialState = {
    ricoveri: [],
};

const ricoveroReducer = (state = initialState, action) => {
    switch (action.type) {
        case "GET_RICOVERI":
            return {
                ...state,
                ricoveri: action.payload,
            };
        default:
            return state;
    }
};

export default ricoveroReducer;