//using System.Collections.Generic;
//using DTO;
//using DAL;

//namespace BLL
//{
//    public class TestBLL
//    {
//        private TestDAO dao = new TestDAO();

//        public IEnumerable<TestDTO> GetAllTests()
//        {
//            return dao.GetAll();
//        }

//        public TestDTO GetTestById(int id)
//        {
//            return dao.GetById(id);
//        }

//        public void AddTest(TestDTO test)
//        {
//            dao.Add(test);
//        }

//        public void UpdateTest(TestDTO test)
//        {
//            dao.Update(test);
//        }

//        public void DeleteTest(int id)
//        {
//            dao.Delete(id);
//        }
//    }
//}



using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;
using DAL;
//using System.IO;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace BLL
{
    public class TestBLL
    {
        private readonly TestDAO dao;

        // ✅ Parameterless constructor (for your controller)
        public TestBLL()
        {
            // Hardcoded connection string (works, but not best practice).
            string connectionString =
                  "Data Source=LAPTOP-3BNGUHJN\\SQLEXPRESS;Initial Catalog=PS00001;Integrated Security=True;Encrypt=False";

            dao = new TestDAO(connectionString);
        }




        // ✅ If you want flexibility, keep another constructor too
        public TestBLL(string connectionString)
        {
            dao = new TestDAO(connectionString);
        }

        public IEnumerable<TestDTO> GetAllTests()
        {
            return dao.GetAll();
        }

        public TestDTO GetTestById(int id)
        {
            return dao.GetById(id);
        }

        public void AddTest(TestDTO test)
        {
            dao.Add(test);
        }

        public void UpdateTest(TestDTO test)
        {
            dao.Update(test);
        }

        public void DeleteTest(int id)
        {
            dao.Delete(id);
        }
    }
}
