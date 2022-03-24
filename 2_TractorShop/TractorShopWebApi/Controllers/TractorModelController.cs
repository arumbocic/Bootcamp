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
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                if (updateModel != null)
                {
                    conn.Open();

                    string sqlQuery1 = $"SELECT Id FROM TractorModel;";
                    SqlCommand command = new SqlCommand(sqlQuery1, conn);
                    SqlDataReader dr = command.ExecuteReader();




                    SqlDataAdapter da = new SqlDataAdapter();
                    string sqlQuery2 = $"UPDATE TABLE TractorModel SET Model = @Model, BrandId = @BrandId WHERE Id = '{updateModel.Id}';";
                    da.InsertCommand = new SqlCommand(sqlQuery2, conn);
                    da.InsertCommand.Parameters.Add("@Model", SqlDbType.NVarChar).Value = updateModel.Model;
                    da.InsertCommand.Parameters.Add("@BrandId", SqlDbType.Int).Value = updateModel.BrandId;
                    da.InsertCommand.ExecuteNonQuery();

                    conn.Close();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, $"There is no element with id {updateModel.Id}!");
                }
            }
        }

        //// DELETE api/values/5
        //[HttpDelete]
        //[Route("tractormodel/delete/{id}")]
        //public HttpResponseMessage DeleteById(Guid id)
        //{

        //    if (id == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "Provided an non existing id!");
        //    }

        //    var item = machines.Find(r => r.Id == id);
        //    machines.Remove(item);

        //    if (item == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, $"There is no element with id {id}!");
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, machines);

        //}
    }
}
