using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;
using ProjectStartUp.Connection;

namespace DAL
{
    public class AccountSubGroupDAO
    {
        private readonly string _connectionString;

        public AccountSubGroupDAO(ConnectionString sys)
        {
            _connectionString = sys.GetConnectionString();
        }

        public IEnumerable<AccountSubGroupDTO> GetAll()
        {
            var tests = new List<AccountSubGroupDTO>();
            using (var conn = new SqlConnection(_connectionString))
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



        public void Save(AccountSubGroupDTO model)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"INSERT INTO Test 
      (SGrpCode, SGrpDesc, SGrpShortName, Source_Module, Action_Date, Action_Time, Action_Miti, Action, IsActive) 
      VALUES 
      (@SGrpCode, @SGrpDesc, @SGrpShortName, @Source_Module, @Action_Date, @Action_Time, @Action_Miti, @Action, @IsActive)", conn))
            {
                cmd.Parameters.AddWithValue("@SGrpCode", model.SGrpCode);
                cmd.Parameters.AddWithValue("@SGrpDesc", model.SGrpDesc);
                cmd.Parameters.AddWithValue("@SGrpShortName", model.SGrpShortName);
                cmd.Parameters.AddWithValue("@Source_Module", model.Source_Module);
                cmd.Parameters.AddWithValue("@Action_Date", model.Action_Date);
                cmd.Parameters.AddWithValue("@Action_Time", model.Action_Time);
                cmd.Parameters.AddWithValue("@Action_Miti", model.Action_Miti);
                cmd.Parameters.AddWithValue("@Action", model.Action);
                cmd.Parameters.AddWithValue("@IsActive", model.IsActive);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }

    }
}
