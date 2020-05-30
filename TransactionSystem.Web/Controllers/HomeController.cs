using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionSystem.Domain.BLL;
using TransactionSystem.Domain.DTO;
using TransactionSystem.Domain.IBLL;
using $safeprojectname$.Models.DemandViewModel;
using $safeprojectname$.Models.UserViewModel;


namespace $safeprojectname$.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IDemandManager demandManager = new DemandManager();
            return View(demandManager.GetAllDemand());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            IUserManager userManager = new UserManager();
            var userinfo = userManager.Login(model.Email, model.Password);
            if (userinfo != null)
            {
                Session["UserName"] = userinfo.UserName;
                Session["UserId"] = userinfo.UserId;
                Session["UserType"] = userinfo.UserType;
                return RedirectToAction("Index", "Home");
            }
            return Content("error");
        }
        [HttpGet]
        public ActionResult Registe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registe(RegisteViewModel model)
        {
            IUserManager userManager = new UserManager();
            //UserDTO userinfo = new UserDTO() { Email = model.Email, Password = model.Password, Address = model.Address, CompanyName = model.CompanyName, RealName = model.RealName, TelphoneNumber = model.TelphoneNumber, UserName = model.UserName };
            
            userManager.Register(model.ToDTO());
            return RedirectToAction("SucessResult");
        }
        public ActionResult SucessResult()
        {
            return View();
        }

        public ActionResult Myaccount()
        {
            Guid userId = Guid.Parse(Session["UserId"].ToString());
            MyaccountViewModel model = new MyaccountViewModel();
            IOrderManager orderManager = new OrderManager();
            ICommentManager commentManager = new CommentManager();
            IDemandManager demandManager = new DemandManager();
            model.orders = orderManager.GetAllOrderByUserId(userId);
            model.demands = demandManager.GetAllDemandByUserId(userId);
            model.comments = commentManager.GetAllCommentByUserId(userId);
            return View(model);
        }
    }
}