import { combineReducers, configureStore } from "@reduxjs/toolkit";
import animaleSmarritoReducer from "../reducers/animaleSmarritoReducer.js";
import animaleReducer from "../reducers/animaleReducer.js";
import SmarritiReducer from "../reducers/SmarritiReducer.js";

const mainReducer = combineReducers({
  animaleSmarrito: animaleSmarritoReducer,
  animale: animaleReducer,
  animaliSmarriti: SmarritiReducer,
});

const store = configureStore({
  reducer: mainReducer,
});

export default store;
