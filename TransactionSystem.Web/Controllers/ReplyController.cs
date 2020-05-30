using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionSystem.Domain.BLL;
using TransactionSystem.Domain.DTO;
using TransactionSystem.Domain.IBLL;
using $safeprojectname$.Models.ReplyViewModel;

namespace $safeprojectname$.Controllers
{
    public class ReplyController : Controller
    {
        // GET: Reply
        [HttpGet]
        public ActionResult RelaseReply()
        {
            string id = Request.QueryString["CommentId"].ToString();
            Guid commentId = Guid.Parse(id);
            RelaseReplyViewModel model = new RelaseReplyViewModel() { CommentId = commentId };
            return View(model);
        }
        [HttpPost]
        public ActionResult RelaseReply(RelaseReplyViewModel model)
        {
            IReplyManager replyManager = new ReplyManager();
            replyManager.Relase(new ReplyDTO()
            {
                CommentId = model.CommentId,
                Content = model.Content,
                UserId = Guid.Parse(Session["UserId"].ToString())
            });
            return View();
        }
    }
}