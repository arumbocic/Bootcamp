import { useState } from "react";
import Header from "./components/Header";
import Customers from "./components/Customers";
import AddCustomer from "./components/AddCustomer";

const App = () => {
  const [customers, setCustomers] = useState([
    {
      id: 1,
      firstname: "John",
      lastname: "Doe",
      age: "27",
    },
  ]);

  const addCustomer = (customer) => {
    const id = customers.length + 1;
    const newCustomer = { id, ...customer };
    setCustomers([...customers, newCustomer]);
  };

  return (
    <div className="container">
      <Header />
      <AddCustomer addPerson={addCustomer} />
      <Customers customers={customers} />
    </div>
  );
};

export default App;
