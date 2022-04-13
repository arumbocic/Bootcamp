import { useState } from "react";

const AddCustomer = ({ addPerson }) => {
  const [person, setPerson] = useState({
    firstname: "",
    lastname: "",
    age: "",
  });

  const handleChange = (e) => {
    setPerson({ ...person, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setPerson({ firstname: "", lastname: "", age: "" });
    addPerson(person);
  };

  return (
    <form className="add-form" onSubmit={handleSubmit}>
      <div className="form-control">
        <label>First Name</label>
        <input
          type="text"
          name="firstname"
          placeholder="Add first name"
          value={person.firstname}
          onChange={handleChange}
        />
      </div>
      <div className="form-control">
        <label>Last Name</label>
        <input
          type="text"
          name="lastname"
          placeholder="Add last name"
          value={person.lastname}
          onChange={handleChange}
        />
      </div>
      <div className="form-control">
        <label>Age</label>
        <input
          type="text"
          name="age"
          placeholder="Add age"
          value={person.age}
          onChange={handleChange}
        />
      </div>

      <input type="submit" value="Save Customer" className="btn btn-block" />
    </form>
  );
};

export default AddCustomer;
