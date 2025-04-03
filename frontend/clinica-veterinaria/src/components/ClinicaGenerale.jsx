import { Link } from "react-router-dom";

const ClinicaGenerale = () => {
  return (
    <div className="container py-5">
      <div className="row">
        <div className="col-3 my-5">
          <Link to={"/clinica/listaAnimali"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                CONSULTA LA{" "}
                <span className=" fw-semibold">LISTA DEGLI ANIMALI</span>
              </p>
            </div>
          </Link>
        </div>

        <div className="col-3 my-5">
          <Link to={"/clinica/animaliSmarriti"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                CONSULTA LA{" "}
                <span className=" fw-semibold">
                  LISTA DEGLI ANIMALI SMARRITI
                </span>
              </p>
            </div>
          </Link>
        </div>

        <div className="col-3 my-5">
          <Link to={"/clinica/formAnimali"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                <span className=" fw-semibold">AGGIUNGI UN ANIMALE</span> ALLA
                LISTA
              </p>
            </div>
          </Link>
        </div>

        <div className="col-3 my-5">
          <Link to={"/clinica/formAnimaliSmarriti"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                <span className=" fw-semibold">
                  AGGIUNGI UN ANIMALE SMARRITO
                </span>{" "}
                ALLA LISTA
              </p>
            </div>
          </Link>
        </div>

        <div className="col-3 my-5">
          <Link to={"clinica/listaRicoveri"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                CONSULTA LA
                <span className="fw-semibold"> LISTA DI RICOVERI</span>{" "}
              </p>
            </div>
          </Link>
        </div>

        <div className="col-3 my-5">
          <Link to={"/clinica/formRicovero"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                <span className="fw-semibold">AGGIUNGI UN RICOVERO</span> ALLA
                LISTA
              </p>
            </div>
          </Link>
        </div>

        <div className="col-3 my-5">
          <Link to={"clinica/listaVisite"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                CONSULTA LA
                <span className="fw-semibold"> LISTA DI VISITE</span>{" "}
              </p>
            </div>
          </Link>
        </div>

        <div className="col-3 my-5">
          <Link to={"/clinica/formVisita"} className="cardClinica">
            <div className="contentClinica">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="14"
                height="14"
                fill="currentColor"
                className="bi bi-folder"
                viewBox="0 0 16 16"
              >
                <path d="M.54 3.87.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181l-.637 7A2 2 0 0 1 13.174 14H2.826a2 2 0 0 1-1.991-1.819l-.637-7a2 2 0 0 1 .342-1.31zM2.19 4a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zm4.69-1.707A1 1 0 0 0 6.172 2H2.5a1 1 0 0 0-1 .981l.006.139q.323-.119.684-.12h5.396z" />
              </svg>
              <p className="para text-center">
                <span className="fw-semibold">AGGIUNGI UNA VISITA</span> ALLA
                LISTA
              </p>
            </div>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default ClinicaGenerale;
