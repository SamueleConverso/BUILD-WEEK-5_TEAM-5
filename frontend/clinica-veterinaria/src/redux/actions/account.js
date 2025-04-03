export const register = (nome, cognome, email, password) => {
  return async (dispatch, navigate) => {
    try {
      const response = await fetch(
        "https://localhost:7138/api/Account/register",
        {
          headers: {
            "Content-Type": "application/json",
          },
          method: "POST",
          body: JSON.stringify({
            firstName: nome,
            lastName: cognome,
            email: email,
            password: password,
          }),
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        navigate("/login");
      } else {
        dispatch({
          type: "REGISTER_ERROR",
          payload: "Errore nella registrazione.",
        });
        throw new Error("Errore nella response di registrazione");
      }
    } catch (error) {
      console.error("ERRORE FETCH:" + error);
    }
  };
};

export const login = (email, password) => {
  return async (dispatch, navigate) => {
    try {
      const response = await fetch("https://localhost:7138/api/Account/login", {
        headers: {
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify({
          email: email,
          password: password,
        }),
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        localStorage.setItem("jwtToken", data.token);
        dispatch({ type: "LOGIN_SUCCESS", payload: true });
        console.log("SONO QUI");
        navigate("/");
      } else {
        dispatch({ type: "LOGIN_ERROR", payload: "Errore nel login." });
        throw new Error("Errore nella response di login");
      }
    } catch (error) {
      console.error("ERRORE FETCH:" + error);
    }
  };
};
