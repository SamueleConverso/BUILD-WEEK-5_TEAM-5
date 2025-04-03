import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "bootstrap-icons/font/bootstrap-icons.min.css";
import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import CreaAnimaleSmarrito from "./components/CreaAnimaleSmarrito";
import Home from "./components/Home";
import LoginClinica from "./components/LoginClinica";
import RegisterClinica from "./components/RegisterClinica";
import FooterClinica from "./components/FooterClinica";
import NavClinica from "./components/NavClinica";
import AnimaleDetails from "./components/AnimaleDetails";
import ClinicaGenerale from "./components/ClinicaGenerale";
import AddAnimaleForm from "./components/AddAnimaleForm";
import AnimaliList from "./components/AnimaliList";
import RicoveriList from "./components/RicoveriList";
import RicoveroForm from "./components/RicoveroForm";
import VisiteList from "./components/VisiteList";
import VisitaForm from "./components/VisitaForm";
import EditAnimale from "./components/EditAnimale";
import AnimaleSmarritoList from "./components/AnimaleSmarritoList";
import AnimaleSmarritoDetails from "./components/AnimaleSmarritoDetails";

function App() {
  return (
    <Router>
      <NavClinica />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route
          path="/clinica"
          //path="/animali"
          element={<ClinicaGenerale />}
        />
        <Route path="/clinica/formAnimali" element={<AddAnimaleForm />} />
        <Route path="/clinica/listaAnimali" element={<AnimaliList />} />
        <Route
          path="/clinica/formAnimaliSmarriti"
          element={<CreaAnimaleSmarrito />}
        />
        <Route
          path="/clinica/animaliSmarriti"
          element={<AnimaleSmarritoList />}
        />
        <Route
          path="/clinica/animaliSmarriti/:id"
          element={<AnimaleSmarritoDetails />}
        />
        <Route
          path="/animale-details/:animaleId"
          element={<AnimaleDetails />}
        />
        <Route path="/clinica/formRicovero" element={<RicoveroForm />} />
        <Route path="/clinica/listaRicoveri" element={<RicoveriList />} />
        <Route path="/clinica/formVisita" element={<VisitaForm />} />
        <Route path="/clinica/listaVisite" element={<VisiteList />} />
        <Route path="/animale-edit/:animaleId" element={<EditAnimale />} />
        <Route path="/login" element={<LoginClinica />} />
        <Route path="/register" element={<RegisterClinica />} />
      </Routes>
      <FooterClinica />
    </Router>
  );
}

export default App;
