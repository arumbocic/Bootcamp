import Customer from "./Customer";

const Customers = ({ customers }) => {
  return (
    <>
      {customers.map((customer) => (
        <Customer key={customer.id} customer={customer} />
      ))}
    </>
  );
};

export default Customers;
