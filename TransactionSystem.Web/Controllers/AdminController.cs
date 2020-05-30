using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionSystem.Domain.BLL;
using TransactionSystem.Domain.DTO;
using TransactionSystem.Domain.IBLL;
using $safeprojectname$.Models.AdminViewModel;

namespace $safeprojectname$.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            UserListViewModel model = new UserListViewModel();
            IUserManager userManager = new UserManager();
            model.Users = userManager.GetAllUser();
            return View(model);
        }
        [HttpPost]
        public ActionResult EditUser(Guid? Id)
        {
            IUserManager userManager = new UserManager();
            return View(userManager.GetUser(Id.Value));
        }
        public ActionResult EditUserAction(UserDTO user)
        {
            IUserManager userManager = new UserManager();
            userManager.EditUser(user);
            return RedirectToAction("Index");
        }
    }
}