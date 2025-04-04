import React, { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useParams, useNavigate } from "react-router-dom";
import {
  createAnimaleSmarritoAPI,
  updateAnimaleSmarritoAPI,
  getAnimaleSmarritoById,
} from "../redux/actions/animaleSmarrito.js";

const FormAnimaleSmarrito = ({ isEdit = false }) => {
  const { id } = useParams();
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { animaleSelezionato, loading, success, error } = useSelector(
    (state) => state.animaliSmarriti || {}
  );

  const [nome, setNome] = useState("");
  const [specie, setSpecie] = useState("");
  const [colore, setColore] = useState("");
  const [microchip, setMicrochip] = useState(false);
  const [numeroMicrochip, setNumeroMicrochip] = useState(0);
  const [formSubmitted, setFormSubmitted] = useState(false);

  useEffect(() => {
    if (isEdit && id) {
      dispatch(getAnimaleSmarritoById(id));
    }
  }, [isEdit, id, dispatch]);

  useEffect(() => {
    if (isEdit && animaleSelezionato) {
      setNome(animaleSelezionato.nome || "");
      setSpecie(animaleSelezionato.specie || "");
      setColore(animaleSelezionato.colore || "");
      setMicrochip(animaleSelezionato.microchip || false);
      setNumeroMicrochip(animaleSelezionato.numeroMicrochip || 0);
    }
  }, [isEdit, animaleSelezionato]);

  useEffect(() => {
    if (success && formSubmitted) {
      const timer = setTimeout(() => {
        navigate("/clinica/animaliSmarriti");
      }, 2000);

      return () => clearTimeout(timer);
    }
  }, [success, formSubmitted, navigate]);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!nome || !specie || !colore) {
      alert("I campi Nome, Specie e Colore sono obbligatori");
      return;
    }

    setFormSubmitted(true);

    if (isEdit && id) {
      dispatch(
        updateAnimaleSmarritoAPI(
          id,
          nome,
          specie,
          colore,
          microchip,
          numeroMicrochip
        )
      );
    } else {
      dispatch(
        createAnimaleSmarritoAPI(
          nome,
          specie,
          colore,
          microchip,
          numeroMicrochip
        )
      );
    }
  };

  return (
    <div className="container-fluid d-flex flex-column mb-5 align-items-center">
      <div className="containerLogin containerAnimali">
        <h5 className="heading">
          {isEdit
            ? "Modifica animale smarrito"
            : "Registrazione animale smarrito"}
        </h5>

        {error && <div className="alert alert-danger">{error}</div>}

        <div className="card-body">
          <form className="formLogin" onSubmit={handleSubmit}>
            <input
              type="text"
              className="form-control inputLogin"
              id="nome"
              value={nome}
              onChange={(e) => setNome(e.target.value)}
              placeholder="Nome animale"
            />

            <input
              type="text"
              className="form-control inputLogin"
              id="specie"
              value={specie}
              onChange={(e) => setSpecie(e.target.value)}
              placeholder="Specie (es. Cane, Gatto)"
            />

            <input
              type="text"
              className="form-control inputLogin"
              id="colore"
              value={colore}
              onChange={(e) => setColore(e.target.value)}
              placeholder="Colore animale"
            />

            <div className="ps-3 d-flex align-items-center inputLogin">
              <input
                type="checkbox"
                id="cbx"
                className="d-none"
                checked={microchip}
                onChange={(e) => setMicrochip(e.target.checked)}
              />
              <label htmlFor="cbx" className="d-flex align-items-center check">
                <svg width="18px" height="18px" viewBox="0 0 18 18">
                  <path d="M1,9 L1,3.5 C1,2 2,1 3.5,1 L14.5,1 C16,1 17,2 17,3.5 L17,14.5 C17,16 16,17 14.5,17 L3.5,17 C2,17 1,16 1,14.5 L1,9 Z"></path>
                  <polyline points="1 9 7 14 15 4"></polyline>
                </svg>
              </label>
              <p className="ps-2" id="microchip">
                Microchip
              </p>
            </div>

            {microchip && (
              <>
                <input
                  type="number"
                  className="form-control inputLogin"
                  id="numeroMicrochip"
                  value={numeroMicrochip}
                  onChange={(e) => setNumeroMicrochip(e.target.value)}
                  placeholder="Numero microchip"
                />
              </>
            )}

            <div>
              <button
                type="submit"
                className="btn login-button"
                disabled={loading}
              >
                {loading
                  ? "Caricamento..."
                  : isEdit
                  ? "Modifica animale"
                  : "Registra"}
              </button>

              <a
                href="/clinica/animaliSmarriti"
                className="btn btn-secondary annulla-button"
              >
                Annulla
              </a>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default FormAnimaleSmarrito;
