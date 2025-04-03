/* eslint-disable react-hooks/exhaustive-deps */
import { useParams } from "react-router-dom";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getAnimaleById } from "../redux/actions/animale.js";

function AnimaleDetails() {
  const { animaleId } = useParams();
  const dispatch = useDispatch();
  const animale = useSelector((state) => state.animale.animale);

  useEffect(() => {
    dispatch(getAnimaleById(animaleId));
  }, []);

  return (
    <div className="my-5">
      {animale && (
        <div
          className="container"
          style={{
            border: "3px solid black",
            borderRadius: "5px",
          }}
        >
          <h1 className="text-center">{animale.nome}</h1>
          <h3 className="text-center">{animale.specie}</h3>
          <div className="table-responsive">
            <table
              style={{ width: "100%" }}
              className="table table-bordered table-hover"
            >
              <thead>
                <tr>
                  <th scope="col">Data di registrazione</th>
                  <th scope="col">Colore</th>
                  <th scope="col">Data di nascita</th>
                  <th scope="col">Microchip</th>
                  <th scope="col">Numero microchip</th>
                  <th scope="col">Nominativo proprietario</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{animale.dataRegistrazione}</td>
                  <td>{animale.colore}</td>
                  <td>{animale.dataNascita}</td>
                  <td>{animale.microchip === true ? "Sì" : "No"}</td>
                  <td>{animale.numeroMicrochip}</td>
                  <td>{animale.nominativoProprietario}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      )}
    </div>
  );
}

export default AnimaleDetails;
