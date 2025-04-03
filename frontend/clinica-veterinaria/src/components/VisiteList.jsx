/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getVisite } from "../redux/actions/visita.js";
import { Link } from "react-router-dom";

const VisiteList = () => {
  const dispatch = useDispatch();
  const visite = useSelector((state) => state.visita.visite);

  useEffect(() => {
    dispatch(getVisite());
  }, []);
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
                      <Link to={`/animale-details/${visita.animale.animaleId}`}>
                        {visita.animale.nome}
                      </Link>
                    ) : (
                      "-"
                    )}
                  </td>
                  <td>
                    {visita.animaleSmarrito ? (
                      <Link
                        to={`/clinica/animaliSmarriti/${visita.animaleSmarrito.animaleSmarritoId}`}
                      >
                        {visita.animaleSmarrito.nome}
                      </Link>
                    ) : (
                      "-"
                    )}
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
