using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStartUp.Controllers
{
    public class MasterController : Controller
    {

        private readonly AccountSubGroupBLL _accountSubGroupBLL;

        // BLL injected via constructor
        public MasterController(AccountSubGroupBLL accountSubGroupBLL)
        {
            _accountSubGroupBLL = accountSubGroupBLL;
        }

        public IActionResult Index()
        {
            return View();
        }

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

        //public IActionResult AccountSubGroup(int id = 0)
        //{
        //    AccountSubGroupDTO model;
        //    try
        //    {
        //        if (id != 0)
        //        {
        //            // If you implement GetById in BLL/DAO, uncomment:
        //            // model = _accountSubGroupBLL.GetById(id) ?? new AccountSubGroupDTO();
        //        }
        //        else
        //        {
        //            model = new AccountSubGroupDTO();
        //        }

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        TempData["ErrorMessage"] = "An error occurred while fetching the details.";
        //        return RedirectToAction("AccountSubGroupList");
        //    }
        //}

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
