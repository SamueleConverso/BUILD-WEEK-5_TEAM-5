export const postRicovero = (
    descrizione,
    dataInizioRicovero,
    dataFineRicovero,
    animaleId,
    animaleSmarritoId,
) => {
    return async (dispatch) => {
        try {
            const response = await fetch("https://localhost:7138/api/Ricovero", {
                headers: {
                    Authorization: "Bearer " + localStorage.getItem("jwtToken"),
                    "Content-Type": "application/json",
                },
                method: "POST",
                body: JSON.stringify({
                    descrizione: descrizione,
                    dataInizioRicovero: dataInizioRicovero,
                    dataFineRicovero: dataFineRicovero,
                    animaleId: animaleId,
                    animaleSmarritoId: animaleSmarritoId,
                }),
            });
            if (response.ok) {
                const data = await response.json();
                console.log(data);
                dispatch(getRicoveri());
                alert("Ricovero aggiunto con successo!");
            } else {
                alert("Errore! Forse non hai inserito tutti i campi richiesti.");
                throw new Error("Errore nella response di postRicovero");
            }
        } catch (error) {
            console.error("ERRORE FETCH:" + error);
        }
    };
};

export const getRicoveri = () => {
    return async (dispatch) => {
        try {
            const response = await fetch("https://localhost:7138/api/Ricovero", {
                headers: {
                    Authorization: "Bearer " + localStorage.getItem("jwtToken"),
                    "Content-Type": "application/json",
                },
            });
            if (response.ok) {
                const data = await response.json();
                console.log(data);
                dispatch({
                    type: "GET_RICOVERI",
                    payload: data.ricoveri,
                });
            } else {
                throw new Error("Errore nella response di getRicoveri");
            }
        } catch (error) {
            console.error("ERRORE FETCH:" + error);
        }
    };
};

export const deleteRicovero = (id) => {
    return async (dispatch) => {
        try {
            const response = await fetch("https://localhost:7138/api/Ricovero/" + id, {
                method: "DELETE",
                headers: {
                    Authorization: "Bearer " + localStorage.getItem("jwtToken"),
                },
            });
            if (response.ok) {
                dispatch(getRicoveri());
            } else throw new Error("errore nella response di deleteRicovero");
        } catch (error) {
            console.error("ERRORE:", error);
        }
    };
};

export const putRicovero = (
    ricoveroId,
    descrizione,
    dataInizioRicovero,
    dataFineRicovero,
    animaleId,
    animaleSmarritoId,
) => {
    return async (dispatch) => {
        try {
            const response = await fetch(
                "https://localhost:7138/api/Ricovero/" + ricoveroId,
                {
                    method: "PUT",
                    body: JSON.stringify({
                        descrizione: descrizione,
                        dataInizioRicovero: dataInizioRicovero,
                        dataFineRicovero: dataFineRicovero,
                        animaleId: animaleId,
                        animaleSmarritoId: animaleSmarritoId,
                    }),
                    headers: {
                        Authorization: "Bearer " + localStorage.getItem("jwtToken"),
                        "Content-type": "application/json; charset=UTF-8",
                    },
                }
            );
            if (response.ok) {
                alert("Ricovero modificato con successo!");
                dispatch(getRicoveri());
            } else {
                alert("Errore! Forse non hai inserito tutti i campi richiesti.");
                throw new Error("errore nella risposta di putRicovero");
            }
        } catch (error) {
            console.error("ERRORE:", error);
        }
    };
};

export const getRicoveroById = (ricoveroId) => {
    return async (dispatch) => {
        try {
            const response = await fetch(
                "https://localhost:7138/api/Ricovero/" + ricoveroId,
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
                    type: "GET_RICOVERO_BY_ID",
                    payload: data.ricovero,
                });
            } else {
                throw new Error("Errore nella response di getRicoveroById");
            }
        } catch (error) {
            console.error("ERRORE FETCH:" + error);
        }
    };
};