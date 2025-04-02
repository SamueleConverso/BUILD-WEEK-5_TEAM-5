import { combineReducers, configureStore } from '@reduxjs/toolkit';
import animaleSmarritoReducer from '../reducers/animaleSmarritoReducer';

const mainReducer = combineReducers({
  animaleSmarrito: animaleSmarritoReducer
});


const store = configureStore({
  reducer: mainReducer,
});

export default store;