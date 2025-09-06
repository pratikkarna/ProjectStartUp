using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class AccountSubGroupBLL
    {
        private readonly AccountSubGroupDAO _dao;

        public AccountSubGroupBLL(AccountSubGroupDAO dao)
        {
            _dao = dao;
        }

        public IEnumerable<AccountSubGroupDTO> GetAllAccountSbuGroup() => _dao.GetAll();
        public void AddAccountSubGroup(AccountSubGroupDTO model) => _dao.Save(model);
    }
}





























//using System.Collections.Generic;
//using DTO;
//using DAL;
//using Microsoft.Extensions.Configuration;

//using System.IO;
//using ProjectStartUp.Connection;

//namespace BLL
//{
//    public class AccountSubGroupBLL
//    {

//        private readonly AccountSubGroupDAO dao;
//        private readonly ConnectionString Sys;

//        public AccountSubGroupBLL()
//        {
//            Sys = new ConnectionString();

//            string connectionString = Sys.GetConnectionString();

//            dao = new AccountSubGroupDAO(connectionString);
//        }

//        public AccountSubGroupBLL(string connectionString)
//        {
//            dao = new AccountSubGroupDAO(connectionString);
//        }

//        public IEnumerable<AccountSubGroupDTO> GetAllAccountSbuGroup() => dao.GetAll();

//        //public AccountSubGroupDTO GetTestById(int id) => dao.GetById(id);

//        public void AddTest(AccountSubGroupDTO accountSubGroup) => dao.Save(accountSubGroup);

//        //public void UpdateTest(AccountSubGroupDTO test) => dao.Update(test);

//        //public void DeleteTest(int id) => dao.Delete(id);
//    }
//}




