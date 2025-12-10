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
        private readonly AreaBLL _areaBll;

        // BLL injected via constructor
        public MasterController(AccountSubGroupBLL accountSubGroupBLL,AccountGroupBLL accountGroupBLL, AreaBLL areaBLL)
        {
            _accountSubGroupBLL = accountSubGroupBLL;
            _areaBll = areaBLL;
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
        
        #region Area
        public ActionResult AreaList()
        {
            try
            {
                var areas = _areaBll.GetAllArea();
                return View(areas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the test list.";
                return View(new List<TestDTO>());
            }
        }
        public IActionResult AddArea(int id = 0)
        {
            AreaDTO model;
            try
            {
                if (id != 0)
                {
                    model = _areaBll.getAreaById(id) ?? new AreaDTO();
                }
                else
                {
                    model = new AreaDTO();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the details.";
                return RedirectToAction("AreaList");
            }
        }
        [HttpPost]

        public IActionResult AddArea(AreaDTO model)
        {
            try
            {
                if (model.Area_Code != 0)
                {
                    // If you implement Update in BLL/DAO
                    // _accountSubGroupBLL.Update(model);
                }
                else
                {
                    _areaBll.AddArea(model);
                }

                ModelState.Clear();
                return RedirectToAction("AreaList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while saving the data.";
                return View(model);
            }
        }

        //public ActionResult DeleteTest(int id)
        //{
        //    try
        //    {
        //        _testBLL.DeleteTest(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        TempData["ErrorMessage"] = "An error occurred while deleting the test.";
        //    }
        //    return RedirectToAction("TestList");
        //}


        #endregion
        #region Ledger
        public IActionResult LedgerList()
{
    return View();
}
#endregion
}
}
