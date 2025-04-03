import { useNavigate } from "react-router-dom";
import { login } from "../redux/actions/account.js";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";

const LoginClinica = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const errore = useSelector((state) => state.isLoginError);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessages, setErrorMessages] = useState({});

  const handleSubmit = (e) => {
    e.preventDefault();
    const errors = {};

    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (!email || !password) {
      errors.generic = "Compilare tutti i campi!";
    }

    if (!emailRegex.test(email)) {
      errors.email = "Inserire un'email valida.";
    }

    if (password.length < 8) {
      errors.password = "La password deve essere lunga almeno 8 caratteri.";
    }

    if (Object.keys(errors).length > 0) {
      setErrorMessages(errors);
      return;
    }

    setPassword("");
    setEmail("");
    setErrorMessages({});
    e.target.reset();
    dispatch(login(email, password, navigate));
  };

  return (
    <div className="container-fluid d-flex justify-content-center align-items-center">
      {errorMessages.generic && (
        <p className="text-danger">{errorMessages.generic}</p>
      )}
      <div className="containerLogin">
        <div className="heading">Accedi</div>
        <form
          onSubmit={(e) => {
            handleSubmit(e);
          }}
          className="formLogin"
        >
          <input
            required=""
            className="inputLogin"
            type="email"
            name="email"
            id="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="E-mail"
          />
          {errorMessages.email && (
            <p className="text-danger">{errorMessages.email}</p>
          )}
          <input
            required=""
            className="inputLogin"
            type="password"
            name="password"
            id="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Password"
          />
          {errorMessages.password && (
            <p className="text-center text-danger">{errorMessages.password}</p>
          )}
          <button className="login-button" type="submit">
            Accedi ora
          </button>
        </form>
        <div className="no-account-container">
          <p className="title text-black-50">
            Non hai un account? <a href="/register">Registrati</a>
          </p>
        </div>
      </div>
      {errore && <p> {errore} </p>}
    </div>
  );
};

export default LoginClinica;
