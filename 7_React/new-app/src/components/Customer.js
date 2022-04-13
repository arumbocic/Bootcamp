const Customer = ({ customer }) => {
  return (
    <div className="customer">
      <h3>
        {customer.firstname} {customer.lastname}, Age: {customer.age}
      </h3>
    </div>
  );
};

export default Customer;
