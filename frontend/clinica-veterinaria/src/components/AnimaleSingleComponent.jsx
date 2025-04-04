import { Link } from "react-router-dom";
import { useDispatch } from "react-redux";
import { deleteAnimale } from "../redux/actions/animale.js";
import { useNavigate } from "react-router-dom";
import { useLocation } from "react-router-dom";

function AnimaleSingleComponent(props) {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const handleDelete = (id) => {
    dispatch(deleteAnimale(id));
  };

  const location = useLocation();

  const handlePut = (id) => {
    navigate(`/animale-edit/${id}`);
  };
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
        {location.pathname === "/clinica/listaAnimali" && (
          <div className="d-flex justify-content-between mt-2">
            <Link
              to={`/animale-details/${props.animale.animaleId}`}
              className="btn btn-primary"
            >
              Dettagli
            </Link>

            <button
              onClick={(e) => {
                e.preventDefault();
                handleDelete(props.animale.animaleId);
              }}
              className="btn btn-danger"
            >
              Elimina
            </button>

            <button
              onClick={(e) => {
                e.preventDefault();
                handlePut(props.animale.animaleId);
              }}
              className="btn btn-warning"
            >
              Modifica
            </button>
          </div>
        )}
      </div>
    </div>
  );
}

export default AnimaleSingleComponent;
