using Microsoft.AspNetCore.Mvc;
using DTO;
using BLL;
using System;
using System.Collections.Generic;

namespace ProjectStartUp.Controllers
{
    public class TestController : Controller
    {
        private readonly TestBLL _testBLL;

        // Inject TestBLL via constructor
        public TestController(TestBLL testBLL)
        {
            _testBLL = testBLL;
        }

        #region Test

        public ActionResult TestList()
        {
            try
            {
                var tests = _testBLL.GetAllTests();
                return View(tests);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the test list.";
                return View(new List<TestDTO>());
            }
        }

        public ActionResult Test(int id = 0)
        {
            try
            {
                TestDTO model;
                if (id != 0)
                {
                    model = _testBLL.GetTestById(id) ?? new TestDTO();
                }
                else
                {
                    model = new TestDTO();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while fetching the test details.";
                return RedirectToAction("TestList");
            }
        }

        [HttpPost]
        public ActionResult Test(TestDTO model)
        {
            try
            {
                if (model.ID != 0)
                {
                    _testBLL.UpdateTest(model);
                }
                else
                {
                    _testBLL.AddTest(model);
                    ModelState.Clear();
                    return RedirectToAction("Test", new { id = 0 });
                }
                return RedirectToAction("TestList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while saving the test.";
                return View(model);
            }
        }

        public ActionResult DeleteTest(int id)
        {
            try
            {
                _testBLL.DeleteTest(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TempData["ErrorMessage"] = "An error occurred while deleting the test.";
            }
            return RedirectToAction("TestList");
        }

        #endregion
    }
}
