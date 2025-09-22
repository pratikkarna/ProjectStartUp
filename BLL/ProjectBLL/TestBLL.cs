using System.Collections.Generic;
using DTO;
using DAL;
using ProjectStartUp.Connection;

namespace BLL
{
    public class TestBLL
    {
        private readonly TestDAO _dao;

        // Inject TestDAO via DI
        public TestBLL(TestDAO dao)
        {
            _dao = dao;
        }

        public IEnumerable<TestDTO> GetAllTests() => _dao.GetAll();

        public TestDTO GetTestById(int id) => _dao.GetById(id);

        public void AddTest(TestDTO test) => _dao.Add(test);

        public void UpdateTest(TestDTO test) => _dao.Update(test);

        public void DeleteTest(int id) => _dao.Delete(id);
    }
}
