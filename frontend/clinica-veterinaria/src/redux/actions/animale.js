export const postAnimale = (
  dataRegistrazione,
  nome,
  specie,
  colore,
  dataNascita,
  microchip,
  numeroMicrochip,
  nominativoProprietario
) => {
  return async () => {
    try {
      const response = await fetch("https://localhost:7138/api/Animale", {
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
      const response = await fetch("https://localhost:7138/api/Animale", {
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
        "https://localhost:7138/api/Animale/" + animaleId,
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
