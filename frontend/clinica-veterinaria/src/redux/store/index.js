import { combineReducers, configureStore } from "@reduxjs/toolkit";
import animaleSmarritoReducer from "../reducers/animaleSmarritoReducer.js";
import animaleReducer from "../reducers/animaleReducer.js";

const mainReducer = combineReducers({
  animaleSmarrito: animaleSmarritoReducer,
  animale: animaleReducer,
});

const store = configureStore({
  reducer: mainReducer,
});

export default store;
