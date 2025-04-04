import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { createAnimaleSmarritoAPI } from "../redux/actions/animaleSmarrito";
import FormAnimaleSmarrito from "./FormAnimaleSmarrito";

const CreaAnimaleSmarrito = () => {
  const dispatch = useDispatch();
  const { loading } = useSelector((state) => state.animaleSmarrito);
  const [error, setError] = useState(null);

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
    <div className="container-fluid d-flex flex-column align-items-center justify-content-center">
      {error && <div className="alert alert-danger">{error}</div>}

      <FormAnimaleSmarrito onSubmit={handleSubmit} isLoading={loading} />
    </div>
  );
};

export default CreaAnimaleSmarrito;
