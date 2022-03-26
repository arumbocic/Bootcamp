using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TractorShop.Model;
using TractorShop.Repository.Common;

namespace TractorShop.Repository
{
    public class TractorModelRepository : ITractorModelRepository
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TractorShopDB;Integrated Security=True";

        #region GetAll
        public List<TractorModelEntity> GetAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<TractorModelEntity> tractorModels = new List<TractorModelEntity>();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM TractorModel;", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TractorModelEntity tractorModel = new TractorModelEntity();

                        tractorModel.Id = reader.GetInt32(0);
                        tractorModel.Model = reader.GetString(1);
                        tractorModel.CatalogueCode = reader.GetGuid(2);
                        tractorModel.BrandId = reader.GetInt32(3);

                        tractorModels.Add(tractorModel);
                    }

                    reader.Close();
                    connection.Close();
                }
            }
            return tractorModels;
        }
        #endregion

        #region GetById
        public TractorModelEntity GetById(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            TractorModelEntity tractorModel = new TractorModelEntity();

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM TractorModel WHERE Id = '{Id}';", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (reader.Read())
                {
                    tractorModel.Id = reader.GetInt32(0);
                    tractorModel.Model = reader.GetString(1);
                    tractorModel.CatalogueCode = reader.GetGuid(2);
                    tractorModel.BrandId = reader.GetInt32(3);

                    reader.Close();
                    connection.Close();
                }
            }
            return tractorModel;
        }
        #endregion

        #region Create
        public void Post(TractorModelEntity postModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                if (postModel != null)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sqlQuery = "INSERT INTO TractorModel (Model, BrandId) VALUES (@Model, @BrandId);";
                    adapter.InsertCommand = new SqlCommand(sqlQuery, connection);

                    connection.Open();

                    adapter.InsertCommand.Parameters.Add("@Model", SqlDbType.NVarChar).Value = postModel.Model;
                    adapter.InsertCommand.Parameters.Add("@BrandId", SqlDbType.Int).Value = postModel.BrandId;
                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
        #endregion

        #region Update
        public void UpdateById(int Id, TractorModelEntity updateModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                string sqlQuery = $"SELECT * FROM TractorModel WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();                    

                    if (!string.IsNullOrEmpty(updateModel.Model))
                    {
                        sqlQuery = $"UPDATE TractorModel SET Model = @Model WHERE Id = '{Id}';";
                        adapter.InsertCommand = new SqlCommand(sqlQuery, connection);
                        adapter.InsertCommand.Parameters.Add("@Model", SqlDbType.NVarChar).Value = updateModel.Model;
                    }
                    if (updateModel.BrandId > 0)
                    {
                        sqlQuery = $"UPDATE TractorModel SET BrandId = @BrandId WHERE Id = '{Id}';";
                        adapter.InsertCommand = new SqlCommand(sqlQuery, connection);
                        adapter.InsertCommand.Parameters.Add("@BrandId", SqlDbType.Int).Value = updateModel.BrandId;
                    }
                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
        #endregion

        #region Delete
        public void DeleteById(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                string sqlQuery = $"SELECT * FROM TractorModel WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    sqlQuery = $"DELETE FROM TractorModel WHERE Id = '{Id}';";
                    adapter.InsertCommand = new SqlCommand(sqlQuery, connection);
                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
        #endregion
    }
}