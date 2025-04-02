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
    let microchipToPass = numeroMicrochip === 0 ? false : true;
    let numeroMicrochipToPass =
      microchipToPass === false ? null : numeroMicrochip;

    //setMicrochip(numeroMicrochip === 0 ? false : true);
    //setNumeroMicrochip(microchip === false ? null : numeroMicrochip);

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
    <div className="container d-flex flex-column align-items-center mb-5">
      <h1 className="text-center">Aggiungi un nuovo animale</h1>

      <Form
        style={{ width: "50%" }}
        onSubmit={(e) => {
          e.preventDefault();
          handleSubmit();
        }}
      >
        <Form.Label>Data di registrazione</Form.Label>
        <Form.Control
          type="date"
          value={dataRegistrazione}
          onChange={(e) => setDataRegistrazione(e.target.value)}
        ></Form.Control>

        <Form.Label>Nome</Form.Label>
        <Form.Control
          type="text"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
        ></Form.Control>

        <Form.Label>Specie</Form.Label>
        <Form.Control
          type="text"
          value={specie}
          onChange={(e) => setSpecie(e.target.value)}
        ></Form.Control>

        <Form.Label>Colore</Form.Label>
        <Form.Control
          type="text"
          value={colore}
          onChange={(e) => setColore(e.target.value)}
        ></Form.Control>

        <Form.Label>Data di nascita</Form.Label>
        <Form.Control
          type="date"
          value={dataNascita}
          onChange={(e) => setDataNascita(e.target.value)}
        ></Form.Control>

        <Form.Label>Microchip</Form.Label>
        <Form.Check
          checked={microchip}
          onChange={(e) => setMicrochip(e.target.checked)}
        ></Form.Check>
        {microchip && (
          <>
            {" "}
            <Form.Label>Numero microchip</Form.Label>
            <Form.Control
              type="number"
              value={numeroMicrochip}
              onChange={(e) => setNumeroMicrochip(e.target.value)}
            ></Form.Control>
          </>
        )}

        <Form.Label>Nominativo proprietario</Form.Label>
        <Form.Control
          type="text"
          value={nominativoProprietario}
          onChange={(e) => setNominativoProprietario(e.target.value)}
          className="mb-3"
        ></Form.Control>
        <Button
          variant="primary"
          type="submit"
          // onClick={(e) => {
          //   e.preventDefault();
          //   handleSubmit();
          // }}
        >
          Aggiungi animale
        </Button>
      </Form>
    </div>
  );
}

export default AddAnimaleForm;
