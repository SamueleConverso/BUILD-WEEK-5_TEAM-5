/* eslint-disable react-hooks/exhaustive-deps */
import Table from "react-bootstrap/Table";
import { useDispatch, useSelector } from "react-redux";
import { getRicoveri } from "../redux/actions/ricovero";
import { useEffect } from "react";

const RicoveriList = () => {
  const dispatch = useDispatch();
  const ricoveri = useSelector((state) => state.ricoveri.ricoveri);

  useEffect(() => {
    dispatch(getRicoveri());
  }, []);

  return (
    <div className="container my-4">
      <h3
        className="text-center my-3 fw-semibold fs-2"
        style={{ color: "rgb(190, 30, 30)" }}
      >
        Ricoveri animali
      </h3>
      <Table striped bordered hover>
        <thead>
          <tr className="text-center">
            <th>Id</th>
            <th>Descrizione</th>
            <th>Data inizio</th>
            <th>Data fine</th>
            <th>Nome Animale</th>
            <th>Specie</th>
            <th>Colore</th>
            <th>Data di nascita</th>
            <th>Nominativo proprietario</th>
            <th>Numero microchip</th>
          </tr>
        </thead>
        <tbody>
          {ricoveri.map((ricovero) => {
            return (
              ricovero.animale && (
                <tr key={ricovero.ricoveroId} className="text-center">
                  <td>{ricovero.ricoveroId}</td>
                  <td>{ricovero.descrizione}</td>
                  <td>{ricovero.dataInizioRicovero}</td>
                  <td>{ricovero.dataFineRicovero}</td>
                  <td>{ricovero.animale.nome}</td>
                  <td>{ricovero.animale.specie}</td>
                  <td>{ricovero.animale.colore}</td>
                  <td>{ricovero.animale.dataNascita}</td>
                  <td>{ricovero.animale.nominativoProprietario}</td>
                  <td>{ricovero.animale.numeroMicrochip}</td>
                </tr>
              )
            );
          })}
        </tbody>
      </Table>

      <h3
        className="text-center my-3 fw-semibold fs-2"
        style={{ color: "rgb(190, 30, 30)" }}
      >
        Ricoveri animali smarriti
      </h3>
      <Table striped bordered hover>
        <thead>
          <tr className="text-center">
            <th>Id</th>
            <th>Descrizione</th>
            <th>Data inizio</th>
            <th>Data fine</th>
            <th>Nome Animale</th>
            <th>Specie</th>
            <th>Colore</th>
            <th>Numero microchip</th>
          </tr>
        </thead>
        <tbody>
          {ricoveri.map((ricovero) => {
            return (
              ricovero.animaleSmarrito && (
                <tr key={ricovero.ricoveroId} className="text-center">
                  <td>{ricovero.ricoveroId}</td>
                  <td>{ricovero.descrizione}</td>
                  <td>{ricovero.dataInizioRicovero}</td>
                  <td>{ricovero.dataFineRicovero}</td>
                  <td>{ricovero.animaleSmarrito.nome}</td>
                  <td>{ricovero.animaleSmarrito.specie}</td>
                  <td>{ricovero.animaleSmarrito.colore}</td>
                  <td>{ricovero.animaleSmarrito.numeroMicrochip}</td>
                </tr>
              )
            );
          })}
        </tbody>
      </Table>
    </div>
  );
};

export default RicoveriList;
