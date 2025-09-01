using DAL;
using DTO;
using ProjectStartUp.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountSubGroupBLL
    {

        private readonly TestDAO dao;
        private readonly ConnectionString Sys;

        public AccountSubGroupBLL()
        {
            Sys = new ConnectionString();

            string connectionString = Sys.GetConnectionString();

           // dao = new AccountSubGroupDAO(connectionString);
        }

        //public AccountSubGroupBLL(string connectionString)
        //{
        //    dao = new AccountSubGroupDAO(connectionString);
        //}

        //public IEnumerable<AccountSubGroupDTO> GetAllTests() => dao.GetAll();

        //public AccountSubGroupDTO GetTestById(int id) => dao.GetById(id);

        //public void AddTest(AccountSubGroupDTO test) => dao.Add(test);

        //public void UpdateTest(AccountSubGroupDTO test) => dao.Update(test);

        //public void DeleteTest(int id) => dao.Delete(id);
    }
}
