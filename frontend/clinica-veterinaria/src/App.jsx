import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import AnimaleManagementPage from "./components/AnimaleManagementPage";
import { Link } from "react-router-dom";
import AnimaleDetails from "./components/AnimaleDetails";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Link to="/animali">Animali</Link>} />
        <Route path="/animali" element={<AnimaleManagementPage />} />
        <Route
          path="/animale-details/:animaleId"
          element={<AnimaleDetails />}
        />
      </Routes>
    </Router>
  );
}

export default App;
