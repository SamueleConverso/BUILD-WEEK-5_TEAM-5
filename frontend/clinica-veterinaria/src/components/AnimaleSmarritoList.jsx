/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { getAnimaliSmarriti } from "../redux/actions/animaleSmarrito";
import AnimaleSmarritoCard from "./AnimaleSmarritoCard";

function AnimaleSmarritoList() {
  const dispatch = useDispatch();

  const {
    animaliSmarriti = [],
    loading,
    error: reduxError,
  } = useSelector((state) => state.animaliSmarriti || {});
  const [error, setError] = useState(null);

  useEffect(() => {
    try {
      dispatch(getAnimaliSmarriti());
    } catch (err) {
      console.error("Errore recupero animali:", err);
      setError("Impossibile caricare la lista degli animali smarriti");
    }
  }, []);

  useEffect(() => {
    if (animaliSmarriti) {
      // animaliSmarriti.forEach((a) => {
      //   console.log(a.nome);
      //   console.log(a.animaleSmarritoId);
      // });
      console.log(animaliSmarriti);
    }
  }, [animaliSmarriti]);

  if (loading && (!animaliSmarriti || animaliSmarriti.length === 0)) {
    return (
      <div className="container text-center my-5">
        <div className="spinner-border" role="status">
          <span className="visually-hidden">Caricamento...</span>
        </div>
      </div>
    );
  }

  if (error || reduxError) {
    return (
      <div className="container my-5">
        <div className="alert alert-danger" role="alert">
          {error || reduxError}
        </div>
      </div>
    );
  }

  return (
    <div className="container my-5">
      <div className="d-flex justify-content-center align-items-center mb-4">
        <h2>Animali Smarriti</h2>
      </div>

      {!animaliSmarriti || animaliSmarriti.length === 0 ? (
        <div className="alert alert-info">
          Non ci sono animali smarriti registrati.
        </div>
      ) : (
        <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
          {animaliSmarriti.map((animale) => (
            <div
              className="col d-flex justify-content-center"
              key={animale.animaleSmarritoId}
            >
              <AnimaleSmarritoCard animale={animale} />
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default AnimaleSmarritoList;
