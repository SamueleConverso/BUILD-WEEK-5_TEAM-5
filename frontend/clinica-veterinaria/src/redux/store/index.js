import { combineReducers, configureStore } from "@reduxjs/toolkit";
import animaleSmarritoReducer from "../reducers/animaleSmarritoReducer.js";
import animaleReducer from "../reducers/animaleReducer.js";
import SmarritiReducer from "../reducers/SmarritiReducer.js";
import ricoveroReducer from "../reducers/ricoveroReducer.js";

const mainReducer = combineReducers({
  animaleSmarrito: animaleSmarritoReducer,
  animale: animaleReducer,
  animaliSmarriti: SmarritiReducer,
  ricoveri: ricoveroReducer
});

const store = configureStore({
  reducer: mainReducer,
});

export default store;
