import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "bootstrap-icons/font/bootstrap-icons.min.css";
import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import CreaAnimaleSmarrito from './components/CreaAnimaleSmarrito';
import Home from "./components/Home";
import LoginClinica from "./components/LoginClinica";
import RegisterClinica from "./components/RegisterClinica";
import FooterClinica from "./components/FooterClinica";
import NavClinica from "./components/NavClinica";
import AnimaleManagementPage from "./components/AnimaleManagementPage";
import { Link } from "react-router-dom";
import AnimaleDetails from "./components/AnimaleDetails";

function App() {
  return (
    <Router>
      <Routes>
      <NavClinica />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/clinica" element={<AnimaleManagementPage />} />
        <Route path="/clinica/animali-smarriti" element={<CreaAnimaleSmarrito />} />
        <Route
          path="/animale-details/:animaleId"
          element={<AnimaleDetails />}
        />
        <Route path="/login" element={<LoginClinica />} />
        <Route path="/register" element={<RegisterClinica />} />
      </Routes>
      <FooterClinica />
    </Router>
  );
}

export default App;
