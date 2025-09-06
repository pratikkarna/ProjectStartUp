using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;
using ProjectStartUp.Connection;

namespace DAL
{
    public class TestDAO
    {
        private readonly string _connectionString;

        // Inject ConnectionString via DI
        public TestDAO(ConnectionString sys)
        {
            _connectionString = sys.GetConnectionString();
        }

        public IEnumerable<TestDTO> GetAll()
        {
            var tests = new List<TestDTO>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT ID, Name, IsActive FROM Test", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tests.Add(new TestDTO
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            IsActive = reader.GetBoolean(2)
                        });
                    }
                }
            }

            return tests;
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
