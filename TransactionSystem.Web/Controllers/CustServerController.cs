using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionSystem.Domain.BLL;
using TransactionSystem.Domain.DTO;
using TransactionSystem.Domain.IBLL;

namespace $safeprojectname$.Controllers
{
    public class CustServerController : Controller
    {
        // GET: CustServer
        public ActionResult Index()
        {
            IDemandManager demandManager = new DemandManager();

            return View(demandManager.GetAllDemand());
        }
        public ActionResult ConfirmDemand(string id)
        {
            //string id = Request.QueryString["OrderId"].ToString();
            Guid demandId = Guid.Parse(id);
            IDemandManager demandManager = new DemandManager();
            demandManager.Confirm(demandId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(FeedBackDTO feedBack)
        {
            Guid userId = Guid.Parse(Session["UserId"].ToString());
            feedBack.UserId = userId;
            IFeedBackManager feedBackManager = new FeedBackManager();
            feedBackManager.Relase(feedBack);
            return View();
        }
        public ActionResult FeedbackList()
        {
            List<FeedBackDTO> list;
            IFeedBackManager feedBackManager = new FeedBackManager();
            list = feedBackManager.GetAllFeedBack();
            return View(list);
        }
        [HttpPost]
        public ActionResult FeedbackDetail(Guid? id)
        {
            IFeedBackManager feedBackManager = new FeedBackManager();
            ViewBag.FeedBack = feedBackManager.GetFeedBack(id.Value);
            return View();
        }
    }
}