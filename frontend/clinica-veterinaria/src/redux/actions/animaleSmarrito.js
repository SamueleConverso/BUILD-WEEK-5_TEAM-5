const API_URL = 'http://localhost:5284/api/AnimaleSmarrito';

export const createAnimaleSmarritoAPI = async (animaleSmarritoData, dispatch) => {
  
  dispatch({ type: 'CREATE_ANIMALE_SMARRITO_REQUEST' });
  
  try {
      const response = await fetch(API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ0b21tYXNvQGNpYW8uaXQiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidG9tbWFzbyBtYW5jaW5pIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiJhZDZjZjdiNS1iMWRlLTQzYzQtYmYxMy0xYmVlNjYyYzYyN2UiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOlsiVmV0ZXJpbmFyaW8iLCJmYXJtYWNpc3RhIl0sImV4cCI6MTc0MzY1MzgwMywiaXNzIjoiaHR0cHM6Ly9jbGluaWNhLXZldGVyaW5hcmlhLmNvbSIsImF1ZCI6Imh0dHBzOi8vY2xpbmljYS12ZXRlcmluYXJpYS1kYXNoYm9hcmQuY29tIn0.WZxGcg9BLVZpMp5Ut1OT0RcylvYVHtTU-NjnFGkBDgk`
      },
      body: JSON.stringify({
        nome: animaleSmarritoData.nome,
        specie: animaleSmarritoData.specie,
        colore: animaleSmarritoData.colore,
        microchip: animaleSmarritoData.microchip,
        numeroMicrochip: animaleSmarritoData.numeroMicrochip
      })
    });
    
    if (!response.ok) {
      throw new Error(`Errore ${response.status}: ${response.statusText}`);
    }
    
    const data = await response.json();
    
    dispatch({ type: 'CREATE_ANIMALE_SMARRITO_SUCCESS' });
    
    return data;
  } catch (error) {
    console.error('Errore durante la creazione:', error);
    throw error;
  }
};