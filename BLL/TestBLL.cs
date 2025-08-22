using System.Collections.Generic;
using DTO;
using DAL;
using Microsoft.Extensions.Configuration;

using System.IO;
using ProjectStartUp.Connection;

namespace BLL
{
    public class TestBLL
    {
        private readonly TestDAO dao;
        private readonly ConnectionString Sys;

        public TestBLL()
        {
            Sys = new ConnectionString();

            // ✅ use public method instead of Sys.ConnectionString()
            string connectionString = Sys.GetConnectionString();

            dao = new TestDAO(connectionString);
        }

        // ✅ Flexible constructor (if you want to pass your own connection string)
        public TestBLL(string connectionString)
        {
            dao = new TestDAO(connectionString);
        }

        public IEnumerable<TestDTO> GetAllTests() => dao.GetAll();

        public TestDTO GetTestById(int id) => dao.GetById(id);

        public void AddTest(TestDTO test) => dao.Add(test);

        public void UpdateTest(TestDTO test) => dao.Update(test);

        public void DeleteTest(int id) => dao.Delete(id);
    }
}
