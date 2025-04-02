const Home = () => {
  return (
    <div
      className="my-4 container-fluid d-flex flex-column justify-content-center"
      style={{ height: "64dvh" }}
    >
      <div className="text-center my-2">
        <img
          src="https://animalheroes.eu/wp-content/uploads/2023/03/unnamed.gif"
          className="cane"
          alt=""
        />
      </div>

      <h1 className="text-center display-4 fw-semibold m-0">
        Benvenut* nella <span className="text-danger">Clinica Veterinaria</span>
      </h1>
      <p className=" fs-4 text-center">
        Curiamo con amore i tuoi amici a quattro zampe.
      </p>
    </div>
  );
};

export default Home;
