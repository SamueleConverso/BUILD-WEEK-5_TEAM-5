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