
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using TransactionSystem.Domain.BLL;
using TransactionSystem.Domain.DTO;
using TransactionSystem.Domain.IBLL;
using $safeprojectname$.Models.DemandViewModel;

namespace $safeprojectname$.Controllers
{
    public class DeamdController : Controller
    {
        // GET: Deamd
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DemandDetail(Guid? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            IDemandManager demandManager = new DemandManager();
            DemandDTO demand = demandManager.GetDemand(id.Value);
            ICommentManager commentManager = new CommentManager();
            List<CommentDTO> comments = commentManager.GetAllComment(id.Value);
            List<ReplyDTO> replys = new List<ReplyDTO>();
            foreach (var item in comments)
            {
                IReplyManager replyManager1 = new ReplyManager();
                replys.Add(replyManager1.GetReply(item.CommentId));
            }
            ViewBag.comment = comments;
            ViewBag.reply = replys;
            IReplyManager replyManager = new ReplyManager();

            return View(demand);
        }
        [HttpPost]
        public ActionResult RelaseComment(string comment_title,string comment_MinPrice,string comment_MaxPrice, string comment_content, string comment_UserId,string comment_DemandId)
        {
            ICommentManager commentManager = new CommentManager();
            commentManager.Relase(new CommentDTO()
            {
                Content = comment_content,
                MaxPrice = Convert.ToSingle(comment_MaxPrice),
                MinPrice = Convert.ToSingle(comment_MinPrice),
                Title = comment_title,
                UserId = Guid.Parse(Session["UserId"].ToString()),
                DemandId = Guid.Parse(comment_DemandId)
            });
            IReplyManager replyManager = new ReplyManager();



            return RedirectToAction("SucessResult","Home");
        }
        [HttpGet]
        public ActionResult RelaseDemand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RelaseDemand(RelaseDemandViewModel model)
        {
            Guid userId = Guid.Parse(Session["UserId"].ToString());
            DemandDTO demand = new DemandDTO() { Content = model.Content, Introduction = model.Introduction, Title = model.Title, UserId = userId ,IsHidden = true};
            IDemandManager demandManger = new DemandManager();
            demandManger.Release(demand);
            return RedirectToAction("SucessResult","Home");
        }
        public ActionResult CreateOrder()
        {
            string id = Request.QueryString["CommentId"].ToString();
            Guid commentGuid = Guid.Parse(id);
            IOrderManager orderManager = new OrderManager();
            ICommentManager commentManager = new CommentManager();
            CommentDTO commentDTO = commentManager.GetComment(commentGuid);
            orderManager.Relase(new OrderDTO()
            {
                CommentId = commentDTO.CommentId,
                CreateTime = commentDTO.CreateTime,
                DemandId = commentDTO.DemandId,
                OrderState = 100000,
                UserId = commentDTO.UserId
            });
            return RedirectToAction("SucessResult", "Home");
        }
    }
}