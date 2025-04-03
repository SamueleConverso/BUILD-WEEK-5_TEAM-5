import { Button, Form } from "react-bootstrap";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { postAnimale } from "../redux/actions/animale.js";

function AddAnimaleForm() {
  const [dataRegistrazione, setDataRegistrazione] = useState("");
  const [nome, setNome] = useState("");
  const [specie, setSpecie] = useState("");
  const [colore, setColore] = useState("");
  const [dataNascita, setDataNascita] = useState("");
  const [microchip, setMicrochip] = useState(false);
  const [numeroMicrochip, setNumeroMicrochip] = useState(0);
  const [nominativoProprietario, setNominativoProprietario] = useState("");

  const dispatch = useDispatch();

  const handleSubmit = () => {
    let microchipToPass = null;
    let numeroMicrochipToPass = null;

    if (!microchip) {
      setNumeroMicrochip(0);
      microchipToPass = false;
      numeroMicrochipToPass = null;
    } else {
      microchipToPass = true;
      numeroMicrochipToPass = numeroMicrochip;
      if (numeroMicrochipToPass === 0) {
        microchipToPass = false;
        numeroMicrochipToPass = null;
      }
    }

    dispatch(
      postAnimale(
        dataRegistrazione,
        nome,
        specie,
        colore,
        dataNascita,
        microchipToPass,
        numeroMicrochipToPass,
        nominativoProprietario
      )
    );

    setDataRegistrazione("");
    setNome("");
    setSpecie("");
    setColore("");
    setDataNascita("");
    setMicrochip(false);
    setNumeroMicrochip(0);
    setNominativoProprietario("");

    console.log(
      dataRegistrazione,
      nome,
      specie,
      colore,
      dataNascita,
      microchipToPass,
      numeroMicrochipToPass,
      nominativoProprietario
    );
  };

  return (
    <div className="container-fluid mb-5 d-flex justify-content-center">
      <div className="containerLogin containerAnimali">
        <h1 className="heading">Aggiungi un nuovo animale</h1>

        <Form
          className="formLogin"
          onSubmit={(e) => {
            e.preventDefault();
            handleSubmit();
          }}
        >
          <Form.Label className="m-0 ps-2" id="microchip">
            Data di registrazione
          </Form.Label>
          <Form.Control
            className="inputLogin mt-0"
            type="date"
            value={dataRegistrazione}
            onChange={(e) => setDataRegistrazione(e.target.value)}
          ></Form.Control>

          <Form.Control
            className="inputLogin"
            placeholder="Nome"
            type="text"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
          ></Form.Control>

          <Form.Control
            className="inputLogin"
            placeholder="Specie"
            type="text"
            value={specie}
            onChange={(e) => setSpecie(e.target.value)}
          ></Form.Control>

          <Form.Control
            className="inputLogin"
            placeholder="Colore"
            type="text"
            value={colore}
            onChange={(e) => setColore(e.target.value)}
          ></Form.Control>

          <Form.Label className="mt-3 mb-0 ps-2" id="microchip">
            Data di nascita
          </Form.Label>
          <Form.Control
            className="inputLogin mt-0"
            type="date"
            value={dataNascita}
            onChange={(e) => setDataNascita(e.target.value)}
          ></Form.Control>

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
              {" "}
              <Form.Control
                className="inputLogin"
                placeholder="Numero microchip"
                type="number"
                value={numeroMicrochip}
                onChange={(e) => setNumeroMicrochip(e.target.value)}
              ></Form.Control>
            </>
          )}

          <Form.Control
            className="inputLogin"
            placeholder="Nominativo proprietario"
            type="text"
            value={nominativoProprietario}
            onChange={(e) => setNominativoProprietario(e.target.value)}
          ></Form.Control>
          <Button
            className="login-button"
            type="submit"
          >
            Aggiungi animale
          </Button>
        </Form>
      </div>
    </div>
  );
}

export default AddAnimaleForm;
