using DTO;
using ProjectStartUp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ProjectDAL
{
    public class AccountGroupDAO
    {
        private readonly string _connectionString;

        public AccountGroupDAO(ConnectionString sys)
        {
            _connectionString = sys.GetConnectionString();
        }

        public IEnumerable<AccountGroupDTO> GetAll()
        {
            var tests = new List<AccountGroupDTO>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"select Ac_GrpCode,Ac_Desc,Ac_Type,BP_Type,ac_schedul from Account_Group", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tests.Add(new AccountGroupDTO
                        {
                            Ac_GrpCode = Convert.ToInt32(reader.GetString(0)),                // was GetInt32
                            Ac_Desc = reader.GetString(1),
                            Ac_Type = reader.GetString(2)[0],             // safer than GetChar
                            BP_Type = reader.GetString(3)[0],             // safer than GetChar
                            Ac_Schedul = reader.GetString(4)
                        });
                    }
                }
            }
            return tests;
        }

        public void Save(AccountGroupDTO model)
        {
            var now = DateTime.Now;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
            INSERT INTO Account_Group
            (Ac_GrpCode, Ac_Desc, Ac_Type, BP_Type, Source_Module, MainGroup,
             Action_Date, Action_Time, Action_Miti, Action, Ac_Schedul)
            VALUES
            ((SELECT ISNULL(MAX(CAST(Ac_GrpCode AS INT)), 0) + 1 FROM Account_Group),
             @Ac_Desc, @Ac_Type, @BP_Type, @Source_Module, @MainGroup,
             @Action_Date, @Action_Time, @Action_Miti, @Action, @Ac_Schedul);
        ", conn))
            {
                cmd.Parameters.Add("@Ac_Desc", SqlDbType.VarChar, 50).Value = model.Ac_Desc;
                cmd.Parameters.Add("@Ac_Type", SqlDbType.Char, 1).Value = model.Ac_Type;
                cmd.Parameters.Add("@BP_Type", SqlDbType.Char, 1).Value = (object)model.BP_Type ?? DBNull.Value;
                cmd.Parameters.Add("@Source_Module", SqlDbType.VarChar, 20).Value = (object)model.Source_Module ?? DBNull.Value;
                cmd.Parameters.Add("@MainGroup", SqlDbType.VarChar, 100).Value = (object)model.MainGroup ?? DBNull.Value;

                cmd.Parameters.Add("@Action_Date", SqlDbType.DateTime).Value = now;
                cmd.Parameters.Add("@Action_Time", SqlDbType.DateTime).Value = now;

                cmd.Parameters.Add("@Action_Miti", SqlDbType.VarChar, 10)
                    .Value = now.ToString("yyyy-MM-dd");

                cmd.Parameters.Add("@Action", SqlDbType.VarChar, 2).Value = model.Action;
                cmd.Parameters.Add("@Ac_Schedul", SqlDbType.VarChar, 3).Value = model.Ac_Schedul;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public AccountGroupDTO GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"SELECT Ac_GrpCode, Ac_Desc, Ac_Type, BP_Type, Source_Module, MainGroup, Action_Date, Action_Time,
                                              Action_Miti, Action, Ac_Schedul 
                                              FROM Account_Group 
                                              WHERE Ac_GrpCode = @Ac_GrpCode", conn))
            {
                cmd.Parameters.AddWithValue("@Ac_GrpCode", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AccountGroupDTO
                        {
                            Ac_GrpCode = Convert.ToInt32(reader.GetString(0)),
                            Ac_Desc = reader.GetString(1),
                            Ac_Type = reader.GetChar(2),
                            BP_Type = reader.GetChar(3),
                            Source_Module = reader.GetString(4),
                            MainGroup = reader.GetString(5),
                            Action_Date = reader.GetDateTime(6),
                            Action_Time = reader.GetDateTime(7),
                            Action_Miti = reader.GetDateTime(8),
                            Action = reader.GetString(9),
                            Ac_Schedul = reader.GetString(10)
                        };
                    }
                }
            }
            return null;
        }

        // Delete
        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("DELETE FROM Account_Group WHERE Ac_GrpCode = @Ac_GrpCode", conn))
            {
                cmd.Parameters.AddWithValue("@Ac_GrpCode", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
