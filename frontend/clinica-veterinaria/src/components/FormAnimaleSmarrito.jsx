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
    <div className="mb-4 containerLogin">
      <h5 className="heading">Registrazione animale smarrito</h5>
      <div className="card-body">
        <form
          className="formLogin"
          onSubmit={(e) => {
            e.preventDefault();
            handleSubmit();
          }}
        >
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
              className=" d-none"
              checked={microchip}
              onChange={(e) => setMicrochip(e.target.checked)}
            />
            <label for="cbx" className="d-flex align-items-center check">
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
              disabled={isLoading}
            >
              {isLoading ? "Caricamento..." : "Registra"}
            </button>
            <a
              href="/animali-smarriti"
              className="btn btn-secondary annulla-button"
            >
              Annulla
            </a>
          </div>
        </form>
      </div>
    </div>
  );
};

export default FormAnimaleSmarrito;
