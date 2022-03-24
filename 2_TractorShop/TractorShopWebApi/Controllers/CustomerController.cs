using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TractorShopWebApi.Models;

namespace TractorShopWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TractorShopDB;Integrated Security=True";

        // GET api/values
        [HttpGet]
        [Route("customer/getall")]
        public HttpResponseMessage GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Customer;", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Customer> customers = new List<Customer>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();

                        customer.Id = reader.GetGuid(0);
                        customer.FirstName = reader.GetString(1);
                        customer.LastName = reader.GetString(2);
                        customer.Address = reader.GetString(3);

                        customers.Add(customer);
                    }

                    reader.Close();
                    connection.Close();

                    return Request.CreateResponse(HttpStatusCode.OK, customers);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The list is empty!");
                }
            }
        }

        // GET api/values/2
        [HttpGet]
        [Route("customer/get/{id}")]
        public HttpResponseMessage GetById(Guid Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Customer WHERE Id = '{Id}';", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (reader.Read())
                {
                    Customer customer = new Customer();

                    customer.Id = reader.GetGuid(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    customer.Address = reader.GetString(3);

                    reader.Close();
                    connection.Close();

                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no Customer with that id.");
                }
            }
        }

        // POST api/values
        [HttpPost]
        [Route("customer/set")]
        public HttpResponseMessage Post(Customer postCustomer)
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

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
                }
            }
        }


        // PUT api/values/2
        [HttpPut]
        [Route("customer/update/{id}")]
        public HttpResponseMessage PutById(Guid Id, Customer updateCustomer)
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
                    sqlQuery = $"UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Address = @Address WHERE Id = '{Id}';";
                    adapter.InsertCommand = new SqlCommand(sqlQuery, connection);

                    adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = updateCustomer.FirstName;
                    adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = updateCustomer.LastName;
                    adapter.InsertCommand.Parameters.Add("@Address", SqlDbType.NVarChar).Value = updateCustomer.Address;
                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no Customer with that id.");
                }
            }
        }

        // DELETE api/values/2
        [HttpDelete]
        [Route("customer/delete/{id}")]
        public HttpResponseMessage DeleteById(Guid Id)
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

                    return Request.CreateResponse(HttpStatusCode.OK, "Customer is deleted.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no Customer with that id.");
                }
            }
        }
    }
}
