import { combineReducers, configureStore } from "@reduxjs/toolkit";
import animaleSmarritoReducer from "../reducers/animaleSmarritoReducer.js";
import animaleReducer from "../reducers/animaleReducer.js";
import ricoveroReducer from "../reducers/ricoveroReducer.js";
import smarritoReducer from "../reducers/smarritoReducer.js";
import visitaReducer from "../reducers/visitaReducer.js";

const mainReducer = combineReducers({
  animaleSmarrito: animaleSmarritoReducer,
  animale: animaleReducer,
  ricoveri: ricoveroReducer,
  animaliSmarriti: smarritoReducer,
  visita: visitaReducer,
});

const store = configureStore({
  reducer: mainReducer,
});

export default store;
