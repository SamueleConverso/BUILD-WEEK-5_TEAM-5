/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getVisite } from "../redux/actions/visita.js";
import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";
import { deleteVisita } from "../redux/actions/visita.js";

const VisiteList = () => {
  const dispatch = useDispatch();
  const visite = useSelector((state) => state.visita.visite);

  useEffect(() => {
    dispatch(getVisite());
  }, []);

  const handleDelete = (visitaId) => {
    dispatch(deleteVisita(visitaId));
  };

  return (
    <div className="container d-flex justify-content-center table-responsive">
      <table className="table table-bordered table-hover">
        <thead>
          <tr>
            <th>Data visita</th>
            <th>Esame</th>
            <th>Descrizione cura</th>
            <th>Animale</th>
            <th>Animale smarrito</th>
            <th>Azioni</th>
          </tr>
        </thead>
        <tbody>
          {visite &&
            visite.map((visita) => {
              return (
                <tr key={visita.visitaId}>
                  <td>{visita.dataVisita}</td>
                  <td>{visita.esame}</td>
                  <td>{visita.descrizioneCura}</td>
                  <td>
                    {visita.animale ? (
                      <Link
                        className="text-decoration-underline"
                        to={`/animale-details/${visita.animale.animaleId}`}
                      >
                        {visita.animale.nome}
                      </Link>
                    ) : (
                      "-"
                    )}
                  </td>
                  <td>
                    {visita.animaleSmarrito ? (
                      <Link
                        className="text-decoration-underline"
                        to={`/clinica/animaliSmarriti/${visita.animaleSmarrito.animaleSmarritoId}`}
                      >
                        {visita.animaleSmarrito.nome}
                      </Link>
                    ) : (
                      "-"
                    )}
                  </td>
                  <td>
                    <div className="d-flex justify-content-center gap-3">
                      <Button
                        className="btn btn-danger"
                        onClick={(e) => {
                          e.preventDefault();
                          handleDelete(visita.visitaId);
                        }}
                      >
                        <i className="bi bi-trash3"></i>
                      </Button>
                    </div>
                  </td>
                </tr>
              );
            })}
        </tbody>
      </table>
    </div>
  );
};

export default VisiteList;
