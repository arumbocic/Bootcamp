import React, { Component } from 'react'

export default class AddCustomer extends Component {
  constructor (props) {
    super (props);
    this.state = {firstname: "", lastname: "", age: ""}
  }

  handleChange = (e) => {
    this.setState({ ...this.state, [e.target.name]: e.target.value });
  };

  handleSubmit = (e) => {
    e.preventDefault();
    this.props.addCustomer(this.state);
    this.setState({ firstname: "", lastname: "", age: "" });
  };

  render() {
    return (
      <form className="add-form" onSubmit={this.handleSubmit}>
        <div className="form-control">
          <label>First Name</label>
          <input
            type="text"
            name="firstname"
            placeholder="Add first name"
            value={this.state.firstname}
            onChange={this.handleChange}
            required
          />
        </div>
        <div className="form-control">
          <label>Last Name</label>
          <input
            type="text"
            name="lastname"
            placeholder="Add last name"
            value={this.state.lastname}
            onChange={this.handleChange}
            required
          />
        </div>
        <div className="form-control">
          <label>Age</label>
          <input
            type="text"
            name="age"
            placeholder="Add age"
            value={this.state.age}
            onChange={this.handleChange}
            required
          />
        </div>
  
        <input type="submit" value="Save Customer" className="btn btn-block" />
      </form>
    );
  }
}
