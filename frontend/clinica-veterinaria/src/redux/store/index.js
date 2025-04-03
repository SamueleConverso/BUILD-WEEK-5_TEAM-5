import { combineReducers, configureStore } from "@reduxjs/toolkit";
import animaleSmarritoReducer from "../reducers/animaleSmarritoReducer.js";
import animaleReducer from "../reducers/animaleReducer.js";
import smarritoReducer from "../reducers/smarritoReducer.js";

const mainReducer = combineReducers({
  animaleSmarrito: animaleSmarritoReducer,
  animale: animaleReducer,
  animaliSmarriti: smarritoReducer,
});

const store = configureStore({
  reducer: mainReducer,
});

export default store;
