/* eslint-disable react-hooks/exhaustive-deps */
import Table from "react-bootstrap/Table";
import { useDispatch, useSelector } from "react-redux";
import { deleteRicovero, getRicoveri } from "../redux/actions/ricovero";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

const RicoveriList = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const ricoveri = useSelector((state) => state.ricoveri.ricoveri);

  useEffect(() => {
    dispatch(getRicoveri());
  }, []);

  const handleDelete = (id) => {
    dispatch(deleteRicovero(id));
  };

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
            <th>Actions</th>
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
                  {ricovero.dataFineRicovero != null ? (
                    <td>{ricovero.dataFineRicovero}</td>
                  ) : (
                    <td>in corso</td>
                  )}
                  <td>{ricovero.animale.nome}</td>
                  <td>{ricovero.animale.specie}</td>
                  <td>{ricovero.animale.colore}</td>
                  <td>{ricovero.animale.dataNascita}</td>
                  <td>{ricovero.animale.nominativoProprietario}</td>
                  {ricovero.animale.numeroMicrochip != null ? (
                    <td>{ricovero.animale.numeroMicrochip}</td>
                  ) : (
                    <td>microchip non presente</td>
                  )}
                  <td className="d-flex align-items-center justify-content-center gap-2">
                    {" "}
                    <button
                      className="btn btn-danger"
                      onClick={(e) => {
                        e.preventDefault();
                        handleDelete(ricovero.ricoveroId);
                      }}
                    >
                      {" "}
                      <i className="bi bi-trash3"></i>{" "}
                    </button>{" "}
                    <button
                      className="btn btn-warning"
                      onClick={(e) => {
                        e.preventDefault();
                        navigate(
                          `/clinica/formRicovero/${ricovero.ricoveroId}`
                        );
                      }}
                    >
                      <i className="bi bi-pencil-square"></i>
                    </button>{" "}
                  </td>
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
            <th>Actions</th>
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
                  {ricovero.dataFineRicovero != null ? (
                    <td>{ricovero.dataFineRicovero}</td>
                  ) : (
                    <td>in corso</td>
                  )}
                  <td>{ricovero.animaleSmarrito.nome}</td>
                  <td>{ricovero.animaleSmarrito.specie}</td>
                  <td>{ricovero.animaleSmarrito.colore}</td>
                  {ricovero.animaleSmarrito.numeroMicrochip != null ? (
                    <td>{ricovero.animaleSmarrito.numeroMicrochip}</td>
                  ) : (
                    <td>microchip non presente</td>
                  )}
                  <td className="d-flex align-items-center justify-content-center gap-2">
                    {" "}
                    <button
                      className="btn btn-danger"
                      onClick={(e) => {
                        e.preventDefault();
                        handleDelete(ricovero.ricoveroId);
                      }}
                    >
                      {" "}
                      <i className="bi bi-trash3"></i>{" "}
                    </button>{" "}
                    <button
                      className="btn btn-warning"
                      onClick={(e) => {
                        e.preventDefault();
                        navigate(
                          `/clinica/formRicovero/${ricovero.ricoveroId}`
                        );
                      }}
                    >
                      <i className="bi bi-pencil-square"></i>
                    </button>
                  </td>
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
