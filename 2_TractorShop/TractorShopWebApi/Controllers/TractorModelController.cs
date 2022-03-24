using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TractorShopWebApi.Models;

namespace TractorShopWebApi.Controllers
{
    public class TractorModelController : ApiController
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TractorShopDB;Integrated Security=True";

        // GET api/values
        [HttpGet]
        [Route("tractormodel/getall")]
        public HttpResponseMessage GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM TractorModel;", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<TractorModel> tractorModels = new List<TractorModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TractorModel tractorModel = new TractorModel();

                        tractorModel.Id = reader.GetInt32(0);
                        tractorModel.Model = reader.GetString(1);
                        tractorModel.Code = reader.GetGuid(2);
                        tractorModel.BrandId = reader.GetInt32(3);

                        tractorModels.Add(tractorModel);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, tractorModels);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The list is empty!");
                }
                reader.Close();
                connection.Close();
            }
        }

        // GET api/values/5
        //TODO: Postavi stupac Model na Unique values
        [HttpGet]
        [Route("tractormodel/get/{id}")]
        public HttpResponseMessage GetById(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM TractorModel WHERE Id = '{Id}';", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (reader.Read())
                {
                    TractorModel tractorModel = new TractorModel();

                    tractorModel.Id = reader.GetInt32(0);
                    tractorModel.Model = reader.GetString(1);
                    tractorModel.Code = reader.GetGuid(2);
                    tractorModel.BrandId = reader.GetInt32(3);

                    reader.Close();
                    connection.Close();

                    return Request.CreateResponse(HttpStatusCode.OK, tractorModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no TractorModel with that id.");
                }
            }
        }


        // POST api/values
        [HttpPost]
        [Route("tractormodel/set")]
        public HttpResponseMessage Post(TractorModel postModel)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                if (postModel != null)
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    string sqlQuery = "INSERT INTO TractorModel (Model, BrandId) VALUES (@Model, @BrandId);";
                    da.InsertCommand = new SqlCommand(sqlQuery, conn);

                    conn.Open();

                    da.InsertCommand.Parameters.Add("@Model", SqlDbType.NVarChar).Value = postModel.Model;
                    da.InsertCommand.Parameters.Add("@BrandId", SqlDbType.Int).Value = postModel.BrandId;
                    da.InsertCommand.ExecuteNonQuery();

                    conn.Close();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an empty object!");
                }
            }
        }


        // PUT api/values/5
        [HttpPut]
        [Route("tractormodel/update/{id}")]
        public HttpResponseMessage UpdateById(int Id, TractorModel updateModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                string sqlQuery = $"SELECT * FROM TractorModel WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (reader.Read())
                {
                    connection.Close();
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    sqlQuery = $"UPDATE TractorModel SET Model = @Model, BrandId = @BrandId WHERE Id = '{Id}';";
                    da.InsertCommand = new SqlCommand(sqlQuery, connection);

                    da.InsertCommand.Parameters.Add("@Model", SqlDbType.NVarChar).Value = updateModel.Model;
                    da.InsertCommand.Parameters.Add("@BrandId", SqlDbType.Int).Value = updateModel.BrandId;
                    da.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no TractorModel with that id.");
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("tractormodel/delete/{id}")]
        public HttpResponseMessage DeleteById(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                string sqlQuery = $"SELECT * FROM TractorModel WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (reader.Read())
                {
                    connection.Close();
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    sqlQuery = $"DELETE FROM TractorModel WHERE Id = '{Id}';";
                    da.InsertCommand = new SqlCommand(sqlQuery, connection);
                    da.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, "TractorModel is deleted.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no TractorModel with that id.");
                }
            }

        }
    }
}
