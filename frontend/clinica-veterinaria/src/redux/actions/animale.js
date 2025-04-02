const token =
  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJzYW11ZWxlLmNvbnZlcnNvQGVtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJTYW11ZWxlIENvbnZlcnNvIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiJjODhkMzU2NS01NWU2LTQyZDItYmUxMy03YjY5M2FlYjc3MDQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJWZXRlcmluYXJpbyIsImV4cCI6MTc0MzY0MTYzOCwiaXNzIjoiaHR0cHM6Ly9jbGluaWNhLXZldGVyaW5hcmlhLmNvbSIsImF1ZCI6Imh0dHBzOi8vY2xpbmljYS12ZXRlcmluYXJpYS1kYXNoYm9hcmQuY29tIn0.6KUBg7MM35s2OixNsGdtBWlvdcF-iZxQ9EsOTGts5gI";

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
          Authorization: "Bearer " + token,
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
          Authorization: "Bearer " + token,
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
            Authorization: "Bearer " + token,
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
