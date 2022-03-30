using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TractorShop.Model;
using TractorShop.Repository.Common;

namespace TractorShop.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TractorShopDB;Integrated Security=True";

        #region GetAll
        public async Task<List<CustomerEntity>> GetAllAsync()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<CustomerEntity> customers = new List<CustomerEntity>();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Customer;", connection);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
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
        public async Task<CustomerEntity> GetByIdAsync(Guid Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            CustomerEntity customer = new CustomerEntity();

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Customer WHERE Id = '{Id}';", connection);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (await reader.ReadAsync())
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
        public async Task PostAsync(CustomerEntity postCustomer)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                if (postCustomer != null)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sqlQuery = "INSERT INTO Customer (FirstName, LastName, Address) VALUES (@FirstName, @Lastname, @Address);";
                    adapter.InsertCommand = new SqlCommand(sqlQuery, connection);

                    await connection.OpenAsync();

                    adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = postCustomer.FirstName;
                    adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = postCustomer.LastName;
                    adapter.InsertCommand.Parameters.Add("@Address", SqlDbType.NVarChar).Value = postCustomer.Address;
                    await adapter.InsertCommand.ExecuteNonQueryAsync();

                    connection.Close();
                }
            }
        }
        #endregion

        #region Update
        public async Task UpdateByIdAsync(Guid Id, CustomerEntity updateCustomer)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                await connection.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string sqlQuery = $"UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Address = @Address WHERE Id = {Id};";

                adapter.UpdateCommand = new SqlCommand(sqlQuery, connection);
                adapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = updateCustomer.FirstName;
                adapter.UpdateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = updateCustomer.LastName;
                adapter.UpdateCommand.Parameters.Add("@Address", SqlDbType.NVarChar).Value = updateCustomer.Address;

                await adapter.UpdateCommand.ExecuteNonQueryAsync();
                connection.Close();
            }
        }
        #endregion

        #region Delete
        public async Task DeleteByIdAsync(Guid Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                await connection.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string sqlQuery = $"DELETE FROM Customer WHERE Id = '{Id}';";
                adapter.InsertCommand = new SqlCommand(sqlQuery, connection);

                await adapter.InsertCommand.ExecuteNonQueryAsync();

                connection.Close();
            }
        }
        #endregion
    }
}

