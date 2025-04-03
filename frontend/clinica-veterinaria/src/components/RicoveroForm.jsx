/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect, useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { getAnimali } from "../redux/actions/animale.js";

const RicoveroForm = () => {
  const [inCorso, setInCorso] = useState(false);
  const [selectedOption, setSelectedOption] = useState("");
  const [selectedAnimaleOption, setSelectedAnimaleOption] = useState("");
  //const [selectedAnimaleSmarritoOption, setSelectedAnimaleSmarritoOption] = useState("");

  const dispatch = useDispatch();

  const animali = useSelector((state) => state.animale.animali);

  useEffect(() => {
    dispatch(getAnimali());
  }, []);

  return (
    <div className="container-fluid d-flex justify-content-center my-3">
      <div className="containerLogin containerAnimali">
        <h1 className="heading">Aggiungi un nuovo ricovero</h1>

        <Form
          className="formLogin"
          onSubmit={(e) => {
            e.preventDefault();
            //   handleSubmit();
          }}
        >
          <Form.Control
            className="inputLogin"
            placeholder="Descrizione"
            type="text"
            //   value={nome}
            //   onChange={(e) => setNome(e.target.value)}
          ></Form.Control>

          <Form.Label className="mt-2 mb-0 ps-2" id="microchip">
            Data inizio ricovero
          </Form.Label>
          <Form.Control
            className="inputLogin mt-0"
            type="date"
            //   value={dataRegistrazione}
            //   onChange={(e) => setDataRegistrazione(e.target.value)}
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
                //   value={numeroMicrochip}
                //   onChange={(e) => setNumeroMicrochip(e.target.value)
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
                value={selectedAnimaleOption}
                onChange={(e) => setSelectedAnimaleOption(e.target.value)}
              >
                <option className=" text-center" value="">
                  -- Scegli l'animale --
                </option>
                {animali.map((animale) => {
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
              <Form.Control
                className="inputLogin"
                placeholder="Id animale smarrito"
                type="text"
              />
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
