using Microsoft.AspNetCore.Mvc;

namespace ProjectStartUp.Controllers
{
    public class MasterController : Controller
    {
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
        public IActionResult AccountSubGroupList()
        {
            return View();
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
