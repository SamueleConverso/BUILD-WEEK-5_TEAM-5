import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createAnimaleSmarritoAPI } from "../redux/actions/animaleSmarrito";
import FormAnimaleSmarrito from "./FormAnimaleSmarrito";

const CreaAnimaleSmarrito = () => {
  const dispatch = useDispatch();
  const { loading, success } = useSelector((state) => state.animaleSmarrito);
  const [error, setError] = useState(null);

  if (success) {
    setTimeout(() => {
      window.location.href = "/animali-smarriti";
    }, 2000);
  }

  const handleSubmit = (animaleSmarritoData) => {
    try {
      console.log("Invio form con dati:", animaleSmarritoData);
      dispatch(createAnimaleSmarritoAPI(animaleSmarritoData));
      setError(null);
    } catch (err) {
      console.error("Errore form submit:", err);
      setError(
        "Errore durante la creazione: " + (err.message || "Riprova più tardi")
      );
    }
  };

  return (
    <div className="container-fluid d-flex justify-content-center">
      {success && (
        <div className="alert alert-success">
          Animale smarrito registrato con successo! Verrai reindirizzato alla
          lista.
        </div>
      )}

      {error && <div className="alert alert-danger">{error}</div>}

      <FormAnimaleSmarrito onSubmit={handleSubmit} isLoading={loading} />
    </div>
  );
};

export default CreaAnimaleSmarrito;
