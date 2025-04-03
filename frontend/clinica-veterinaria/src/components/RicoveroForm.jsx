/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect, useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { getAnimali } from "../redux/actions/animale.js";
import { getAnimaliSmarriti } from "../redux/actions/animaleSmarrito.js";
import { postRicovero } from "../redux/actions/ricovero.js";
import { useParams } from "react-router-dom";
import { getRicoveroById } from "../redux/actions/ricovero.js";
import { putRicovero } from "../redux/actions/ricovero.js";

const RicoveroForm = () => {
  const [inCorso, setInCorso] = useState(false);
  const [selectedOption, setSelectedOption] = useState("");
  const [descrizione, setDescrizione] = useState("");
  const [dataInizioRicovero, setDataInizioRicovero] = useState("");
  const [dataFineRicovero, setDataFineRicovero] = useState("");
  const [animaleId, setAnimaleId] = useState(0);
  const [animaleSmarritoId, setAnimaleSmarritoId] = useState(0);

  const dispatch = useDispatch();

  const animali = useSelector((state) => state.animale.animali);
  const animaliSmarriti = useSelector(
    (state) => state.animaliSmarriti.animaliSmarriti
  );
  const ricovero = useSelector((state) => state.ricovero.ricovero);

  const ricoveroId = useParams();

  useEffect(() => {
    if (ricoveroId) {
      dispatch(getRicoveroById(ricoveroId));
    }
    dispatch(getAnimali());
    dispatch(getAnimaliSmarriti());
  }, []);

  const handleSubmit = () => {
    let animaleIdToPass = null;
    let animaleSmarritoIdToPass = null;
    if (selectedOption === "animale") {
      animaleSmarritoIdToPass = null;
      animaleIdToPass = animaleId;
    } else {
      animaleIdToPass = null;
      animaleSmarritoIdToPass = animaleSmarritoId;
    }

    let dataFineRicoveroToPass = null;
    if (!inCorso) {
      dataFineRicoveroToPass = dataFineRicovero;
    } else {
      dataFineRicoveroToPass = null;
    }

    dispatch(
      postRicovero(
        descrizione,
        dataInizioRicovero,
        dataFineRicoveroToPass,
        animaleIdToPass,
        animaleSmarritoIdToPass
      )
    );

    setDescrizione("");
    setDataFineRicovero("");
    setDataInizioRicovero("");
    setAnimaleId("");
    setAnimaleSmarritoId("");
  };

  const handleUpdate = () => {
    let animaleIdToPass = null;
    let animaleSmarritoIdToPass = null;
    if (selectedOption === "animale") {
      animaleSmarritoIdToPass = null;
      animaleIdToPass = animaleId;
    } else {
      animaleIdToPass = null;
      animaleSmarritoIdToPass = animaleSmarritoId;
    }

    let dataFineRicoveroToPass = null;
    if (!inCorso) {
      dataFineRicoveroToPass = dataFineRicovero;
    } else {
      dataFineRicoveroToPass = null;
    }

    dispatch(
      putRicovero(
        ricoveroId,
        descrizione,
        dataInizioRicovero,
        dataFineRicoveroToPass,
        animaleIdToPass,
        animaleSmarritoIdToPass
      )
    );

    setDescrizione("");
    setDataFineRicovero("");
    setDataInizioRicovero("");
    setAnimaleId(0);
    setAnimaleSmarritoId(0);
  };

  return (
    <div className="container-fluid d-flex justify-content-center my-3">
      <div className="containerLogin containerAnimali">
        <h1 className="heading">Aggiungi un nuovo ricovero</h1>

        <Form
          className="formLogin"
          onSubmit={(e) => {
            e.preventDefault();
            if (ricoveroId) {
              handleUpdate();
            } else {
              handleSubmit();
            }
          }}
        >
          <Form.Control
            className="inputLogin"
            placeholder="Descrizione"
            type="text"
            value={ricovero.descrizione || descrizione}
            onChange={(e) => setDescrizione(e.target.value)}
          ></Form.Control>

          <Form.Label className="mt-2 mb-0 ps-2" id="microchip">
            Data inizio ricovero
          </Form.Label>
          <Form.Control
            className="inputLogin mt-0"
            type="date"
            value={ricovero.dataInizioRicovero || dataInizioRicovero}
            onChange={(e) => setDataInizioRicovero(e.target.value)}
          ></Form.Control>

          <div className="ps-3 d-flex align-items-center inputLogin">
            <input
              type="checkbox"
              id="cbx"
              className="d-none"
              checked={inCorso}
              onChange={(e) => setInCorso(e.target.checked)}
            />
            <label htmlFor="cbx" className="d-flex align-items-center check">
              <svg width="18px" height="18px" viewBox="0 0 18 18">
                <path d="M1,9 L1,3.5 C1,2 2,1 3.5,1 L14.5,1 C16,1 17,2 17,3.5 L17,14.5 C17,16 16,17 14.5,17 L3.5,17 C2,17 1,16 1,14.5 L1,9 Z"></path>
                <polyline points="1 9 7 14 15 4"></polyline>
              </svg>
            </label>
            <p className="ps-2" id="microchip">
              In corso
            </p>
          </div>
          {!inCorso && (
            <>
              {" "}
              <Form.Label className="mt-2 mb-0 ps-2" id="microchip">
                Data fine ricovero
              </Form.Label>
              <Form.Control
                className="inputLogin mt-0"
                type="date"
                value={ricovero.dataFineRicovero || dataFineRicovero}
                onChange={(e) => setDataFineRicovero(e.target.value)}
              ></Form.Control>
            </>
          )}

          <select
            id="tipoAnimale"
            className="inputLogin"
            value={selectedOption}
            onChange={(e) => setSelectedOption(e.target.value)}
          >
            <option className=" text-center" value="">
              -- Scegli il tipo di animale --
            </option>
            <option className=" text-center" value="animale">
              Animale
            </option>
            <option className=" text-center" value="animale smarrito">
              Animale Smarrito
            </option>
          </select>

          {selectedOption &&
            (selectedOption === "animale" ? (
              <select
                id="tipoAnimale"
                className="inputLogin"
                value={ricovero.animaleId || animaleId}
                onChange={(e) => setAnimaleId(e.target.value)}
              >
                <option className=" text-center" value="">
                  -- Scegli l'animale --
                </option>
                {animali &&
                  animali.map((animale) => {
                    return (
                      <option
                        className=" text-center"
                        key={animale.animaleId}
                        value={animale.animaleId}
                      >
                        {animale.nome}
                      </option>
                    );
                  })}
              </select>
            ) : (
              <select
                id="tipoAnimale"
                className="inputLogin"
                value={ricovero.animaleSmarritoId || animaleSmarritoId}
                onChange={(e) => setAnimaleSmarritoId(e.target.value)}
              >
                <option className=" text-center" value="">
                  -- Scegli l'animale --
                </option>
                {animaliSmarriti &&
                  animaliSmarriti.map((animale) => {
                    return (
                      <option
                        className=" text-center"
                        key={animale.animaleSmarritoId}
                        value={animale.animaleSmarritoId}
                      >
                        {animale.nome}
                      </option>
                    );
                  })}
              </select>
            ))}
          <Button className="login-button" type="submit">
            Aggiungi ricovero
          </Button>
        </Form>
      </div>
    </div>
  );
};

export default RicoveroForm;
