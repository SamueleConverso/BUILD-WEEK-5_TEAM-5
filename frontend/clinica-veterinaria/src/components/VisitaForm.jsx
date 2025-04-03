/* eslint-disable no-unused-vars */
/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect, useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { getAnimali } from "../redux/actions/animale.js";
import { getAnimaliSmarriti } from "../redux/actions/animaleSmarrito.js";
import { postVisita } from "../redux/actions/visita.js";
import { data } from "react-router-dom";

const VisitaForm = () => {
  const [inCorso, setInCorso] = useState(false);
  const [selectedOption, setSelectedOption] = useState("");
  const [selectedAnimaleOption, setSelectedAnimaleOption] = useState("");
  //const [selectedAnimaleSmarritoOption, setSelectedAnimaleSmarritoOption] = useState("");

  const [dataVisita, setDataVisita] = useState("");
  const [esame, setEsame] = useState("");
  const [descrizioneCura, setDescrizioneCura] = useState("");
  const [animaleId, setAnimaleId] = useState(0);
  const [animaleSmarritoId, setAnimaleSmarritoId] = useState(0);

  const dispatch = useDispatch();

  const animali = useSelector((state) => state.animale.animali);
  const animaliSmarriti = useSelector(
    (state) => state.animaliSmarriti.animaliSmarriti
  );

  useEffect(() => {
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

    if (!dataVisita) {
      alert("Inserire la data della visita");
      return;
    }

    dispatch(
      postVisita(
        dataVisita,
        esame,
        descrizioneCura,
        animaleIdToPass,
        animaleSmarritoIdToPass
      )
    );

    setDataVisita("");
    setEsame("");
    setDescrizioneCura("");
    setAnimaleId(0);
    setAnimaleSmarritoId(0);
  };

  return (
    <div className="container-fluid d-flex justify-content-center my-3">
      <div className="containerLogin containerAnimali">
        <h1 className="heading">Aggiungi una nuova visita</h1>

        <Form
          className="formLogin"
          onSubmit={(e) => {
            e.preventDefault();
            handleSubmit();
          }}
        >
          <Form.Label className="mt-2 mb-0 ps-2" id="microchip">
            Data visita
          </Form.Label>
          <Form.Control
            className="inputLogin"
            type="date"
            value={dataVisita}
            onChange={(e) => setDataVisita(e.target.value)}
          ></Form.Control>

          <Form.Control
            className="inputLogin mt-0"
            placeholder="Esame"
            type="text"
            value={esame}
            onChange={(e) => setEsame(e.target.value)}
          ></Form.Control>

          {/* <div className="ps-3 d-flex align-items-center inputLogin">
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
          </div> */}

          <Form.Control
            className="inputLogin mt-0"
            type="text"
            placeholder="Descrizione cura"
            value={descrizioneCura}
            onChange={(e) => setDescrizioneCura(e.target.value)}
          ></Form.Control>

          <select
            id="tipoAnimale"
            className="inputLogin"
            value={selectedOption}
            onChange={(e) => setSelectedOption(e.target.value)}
          >
            <option className="text-center" value="">
              -- Scegli il tipo di animale --
            </option>
            <option className="text-center" value="animale">
              Animale
            </option>
            <option className="text-center" value="animale smarrito">
              Animale Smarrito
            </option>
          </select>

          {selectedOption &&
            (selectedOption === "animale" ? (
              <select
                id="tipoAnimale"
                className="inputLogin"
                value={animaleId}
                onChange={(e) => setAnimaleId(e.target.value)}
              >
                <option className="text-center" value="">
                  -- Scegli l'animale --
                </option>
                {animali &&
                  animali.map((animale) => {
                    return (
                      <option
                        className="text-center"
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
                value={animaleSmarritoId}
                onChange={(e) => setAnimaleSmarritoId(e.target.value)}
              >
                <option className="text-center" value="">
                  -- Scegli l'animale smarrito--
                </option>
                {animaliSmarriti &&
                  animaliSmarriti.map((animale) => {
                    return (
                      <option
                        className="text-center"
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
            Aggiungi visita
          </Button>
        </Form>
      </div>
    </div>
  );
};

export default VisitaForm;
