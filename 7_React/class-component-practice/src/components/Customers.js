import Customer from "./Customer";

const Customers = ({ customers, onDelete }) => {
  return (
    <>
      {customers.map((customer) => (
        <Customer key={customer.id} customer={customer} onDelete={onDelete} />
      ))}
    </>
  );
};

export default Customers;
