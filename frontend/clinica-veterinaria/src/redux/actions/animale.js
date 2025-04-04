export const postAnimale = (
  dataRegistrazione,
  nome,
  specie,
  colore,
  dataNascita,
  microchip,
  numeroMicrochip,
  nominativoProprietario,
  navigate
) => {
  return async (dispatch) => {
    try {
      const response = await fetch("http://192.168.1.65:5284/api/Animale", {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify({
          dataRegistrazione: dataRegistrazione,
          nome: nome,
          specie: specie,
          colore: colore,
          dataNascita: dataNascita,
          microchip: microchip,
          numeroMicrochip: numeroMicrochip,
          nominativoProprietario: nominativoProprietario,
        }),
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        dispatch(getAnimali());
        navigate("/clinica/listaAnimali")
        alert("Animale aggiunto con successo!");
      } else {
        alert("Errore! Forse non hai inserito tutti i campi richiesti.");
        throw new Error("Errore nella response di postAnimale");
      }
    } catch (error) {
      console.error("ERRORE FETCH:" + error);
    }
  };
};

export const getAnimali = () => {
  return async (dispatch) => {
    try {
      const response = await fetch("http://192.168.1.65:5284/api/Animale", {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
          "Content-Type": "application/json",
        },
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        dispatch({
          type: "GET_ANIMALI",
          payload: data.animali,
        });
      } else {
        throw new Error("Errore nella response di getAnimali");
      }
    } catch (error) {
      console.error("ERRORE FETCH:" + error);
    }
  };
};

export const getAnimaleById = (animaleId) => {
  return async (dispatch) => {
    try {
      const response = await fetch(
        "http://192.168.1.65:5284/api/Animale/" + animaleId,
        {
          headers: {
            Authorization: "Bearer " + localStorage.getItem("jwtToken"),
            "Content-Type": "application/json",
          },
        }
      );
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        dispatch({
          type: "GET_ANIMALE_BY_ID",
          payload: data.animale,
        });
      } else {
        throw new Error("Errore nella response di getAnimaleById");
      }
    } catch (error) {
      console.error("ERRORE FETCH:" + error);
    }
  };
};

export const putAnimale = (
  animaleId,
  dataRegistrazione,
  nome,
  specie,
  colore,
  dataNascita,
  microchip,
  numeroMicrochip,
  nominativoProprietario,
  navigate
) => {
  return async (dispatch) => {
    try {
      const response = await fetch(
        "http://192.168.1.65:5284/api/Animale/" + animaleId,
        {
          method: "PUT",
          body: JSON.stringify({
            dataRegistrazione: dataRegistrazione,
            nome: nome,
            specie: specie,
            colore: colore,
            dataNascita: dataNascita,
            microchip: microchip,
            numeroMicrochip: numeroMicrochip,
            nominativoProprietario: nominativoProprietario,
          }),
          headers: {
            Authorization: "Bearer " + localStorage.getItem("jwtToken"),
            "Content-type": "application/json; charset=UTF-8",
          },
        }
      );
      if (response.ok) {
        alert("Animale modificato con successo!");
        dispatch(getAnimali());
        navigate("/clinica/listaAnimali")
      } else {
        alert("Errore! Forse non hai inserito tutti i campi richiesti.");
        throw new Error("errore nella putAnimale");
      }
    } catch (error) {
      console.error("ERRORE:", error);
    }
  };
};

export const deleteAnimale = (id) => {
  return async (dispatch) => {
    try {
      const response = await fetch("http://192.168.1.65:5284/api/Animale/" + id, {
        method: "DELETE",
        headers: {
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
        },
      });
      if (response.ok) {
        dispatch(getAnimali());
      } else throw new Error("errore nella deleteAnimale");
    } catch (error) {
      console.error("ERRORE:", error);
    }
  };
};
