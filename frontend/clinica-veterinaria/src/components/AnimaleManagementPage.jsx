import AddAnimaleForm from "./AddAnimaleForm";
import AnimaliList from "./AnimaliList";

function AnimaleManagementPage() {
  return (
    <div className=" d-flex flex-column align-items-center">
      <AddAnimaleForm />
      <AnimaliList />
    </div>
  );
}

export default AnimaleManagementPage;
