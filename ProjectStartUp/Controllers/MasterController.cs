using BLL;
using BLL.ProjectBLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStartUp.Controllers
{
    public class MasterController : Controller
    {

        private readonly AccountSubGroupBLL _accountSubGroupBLL;
        private readonly AccountGroupBLL _accountGroupBLL;

        // BLL injected via constructor
        public MasterController(AccountSubGroupBLL accountSubGroupBLL, AccountGroupBLL accountGroupBLL)
        {
            _accountSubGroupBLL = accountSubGroupBLL;
            _accountGroupBLL = accountGroupBLL;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Acocunt Group
        public IActionResult AccountGroupList()
        {
            try
            {
                var list = _accountGroupBLL.GetAllAccountGroup();
                return View(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the list.";
                return View(new List<AccountGroupDTO>());
            }
        }
        public IActionResult AddAccountGroup(int id = 0)
        {
            AccountGroupDTO model;
            try
            {
                if (id != 0)
                {
                    model = _accountGroupBLL.GetAccountGroupById(id) ?? new AccountGroupDTO();
                }
                else
                {
                    model = new AccountGroupDTO();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the details.";
                return RedirectToAction("AccountGroupList");
            }
        }
        [HttpPost]
        public IActionResult AddAccountGroup(AccountGroupDTO model)
        {
            try
            {
                if (model.Ac_GrpCode != 0)
                {
                    // If you implement Update in BLL/DAO
                    // _accountSubGroupBLL.Update(model);
                }
                else
                {
                    _accountGroupBLL.AddAccountGroup(model);
                }

                ModelState.Clear();
                return RedirectToAction("AccountGroupList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while saving the data.";
                return View(model);
            }
        }
        #endregion

        #region AccountSubGroup
        public IActionResult AccountSubGroupList()
        {
            try
            {
                var list = _accountSubGroupBLL.GetAllAccountSbuGroup();
                return View(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the list.";
                return View(new List<AccountSubGroupDTO>());
            }
        }

        public IActionResult AccountSubGroup(int id = 0)
        {
            AccountSubGroupDTO model;
            try
            {
                if (id != 0)
                {
                    model = _accountSubGroupBLL.GetAccountSubGroupById(id) ?? new AccountSubGroupDTO();
                }
                else
                {
                    model = new AccountSubGroupDTO();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the details.";
                return RedirectToAction("AccountSubGroupList");
            }
        }

        [HttpPost]
        public IActionResult AccountSubGroup(AccountSubGroupDTO model)
        {
            try
            {
                if (model.SGrpCode != 0)
                {
                    // If you implement Update in BLL/DAO
                    // _accountSubGroupBLL.Update(model);
                }
                else
                {
                    _accountSubGroupBLL.AddAccountSubGroup(model);
                }

                ModelState.Clear();
                return RedirectToAction("AccountSubGroupList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while saving the data.";
                return View(model);
            }
        }
  

   
#endregion
#region Agent
public IActionResult AgentList()
{
    return View();
}
#endregion
#region Area
public IActionResult AreaList()
{
    return View();
}
#endregion
#region Ledger
public IActionResult LedgerList()
{
    return View();
}
#endregion
}
}
