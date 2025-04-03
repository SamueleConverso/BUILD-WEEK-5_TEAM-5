export const postVisita = () => {
  return async () => {
    try {
      const response = await fetch("https://localhost:7138/api/Visita", {
        headers: {
          Authorization: "Bearer " + localStorage.getItem("jwtToken"),
          "Content-Type": "application/json",
        },
        method: "POST",
        body: JSON.stringify({}),
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
