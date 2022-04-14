import React, { Component } from "react";
import Header from "./components/Header";
import Customers from "./components/Customers";
import AddCustomer from "./components/AddCustomer";
import { nanoid } from 'nanoid'

export default class App extends Component {
  constructor() {
    super();
    this.state = {
        customers: [],
    };
  }

  // ADD CUSTOMER
  addCustomer = (customer) => {
    const id = nanoid();
    const newCustomer = { id, ...customer };
    this.setState({customers: [...this.state.customers, newCustomer]});
  };

  // DELETE CUSTOMER    
  deleteCustomer = (id) => {
    this.setState({customers: this.state.customers.filter((customer) => customer.id !== id)});
  }

  render() {
    return (
      <div className="container">
        <Header />
        <AddCustomer addCustomer={this.addCustomer} />
        {this.state.customers.length > 0 ? (<Customers customers={this.state.customers} onDelete={this.deleteCustomer} />) : ('No Customers To Show.')}
      </div>
    );
  }
}