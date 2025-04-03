/* eslint-disable react-hooks/exhaustive-deps */
import { useEffect } from "react";
import { getRicoveri } from "../redux/actions/ricovero";
import { useDispatch } from "react-redux";

const RicoveriList = () => {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(getRicoveri());
  }, []);
};

export default RicoveriList;
