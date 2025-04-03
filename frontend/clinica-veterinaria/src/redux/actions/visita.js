export const postVisita = (
  dataVisita,
  esame,
  descrizioneCura,
  animaleId,
  animaleSmarritoId
) => {
  return async () => {
    try {
      const response = await fetch("https://localhost:7138/api/Visita", {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify({
          dataVisita: dataVisita,
          esame: esame,
          descrizioneCura: descrizioneCura,
          animaleId: animaleId,
          animaleSmarritoId: animaleSmarritoId,
        }),
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        //dispatch(getAnimali());
        alert("Visita aggiunta con successo!");
      } else {
        alert(
          "Errore! Forse non hai inserito tutti i campi richiesti o c'è un errore nella fetch."
        );
        throw new Error("Errore nella response di postVisita");
      }
    } catch (error) {
      console.error("ERRORE FETCH:" + error);
    }
  };
};

export const getVisite = () => {
  return async (dispatch) => {
    try {
      const response = await fetch("https://localhost:7138/api/Visita", {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
          "Content-Type": "application/json",
        },
      });
      if (response.ok) {
        const data = await response.json();
        console.log(data);
        dispatch({
          type: "GET_VISITE",
          payload: data.listaVisite,
        });
      } else {
        throw new Error("Errore nella response di getVisite");
      }
    } catch (error) {
      console.error("ERRORE FETCH:" + error);
    }
  };
};
