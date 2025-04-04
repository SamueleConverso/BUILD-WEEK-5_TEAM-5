import React from 'react';
import { Link } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { deleteAnimaleSmarrito } from '../redux/actions/animaleSmarrito';

function AnimaleSmarritoCard({ animale }) {
  const dispatch = useDispatch();

  if (!animale) {
    return null;
  }
  const handleDelete = async () => {
    if (
      window.confirm(
        `Sei sicuro di voler eliminare l'animale "${animale.nome}"?`
      )
    ) {
      try {
        await dispatch(deleteAnimaleSmarrito(animale.animaleSmarritoId));
      } catch (error) {
        console.error("Errore durante l'eliminazione:", error);
        alert("Errore durante l'eliminazione dell'animale");
      }
    }
  };

  return (
    <div className='card' style={{ width: '100%' }}>
      <img
        src='https://placedog.net/300/300'
        className='card-img-top'
        alt={animale.nome}
      />
      <div className='card-body'>
        <h5 className='card-title'>{animale.nome}</h5>
        <p className='card-text'>
          {animale.specie} - {animale.colore}
        </p>
        <p className='card-text'>
          {animale.microchip
            ? `Microchip: ${animale.numeroMicrochip || 'N/A'}`
            : 'Senza microchip'}
        </p>
        <div className='d-flex justify-content-between'>
          <Link
            to={`/clinica/animaliSmarriti/${animale.animaleSmarritoId}`}
            className='btn btn-primary btn-sm'
          >
            Dettagli
          </Link>
          <Link
            to={`/clinica/modificaAnimaliSmarriti/${animale.animaleSmarritoId}`}
            className='btn btn-warning btn-sm'
          >
            Modifica
          </Link>
          <button className='btn btn-danger btn-sm' onClick={handleDelete}>
            Elimina
          </button>
        </div>
      </div>
    </div>
  );
}

export default AnimaleSmarritoCard;
