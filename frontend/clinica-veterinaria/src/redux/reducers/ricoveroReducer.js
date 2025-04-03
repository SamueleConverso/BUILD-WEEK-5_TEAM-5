const initialState = {
    ricoveri: [],
    ricovero: null,
};

const ricoveroReducer = (state = initialState, action) => {
    switch (action.type) {
        case "GET_RICOVERI":
            return {
                ...state,
                ricoveri: action.payload,
            };

        case "GET_RICOVERO_BY_ID":
            return {
                ...state,
                ricovero: action.payload,
            };

        default:
            return state;
    }
};

export default ricoveroReducer;