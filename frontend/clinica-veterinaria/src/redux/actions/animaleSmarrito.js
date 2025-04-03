const API_URL = "https://localhost:7138/api/AnimaleSmarrito";

export const createAnimaleSmarritoAPI = (
  nome,
  specie,
  colore,
  microchip,
  numeroMicrochip
) => {
  return async (dispatch) => {
    dispatch({ type: "CREATE_ANIMALE_SMARRITO_REQUEST" });

    try {
      const response = await fetch(API_URL, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
        },
        body: JSON.stringify({
          nome: nome,
          specie: specie,
          colore: colore,
          microchip: microchip,
          numeroMicrochip: numeroMicrochip,
        }),
      });

      if (!response.ok) {
        throw new Error(`Errore ${response.status}: ${response.statusText}`);
      }

      const data = await response.json();

      dispatch({ type: "CREATE_ANIMALE_SMARRITO_SUCCESS" });

      return data;
    } catch (error) {
      console.error("Errore durante la creazione:", error);
      throw error;
    }
  };
};

export const getAnimaliSmarriti = () => {
  return async (dispatch) => {
    dispatch({ type: "GET_ANIMALI_SMARRITI_REQUEST" });

    try {
      const response = await fetch(API_URL, {
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
        }
      });

      if (response.ok) {
        const data = await response.json();
        console.log("Dati ricevuti:", data);

        dispatch({
          type: "GET_ANIMALI_SMARRITI_SUCCESS",
          payload: data.animaliSmarriti || []
        });

        return data;
      } else {
        throw new Error(`Errore ${response.status}: ${response.statusText}`);
      }
    } catch (error) {
      console.error("Errore durante la creazione:", error);
      throw error;
    }
  };
};

export const getAnimaleSmarritoById = (id) => {
  return async (dispatch) => {
    dispatch({ type: "GET_ANIMALE_SMARRITO_BY_ID_REQUEST" });

    try {
      const response = await fetch(`https://localhost:7138/animaleSmarrito?id=${id}`, {
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
        }
      });

      if (response.ok) {
        const data = await response.json();
        console.log("Dettaglio animale ricevuto:", data);

        dispatch({
          type: "GET_ANIMALE_SMARRITO_BY_ID_SUCCESS",
          payload: data.animaleSmarrito
        });

        return data;
      } else {
        throw new Error(`Errore ${response.status}: ${response.statusText}`);
      }
    } catch (error) {
      console.error("Errore durante la creazione:", error);
      throw error;
    }
  };
};
