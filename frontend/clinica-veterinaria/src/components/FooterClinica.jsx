const FooterClinica = () => {
  return (
    <div className="container-fluid bg-dark text-white-50 py-2" id="footer">
      <div className="row align-items-center pb-3 border-bottom border-secondary">
        <div className="col-4">
          <div className="d-flex align-items-center">
            <img
              src="/public/img/petcare2-removebg-preview.png"
              className="logoFooter"
            />
            <p className="mb-0 ms-1 fs-4 text-danger fw-semibold">
              Clinica Veterinaria
            </p>
          </div>
          <p>Via degli Animali Felici, 8, 40100</p>
          <p>Bologna, BO</p>
        </div>
        <div className="col-8">
          <div className="row">
            <div className="col-4">
              <div className=" my-2 d-flex flex-column">
                <h4 className="fs-5 text-white">Informativa</h4>
                <a href="#" className="small text-white-50 py-1">
                  Privacy policy
                </a>
                <a href="#" className="small text-white-50 py-1">
                  Cookie policy
                </a>
              </div>
            </div>
            <div className="col-4">
              <div className="my-2 d-flex flex-column">
                <h4 className="fs-5 text-white">Contatti</h4>
                <a href="#" className="small text-white-50 py-1">
                  info@clinicaveterinaria.com
                </a>
                <a href="#" className="small text-white-50 py-1">
                  0532 286101
                </a>
              </div>
            </div>
            <div className="col-4">
              <div className="my-2 d-flex flex-column">
                <h4 className="fs-5 text-white">Seguici sui social</h4>
                <div className="my-2 ps-2">
                  <a href="#" className="small text-white-50 py-1">
                    <i className="bi bi-instagram fs-4 pe-3"></i>
                  </a>
                  <a href="#" className="small text-white-50 py-1">
                    <i className="bi bi-facebook fs-4 px-3"></i>
                  </a>
                  <a href="#" className="small text-white-50 py-1">
                    <i className="bi bi-twitter-x fs-4 ps-3"></i>
                  </a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <p className="text-center py-2">
        Clinica Veterinaria ©. All Rights Reserved.{" "}
      </p>
    </div>
  );
};

export default FooterClinica;
