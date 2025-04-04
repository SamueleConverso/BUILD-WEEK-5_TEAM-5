import React from "react";
import { Link } from "react-router-dom";
import { useDispatch } from "react-redux";
import { deleteAnimaleSmarrito } from "../redux/actions/animaleSmarrito";
import { useLocation } from "react-router-dom";

function AnimaleSmarritoCard({ animale }) {
  const dispatch = useDispatch();

  const location = useLocation();

  if (!animale) {
    return null;
  }
  const handleDelete = async () => {
    if (
      window.confirm(
        `Sei sicuro di voler eliminare l'animale "${animale.nome}"?`
      )
    ) {
      try {
        await dispatch(deleteAnimaleSmarrito(animale.animaleSmarritoId));
      } catch (error) {
        console.error("Errore durante l'eliminazione:", error);
        alert("Errore durante l'eliminazione dell'animale");
      }
    }
  };

  return (
    <div className="card">
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
        {location.pathname === "/clinica/animaliSmarriti" && (
          <div className="d-flex justify-content-between mt-2">
            <Link
              to={`/clinica/animaliSmarriti/${animale.animaleSmarritoId}`}
              className="btn btn-primary"
            >
              Dettagli
            </Link>
            <Link
              to={`/clinica/modificaAnimaliSmarriti/${animale.animaleSmarritoId}`}
              className="btn btn-warning"
            >
              Modifica
            </Link>
            <button className="btn btn-danger" onClick={handleDelete}>
              Elimina
            </button>
          </div>
        )}
      </div>
    </div>
  );
}

export default AnimaleSmarritoCard;
