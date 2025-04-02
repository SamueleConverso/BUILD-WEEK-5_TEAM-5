import { Link } from "react-router-dom";

function AnimaleSingleComponent(props) {
  return (
    <div className="card" style={{ width: "100%" }}>
      <img
        src="https://placedog.net/300/300"
        className="card-img-top"
        alt="..."
      />
      <div className="card-body">
        <h5 className="card-title">{props.animale.nome}</h5>
        <p className="card-text">
          {props.animale.specie} - {props.animale.colore}
        </p>
        <div className="d-flex justify-content-between">
          <Link
            to={`/animale-details/${props.animale.animaleId}`}
            className="btn btn-primary"
          >
            Dettagli
          </Link>
          <Link to="" className="btn btn-danger">
            Elimina
          </Link>
        </div>
      </div>
    </div>
  );
}

export default AnimaleSingleComponent;
