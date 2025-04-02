import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import CreaAnimaleSmarrito from './components/CreaAnimaleSmarrito';

function App() {
  return (
    <Router>
      <Routes>
      <Route path="/" element={<CreaAnimaleSmarrito />} />
      </Routes>
    </Router>
  );
}

export default App;
