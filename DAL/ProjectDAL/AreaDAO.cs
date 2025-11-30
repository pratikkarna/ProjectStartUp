using DTO;
using ProjectStartUp.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ProjectDAL
{
    public class AreaDAO
    {

        private readonly string _connectionString;

        // Inject ConnectionString via DI
        public AreaDAO(ConnectionString sys)
        {
            _connectionString = sys.GetConnectionString();
        }

        public IEnumerable<AreaDTO> GetAll()
        {
            var Area = new List<AreaDTO>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT Area_Code,Area_Desc,MArea_Code,Source_Module,Area_ShortName,CountryCode,MobileNo1,MobileNo2,Type FROM Area_Master", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Area.Add(new AreaDTO
                        {
                            ID = reader.GetInt32(0),
                            Area_Code = reader.GetString(1),
                            Area_Desc = reader.GetString(2),
                            Area_ShortName = reader.GetString(3),
                            IsActive = reader.GetBoolean(4)
                        });
                    }
                }
            }

            return Area;
        }

        public TestDTO GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT ID, Name, CreatedDate, IsActive FROM Tests WHERE ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TestDTO
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            CreatedDate = reader.GetDateTime(2),
                            IsActive = reader.GetBoolean(3)
                        };
                    }
                }
            }
            return null;
        }

        public void Add(TestDTO test)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("INSERT INTO Test (Name, IsActive) VALUES (@Name, @IsActive)", conn))
            {
                cmd.Parameters.AddWithValue("@Name", test.Name);
                cmd.Parameters.AddWithValue("@IsActive", test.IsActive);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(TestDTO test)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("UPDATE Tests SET Name = @Name, IsActive = @IsActive WHERE ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", test.ID);
                cmd.Parameters.AddWithValue("@Name", test.Name);
                cmd.Parameters.AddWithValue("@IsActive", test.IsActive);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("DELETE FROM Tests WHERE ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
