import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { createAnimaleSmarritoAPI } from "../redux/actions/animaleSmarrito.js";

const FormAnimaleSmarrito = ({ isLoading }) => {
  const [nome, setNome] = useState("");
  const [specie, setSpecie] = useState("");
  const [colore, setColore] = useState("");
  const [microchip, setMicrochip] = useState(false);
  const [numeroMicrochip, setNumeroMicrochip] = useState(0);
  const dispatch = useDispatch();

  const handleSubmit = () => {
    if (!nome || !specie || !colore) {
      alert("I campi Nome, Specie e Colore sono obbligatori");
      return;
    }

    dispatch(
      createAnimaleSmarritoAPI(nome, specie, colore, microchip, numeroMicrochip)
    );

    // const formData = {
    //   nome,
    //   specie,
    //   colore,
    //   microchip,
    //   numeroMicrochip:
    //     microchip && numeroMicrochip ? parseInt(numeroMicrochip) : null,
    // };

    // console.log("Dati inviati:", formData);

    // onSubmit(formData);
  };

  return (
    <div className="card mb-4">
      <div className="card-header">
        <h5>Registra Nuovo Animale Smarrito</h5>
      </div>
      <div className="card-body">
        <form
          onSubmit={(e) => {
            e.preventDefault();
            handleSubmit();
          }}
        >
          <div className="mb-3">
            <label htmlFor="nome" className="form-label">
              Nome
            </label>
            <input
              type="text"
              className="form-control"
              id="nome"
              value={nome}
              onChange={(e) => setNome(e.target.value)}
              placeholder="Inserisci il nome dell'animale"
            />
          </div>

          <div className="mb-3">
            <label htmlFor="specie" className="form-label">
              Specie
            </label>
            <input
              type="text"
              className="form-control"
              id="specie"
              value={specie}
              onChange={(e) => setSpecie(e.target.value)}
              placeholder="Inserisci la specie (es. Cane, Gatto)"
            />
          </div>

          <div className="mb-3">
            <label htmlFor="colore" className="form-label">
              Colore
            </label>
            <input
              type="text"
              className="form-control"
              id="colore"
              value={colore}
              onChange={(e) => setColore(e.target.value)}
              placeholder="Inserisci il colore dell'animale"
            />
          </div>

          <div className="mb-3 form-check">
            <input
              type="checkbox"
              className="form-check-input"
              id="microchip"
              checked={microchip}
              onChange={(e) => setMicrochip(e.target.checked)}
            />
            <label className="form-check-label" htmlFor="microchip">
              Microchip
            </label>
          </div>

          {microchip && (
            <div className="mb-3">
              <label htmlFor="numeroMicrochip" className="form-label">
                Numero Microchip
              </label>
              <input
                type="number"
                className="form-control"
                id="numeroMicrochip"
                value={numeroMicrochip}
                onChange={(e) => setNumeroMicrochip(e.target.value)}
                placeholder="Inserisci il numero del microchip"
              />
            </div>
          )}

          <div className="d-flex gap-2">
            <button
              type="submit"
              className="btn btn-primary"
              disabled={isLoading}
            >
              {isLoading ? "Caricamento..." : "Registra"}
            </button>
            <a href="/animali-smarriti" className="btn btn-secondary">
              Annulla
            </a>
          </div>
        </form>
      </div>
    </div>
  );
};

export default FormAnimaleSmarrito;
