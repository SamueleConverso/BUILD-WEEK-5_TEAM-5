import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { useEffect, useState } from "react";
import { jwtDecode } from "jwt-decode";
import { useLocation } from "react-router-dom";

const NavClinica = () => {
  const location = useLocation();
  const [role, setRole] = useState(null);
  const [isAuthorized, setIsAuthorized] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem("jwtToken");

    if (token) {
      try {
        const decodedToken = jwtDecode(token);
        const userRole =
          decodedToken[
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
          ];

        const currentTime = Date.now() / 1000;
        if (decodedToken.exp < currentTime) {
          setIsAuthorized(false);
          localStorage.removeItem("jwtToken");
          return;
        }

        setRole(userRole);
        setIsAuthorized(true);
      } catch {
        localStorage.removeItem("jwtToken");
      }
    } else {
      setIsAuthorized(false);
    }
  }, []);

  return (
    <>
      <Navbar expand="lg" bg="dark" data-bs-theme="dark">
        <Container>
          <Navbar.Brand href="/" className="py-0">
            <img
              src="/public/img/petcare2-removebg-preview.png"
              className="logo"
            />
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              {location.pathname == "/" ? (
                <Nav.Link
                  href="/"
                  className=" border-bottom border-2 text-white border-white"
                >
                  Home
                </Nav.Link>
              ) : (
                <Nav.Link href="/">Home</Nav.Link>
              )}

              {location.pathname == "/animali" ? (
                <Nav.Link
                  href="/animali"
                  className=" border-bottom border-2 text-white border-white"
                >
                  Animali
                </Nav.Link>
              ) : (
                <Nav.Link href="/animali">Animali</Nav.Link>
              )}

              {location.pathname == "/animaliSmarriti" ? (
                <Nav.Link
                  href="/animaliSmarriti"
                  className=" border-bottom border-2 text-white border-white"
                >
                  Animali Smarriti
                </Nav.Link>
              ) : (
                <Nav.Link href="/animaliSmarriti">Animali Smarriti</Nav.Link>
              )}

              {role === "Farmacista" &&
                (location.pathname == "/farmacia" ? (
                  <Nav.Link
                    href="/farmacia"
                    className=" border-bottom border-2 text-white border-white"
                  >
                    Farmacia
                  </Nav.Link>
                ) : (
                  <Nav.Link href="/farmacia">Farmacia</Nav.Link>
                ))}

              {role === "Veterinario" &&
                (location.pathname == "/clinica" ? (
                  <Nav.Link
                    href="/clinica"
                    className=" border-bottom border-2 text-white border-white"
                  >
                    Clinica
                  </Nav.Link>
                ) : (
                  <Nav.Link href="/clinica">Clinica</Nav.Link>
                ))}
            </Nav>
            <Nav>
              {isAuthorized ? (
                <p>{role}</p>
              ) : (
                <Nav.Link
                  href="/login"
                  className="btn btn-sm border border-white py-1 px-3 rounded-3 text-white"
                >
                  Login
                </Nav.Link>
              )}
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
};

export default NavClinica;
