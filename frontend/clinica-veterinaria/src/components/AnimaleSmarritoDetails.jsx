// AnimaleSmarritoDetails.jsx
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useParams, Link } from 'react-router-dom';
import { getAnimaleSmarritoById } from '../redux/actions/animaleSmarrito';

function AnimaleSmarritoDetails() {
  const { id } = useParams();
  const dispatch = useDispatch();
  const { animaleSelezionato, loading, error: reduxError } = useSelector(state => state.animaliSmarriti || {});
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchAnimale = async () => {
      try {
        await dispatch(getAnimaleSmarritoById(id));
      } catch (err) {
        console.error("Errore recupero dettagli animale:", err);
        setError(`Impossibile caricare i dettagli dell'animale ID: ${id}`);
      }
    };

    fetchAnimale();
  }, [dispatch, id]);

  if (loading || !animaleSelezionato) {
    return (
      <div className="container text-center my-5">
        <div className="spinner-border" role="status">
          <span className="visually-hidden">Caricamento...</span>
        </div>
      </div>
    );
  }
  
  if (error || reduxError) {
    return (
      <div className="container my-5">
        <div className="alert alert-danger" role="alert">
          {error || reduxError}
        </div>
        <Link to="/animali-smarriti" className="btn btn-primary">
          Torna alla lista
        </Link>
      </div>
    );
  }

  return (
    <div className="container my-5">
      <div className="card mb-4">
        <div className="card-header d-flex justify-content-between align-items-center">
          <h2 className="mb-0">Dettaglio Animale Smarrito</h2>
          <Link to="/animali-smarriti" className="btn btn-secondary">
            Torna alla lista
          </Link>
        </div>
        <div className="card-body">
          <div className="row">
            <div className="col-md-4 text-center">
              <img
                src="https://placedog.net/400/400"
                className="img-fluid rounded mb-3"
                alt={animaleSelezionato.nome}
              />
            </div>
            <div className="col-md-8">
              <h3 className="mb-3">{animaleSelezionato.nome}</h3>
              
              <table className="table">
                <tbody>
                  <tr>
                    <th style={{ width: "30%" }}>ID</th>
                    <td>{animaleSelezionato.animaleSmarritoId}</td>
                  </tr>
                  <tr>
                    <th>Specie</th>
                    <td>{animaleSelezionato.specie}</td>
                  </tr>
                  <tr>
                    <th>Colore</th>
                    <td>{animaleSelezionato.colore}</td>
                  </tr>
                  <tr>
                    <th>Microchip</th>
                    <td>{animaleSelezionato.microchip ? 'Sì' : 'No'}</td>
                  </tr>
                  {animaleSelezionato.microchip && (
                    <tr>
                      <th>Numero Microchip</th>
                      <td>{animaleSelezionato.numeroMicrochip || 'N/A'}</td>
                    </tr>
                  )}
                </tbody>
              </table>
              
              <div className="mt-4 d-flex gap-2">
                <Link
                  to={`/animali-smarriti/modifica/${animaleSelezionato.animaleSmarritoId}`}
                  className="btn btn-warning"
                >
                  Modifica
                </Link>
                <Link
                  to={`/animali-smarriti/elimina/${animaleSelezionato.animaleSmarritoId}`}
                  className="btn btn-danger"
                >
                  Elimina
                </Link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default AnimaleSmarritoDetails;