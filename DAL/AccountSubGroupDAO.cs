using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class AccountSubGroupDAO
    {
        private readonly string connectionString;

        public AccountSubGroupDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<AccountSubGroupDTO> GetAll()
        {
            var tests = new List<AccountSubGroupDTO>();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"SELECT SGrpCode,SGrpDesc,SGrpShortName,Source_Module,
                                            Action_Date,Action_Time,Action_Miti,IsActive FROM Account_Sub_Group", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tests.Add(new AccountSubGroupDTO
                        {
                            SGrpCode = reader.GetInt32(0),
                            SGrpDesc = reader.GetString(1),
                            SGrpShortName = reader.GetInt32(2),
                            Source_Module = reader.GetInt32(3),
                            Action_Date = reader.GetDateTime(4),
                            Action_Time = reader.GetDateTime(5),
                            Action_Miti = reader.GetDateTime(6),
                            IsActive = reader.GetBoolean(7)
                        });
                    }
                }
            }
            return tests;
        }



        public void Save(TestDTO test)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "INSERT INTO Test (Name, IsActive) VALUES (@Name, @IsActive)", conn))
            {
                cmd.Parameters.AddWithValue("@Name", test.Name);
                //  cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", test.IsActive);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
