using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TractorShop.Model;
using TractorShop.Repository.Common;
using System.Threading.Tasks;
using System.Text;
using TractorShop.Model.Common;
using TractorModel.Common;

namespace TractorShop.Repository
{
    public class TractorModelRepository : ITractorModelRepository
    {
        static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TractorShopDB;Integrated Security=True";

        #region GetAll
        public async Task<List<ITractorModelEntity>> GetAllAsync(ISorting sorting, IPaging paging, IFilterTractorModel filtering)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<ITractorModelEntity> tractorModels = new List<ITractorModelEntity>();

            using (connection)
            {
                StringBuilder queryString = new StringBuilder();

                queryString.Append("SELECT * FROM TractorModel ");

                if (filtering != null)
                {
                    queryString.Append("WHERE 1=1");

                    if (filtering.Id > 0)
                    {
                        queryString.Append($"AND Id = {filtering.Id} ");
                    }
                    if (!string.IsNullOrWhiteSpace(filtering.Model))
                    {
                        queryString.Append($"AND Model LIKE '%{filtering.Model}%' ");
                    }
                    if (filtering.BrandId > 0)
                    {
                        queryString.Append($"AND BrandId = {filtering.BrandId} ");
                    }
                }

                if (sorting != null)
                {
                    queryString.Append($"ORDER BY '{sorting.SortBy}' {sorting.SortOrder} ");
                }

                if (paging != null)
                {
                    queryString.Append($"OFFSET({paging.PageNumber} - 1) * {paging.RecordsPerPage} ROWS FETCH NEXT {paging.RecordsPerPage} ROWS ONLY ");
                }

                SqlCommand command = new SqlCommand(queryString.ToString(), connection);


                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        ITractorModelEntity tractorModel = new TractorModelEntity();

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
        public async Task<ITractorModelEntity> GetByIdAsync(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            ITractorModelEntity tractorModel = new TractorModelEntity();

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM TractorModel WHERE Id = '{Id}';", connection);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                //TODO: check why this works, and didn't work with : if(reader.HasRows)
                //Does this reader.Read() "selects" first row, and that's why this works?
                if (await reader.ReadAsync())
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
        public async Task PostAsync(ITractorModelEntity postModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                if (postModel != null)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sqlQuery = "INSERT INTO TractorModel (Model, BrandId) VALUES (@Model, @BrandId);";
                    adapter.InsertCommand = new SqlCommand(sqlQuery, connection);

                    await connection.OpenAsync();

                    adapter.InsertCommand.Parameters.Add("@Model", SqlDbType.NVarChar).Value = postModel.Model;
                    adapter.InsertCommand.Parameters.Add("@BrandId", SqlDbType.Int).Value = postModel.BrandId;
                    await adapter.InsertCommand.ExecuteNonQueryAsync();

                    connection.Close();
                }
            }
        }
        #endregion

        #region Update
        public async Task UpdateByIdAsync(int Id, ITractorModelEntity updateModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                await connection.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string sqlQuery = $"UPDATE TractorModel SET BrandId = @BrandId, Model = @Model WHERE Id = {Id};";

                adapter.UpdateCommand = new SqlCommand(sqlQuery, connection);
                adapter.UpdateCommand.Parameters.Add("@Model", SqlDbType.NVarChar).Value = updateModel.Model;
                adapter.UpdateCommand.Parameters.Add("@BrandId", SqlDbType.Int).Value = updateModel.BrandId;

                await adapter.UpdateCommand.ExecuteNonQueryAsync();
                connection.Close();
            }
        }
        #endregion

        #region Delete
        public async Task DeleteByIdAsync(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                await connection.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string sqlQuery = $"DELETE FROM TractorModel WHERE Id = '{Id}';";
                adapter.InsertCommand = new SqlCommand(sqlQuery, connection);

                await adapter.InsertCommand.ExecuteNonQueryAsync();

                connection.Close();
            }
        }
        #endregion
    }
}
