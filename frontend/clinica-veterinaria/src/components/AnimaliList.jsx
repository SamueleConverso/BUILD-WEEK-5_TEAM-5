/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getAnimali } from "../redux/actions/animale.js";
import AnimaleSingleComponent from "./AnimaleSingleComponent.jsx";

function AnimaliList() {
  const dispatch = useDispatch();

  const animali = useSelector((state) => state.animale.animali);

  useEffect(() => {
    dispatch(getAnimali());
  }, []);

  return (
    <div className="container my-5">
      <div className="d-flex justify-content-center align-items-center mb-4">
        <h2>Animali</h2>
      </div>
      <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
        {animali.map((animale) => {
          return (
            <div
              className="col d-flex justify-content-center"
              key={animale.animaleId}
            >
              <AnimaleSingleComponent animale={animale} />
            </div>
          );
        })}
      </div>
    </div>
  );
}

export default AnimaliList;
