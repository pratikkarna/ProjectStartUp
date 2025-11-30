using BLL;
using BLL.ProjectBLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStartUp.Controllers
{
    public class MasterController : Controller
    {

        private readonly AccountSubGroupBLL _accountSubGroupBLL;
        private readonly AreaBLL _areaBll;

        // BLL injected via constructor
        public MasterController(AccountSubGroupBLL accountSubGroupBLL,AreaBLL areaBLL )
        {
            _accountSubGroupBLL = accountSubGroupBLL;
            _areaBll= areaBLL;
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
                var tests = _areaBll.GetAllArea();
                return View(tests);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the test list.";
                return View(new List<TestDTO>());
            }
        }

        //public ActionResult Test(int id = 0)
        //{
        //    try
        //    {
        //        TestDTO model;
        //        if (id != 0)
        //        {
        //            model = _testBLL.GetTestById(id) ?? new TestDTO();
        //        }
        //        else
        //        {
        //            model = new TestDTO();
        //        }
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        TempData["ErrorMessage"] = "An error occurred while fetching the test details.";
        //        return RedirectToAction("TestList");
        //    }
        //}

        [HttpPost]
        //public ActionResult Test(TestDTO model)
        //{
        //    try
        //    {
        //        if (model.ID != 0)
        //        {
        //            _testBLL.UpdateTest(model);
        //        }
        //        else
        //        {
        //            _testBLL.AddTest(model);
        //            ModelState.Clear();
        //            return RedirectToAction("Test", new { id = 0 });
        //        }
        //        return RedirectToAction("TestList");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        TempData["ErrorMessage"] = "An error occurred while saving the test.";
        //        return View(model);
        //    }
        //}

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
