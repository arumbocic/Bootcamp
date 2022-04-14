import { FaTimes } from 'react-icons/fa'

const Customer = ({ customer, onDelete }) => {
  return (
    <div className="customer">
      <h3 >
        {customer.firstname} {customer.lastname}, Age: {customer.age}
        <FaTimes style={{color: 'black', cursor: 'pointer'}} onClick={() => onDelete(customer.id)} />
      </h3>
    </div>
  );
};

export default Customer;
