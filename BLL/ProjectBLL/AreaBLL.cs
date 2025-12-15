using DAL;
using DAL.ProjectDAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ProjectBLL
{
    public class AreaBLL
    {
        private readonly AreaDAO _dao;

        // Inject TestDAO via DI
        public AreaBLL(AreaDAO dao)
        {
            _dao = dao;
        }
        public IEnumerable<AreaDTO> GetAllArea() => _dao.GetAll();
        public AreaDTO getAreaById(int id) => _dao.GetById(id);
        public void AddArea(AreaDTO model) => _dao.Save(model);

        //public AreaDTO GetTestById(int id) => _dao.GetById(id);

        //public void AddTest(AreaDTO test) => _dao.Add(test);

        //public void UpdateTest(AreaDTO test) => _dao.Update(test);

        //public void DeleteTest(int id) => _dao.Delete(id);
    }
}
