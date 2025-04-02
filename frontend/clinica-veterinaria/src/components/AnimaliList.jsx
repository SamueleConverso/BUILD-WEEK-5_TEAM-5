/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getAnimali } from "../redux/actions/animale.js";
import AnimaleSingleComponent from "./AnimaleSingleComponent.jsx";

function AnimaliList() {
  const dispatch = useDispatch();

  const animali = useSelector((state) => state.animali);

  useEffect(() => {
    dispatch(getAnimali());
  }, []);

  return (
    <>
      <div className="container d-flex justify-content-center">
        <div className="row row-cols-1 row-cols-md-2 row-cols-lg-4 g-4">
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
    </>
  );
}

export default AnimaliList;
