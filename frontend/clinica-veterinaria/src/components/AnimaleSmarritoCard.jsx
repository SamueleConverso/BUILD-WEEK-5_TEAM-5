import React from 'react';
import { Link } from "react-router-dom";

function AnimaleSmarritoCard({ animale }) {
  if (!animale) {
    return null;
  }
  
  return (
    <div className="card" style={{ width: "100%" }}>
      <img
        src="https://placedog.net/300/300"
        className="card-img-top"
        alt={animale.nome}
      />
      <div className="card-body">
        <h5 className="card-title">{animale.nome}</h5>
        <p className="card-text">
          {animale.specie} - {animale.colore}
        </p>
        <p className="card-text">
          {animale.microchip 
            ? `Microchip: ${animale.numeroMicrochip || "N/A"}` 
            : "Senza microchip"}
        </p>
        <div className="d-flex justify-content-between">
          <Link
            to={`/clinica/animaliSmarriti/${animale.animaleSmarritoId}`}
            className="btn btn-primary btn-sm"
          >
            Dettagli
          </Link>
          <Link 
            to={`/animali-smarriti/modifica/${animale.animaleSmarritoId}`}
            className="btn btn-warning btn-sm"
          >
            Modifica
          </Link>
          <Link 
            to={`/animali-smarriti/elimina/${animale.animaleSmarritoId}`}
            className="btn btn-danger btn-sm"
          >
            Elimina
          </Link>
        </div>
      </div>
    </div>
  );
}

export default AnimaleSmarritoCard;