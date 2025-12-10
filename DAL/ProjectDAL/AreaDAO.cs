using DTO;
using ProjectStartUp.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
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
                            Area_Code = Convert.ToInt32(reader.GetString(0)),
                            Area_Desc = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Area_ShortName = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        });
                    }
                }
            }

            return Area;
        }

        public AreaDTO GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"select Area_Code,Area_Desc,MArea_Code,Source_Module,Area_ShortName,CountryCode,MobileNo1,
                                              MobileNo2,Type FROM Area_Master 
                                              WHERE Area_Code = @Area_Code", conn))
            {
                cmd.Parameters.AddWithValue("@Area_Code", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AreaDTO
                        {
                            Area_Code = Convert.ToInt32(reader.GetString(0)),
                            Area_Desc = reader.GetString(1),
                            MArea_Code = reader.GetString(2),
                            Source_Module = reader.GetString(3),
                            Area_ShortName = reader.GetString(4),
                            CountryCode = reader.GetString(5),
                            MobileNo1 = reader.GetString(6),
                            MobileNo2 = reader.GetString(7),
                            Type = reader.GetString(8),
                           
                        };
                    }
                }
            }
            return null;
        }

        public void Save(AreaDTO model)
        {
            var now = DateTime.Now;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
          INSERT INTO area_master(Area_Code,Area_Desc,MArea_Code,Source_Module,Area_ShortName,CountryCode,MobileNo1,MobileNo2,Type)
          VALUES((SELECT ISNULL(MAX(CAST(Area_Code AS INT)), 0) + 1 FROM area_master),@Area_Desc,@MArea_Code,@Source_Module,
          @Area_ShortName,@CountryCode,@MobileNo1,@MobileNo2,@Type);
        ", conn))
            {
                cmd.Parameters.Add("@Area_Desc", SqlDbType.VarChar, 100).Value = model.Area_Desc;
                cmd.Parameters.Add("@MArea_Code", SqlDbType.VarChar, 20).Value = (object)model.MArea_Code ?? DBNull.Value;
                // cmd.Parameters.Add("@Source_Module", SqlDbType.VarChar, 20).Value =string.IsNullOrWhiteSpace(model.Source_Module) ? DBNull.Valuemodel.Source_Module;
               // cmd.Parameters.Add("@Source_Module", SqlDbType.VarChar, 20).Value =string.IsNullOrWhiteSpace(model.Source_Module)? DBNull.Value: model.Source_Module;
                cmd.Parameters.Add("@Source_Module", SqlDbType.VarChar, 20).Value = DBNull.Value;

                cmd.Parameters.Add("@Area_ShortName", SqlDbType.VarChar, 50).Value = (object)model.Area_ShortName ?? DBNull.Value;
                cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar, 5).Value = (object)model.CountryCode ?? DBNull.Value;
                cmd.Parameters.Add("@MobileNo1", SqlDbType.VarChar, 15).Value = (object)model.MobileNo1 ?? DBNull.Value;
                cmd.Parameters.Add("@MobileNo2", SqlDbType.VarChar, 15).Value = (object)model.MobileNo2 ?? DBNull.Value;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = DBNull.Value;


                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
