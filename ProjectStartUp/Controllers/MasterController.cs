using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ProjectStartUp.Controllers
{
    public class MasterController : Controller
    {

        private readonly AccountSubGroupBLL _accountSubGroupBLL;

        public MasterController()
        {
            _accountSubGroupBLL = new AccountSubGroupBLL();
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Account Group
        public IActionResult AccountGroupList()
        {
            return View();
        }
        #endregion
        #region AccountSubGroup
        //public ActionResult AccountSubGroupList()
        //{
        //    try
        //    {
        //        var tests = _accountSubGroupBLL.GetAll_AccountSbuGroup();
        //        return View(tests);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        TempData["ErrorMessage"] = "An error occurred while fetching the test list.";
        //        return View(new List<TestDTO>());
        //    }
        //}

        //public ActionResult Test(int id = 0)
        //{
        //    try
        //    {
        //        TestDTO model;
        //        if (id != 0)
        //        {
        //            model = _testBLL.GetTestById(id);
        //            if (model == null)
        //                model = new TestDTO();
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
        //        return RedirectToAction("TestList", "Test");
        //    }
        //}

        //[HttpPost]
        //public ActionResult Test(TestDTO model)
        //{
        //    try
        //    {
        //        if (model.ID != 0)
        //        {
        //            _testBLL.UpdateTest(model);
        //            return RedirectToAction("TestList", "Test");
        //        }
        //        else
        //        {
        //            _testBLL.AddTest(model);
        //            ModelState.Clear();
        //            return RedirectToAction("Test", "Test", new { id = 0 });
        //        }
        //        return View(model);
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
        //    return RedirectToAction("TestList", "Test");
        //}
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
