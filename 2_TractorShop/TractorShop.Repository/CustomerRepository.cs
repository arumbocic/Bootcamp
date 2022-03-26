using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TractorShop.Model;
using TractorShop.Repository.Common;

namespace TractorShop.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TractorShopDB;Integrated Security=True";

        #region GetAll
        public List<CustomerEntity> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<CustomerEntity> customers = new List<CustomerEntity>();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Customer;", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CustomerEntity customer = new CustomerEntity();

                        customer.Id = reader.GetGuid(0);
                        customer.FirstName = reader.GetString(1);
                        customer.LastName = reader.GetString(2);
                        customer.Address = reader.GetString(3);

                        customers.Add(customer);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            return customers;
        }
        #endregion

        #region GetById
        public CustomerEntity GetById(Guid Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            CustomerEntity customer = new CustomerEntity();

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Customer WHERE Id = '{Id}';", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (reader.Read())
                {
                    customer.Id = reader.GetGuid(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    customer.Address = reader.GetString(3);

                    reader.Close();
                    connection.Close();
                }
            }
            return customer;
        }
        #endregion

        #region Create
        public void Post(CustomerEntity postCustomer)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                if (postCustomer != null)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sqlQuery = "INSERT INTO Customer (FirstName, LastName, Address) VALUES (@FirstName, @Lastname, @Address);";
                    adapter.InsertCommand = new SqlCommand(sqlQuery, connection);

                    connection.Open();

                    adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = postCustomer.FirstName;
                    adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = postCustomer.LastName;
                    adapter.InsertCommand.Parameters.Add("@Address", SqlDbType.NVarChar).Value = postCustomer.Address;
                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
        #endregion

        #region Update
        public void UpdateById(Guid Id, CustomerEntity updateCustomer)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                string sqlQuery = $"SELECT * FROM Customer WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();                    

                    if (!string.IsNullOrEmpty(updateCustomer.FirstName))
                    {
                        sqlQuery = $"UPDATE Customer SET FirstName = @FirstName WHERE Id = '{Id}';";
                        adapter.InsertCommand = new SqlCommand(sqlQuery, connection);
                        adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = updateCustomer.FirstName;
                    }
                    if (!string.IsNullOrEmpty(updateCustomer.LastName))
                    {
                        sqlQuery = $"UPDATE Customer SET LastName = @LastName WHERE Id = '{Id}';";
                        adapter.InsertCommand = new SqlCommand(sqlQuery, connection);
                        adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = updateCustomer.LastName;
                    }
                    if (!string.IsNullOrEmpty(updateCustomer.Address))
                    {
                        sqlQuery = $"UPDATE Customer SET Address = @Address WHERE Id = '{Id}';";
                        adapter.InsertCommand = new SqlCommand(sqlQuery, connection);
                        adapter.InsertCommand.Parameters.Add("@Address", SqlDbType.NVarChar).Value = updateCustomer.Address;
                    }

                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
        #endregion

        #region Delete
        public void DeleteById(Guid Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                string sqlQuery = $"SELECT * FROM Customer WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    sqlQuery = $"DELETE FROM Customer WHERE Id = '{Id}';";
                    adapter.InsertCommand = new SqlCommand(sqlQuery, connection);
                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
        #endregion
    }
}
