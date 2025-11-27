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
    public class AccountGroupBLL
    {
        private readonly AccountGroupDAO _dao;
        public AccountGroupBLL(AccountGroupDAO dao)
        {
            _dao = dao;
        }

        public IEnumerable<AccountGroupDTO> GetAllAccountGroup() => _dao.GetAll();
        public void AddAccountGroup(AccountGroupDTO model) => _dao.Save(model);
        public AccountGroupDTO GetAccountGroupById(int id) => _dao.GetById(id);
        public void DeleteAccountGroup(int id) => _dao.Delete(id);
    }
}
