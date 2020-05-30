using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionSystem.Domain.BLL;
using TransactionSystem.Domain.IBLL;
using TransactionSystem.Web.Models.UserViewModel;

namespace $safeprojectname$
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //UserManager um = new UserManager();
            //um.Register("123@123.com", "123");
            //Assert.AreEqual(um.Login("12312452@lak.com", "1231231qwfewf"), true);
            //um.Login("12312452@lak.com", "1231231qwfewf");
        }
        [TestMethod]
        public void TestMethod2()
        {
            DemandManager dm = new DemandManager();
            dm.Release(new Domain.DTO.DemandDTO()
            {
                Content = "这是2句话，这是3句话，这是4句话，这是5句话，这是6句话，这是6句话，",
                Title = "这是一句标题",
                Introduction = "123123",
                UserId = Guid.Parse("d575d2d9-3a22-4465-9fe3-259ab0391988")
            });
            //foreach (var item in dm.GetAllDemand())
            //{
            //    Assert.AreEqual(Guid.Parse("1e38e6a5-1684-4b2c-95de-196b8bf7690"), item.UserId);
            //}
        }
        [TestMethod]
        public void TestMethod3()
        {
            CommentManager cm = new CommentManager();
            //cm.Relase(new Domain.DTO.CommentDTO()
            //{
            //    Content = "游戏内容的同时开发新的领域。这样玩家们就能在享受和支持游戏和制作者的同时让其能获得长足的发展",
            //    DemandId = Guid.Parse("34c35b45-09d1-4be3-8d96-27618b32a00c"),
            //    MaxPrice = 50.0f,
            //    MinPrice = 20.0f,
            //    Title = "佛了",
            //    UserId = Guid.Parse("d575d2d9-3a22-4465-9fe3-259ab0391988")
            //});
            Assert.IsNotNull(cm.GetAllComment(Guid.Parse("d2326cb9-12c5-4236-a496-6f320fcbf1ea")).Count > 0);
            //if(cm.GetAllComment(Guid.Parse()).Count > 0);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Guid userId = Guid.Parse(/*Session["UserId"].ToString()*/"d575d2d9-3a22-4465-9fe3-259ab0391988");
            MyaccountViewModel model = new MyaccountViewModel();
            IOrderManager orderManager = new OrderManager();
            ICommentManager commentManager = new CommentManager();
            IDemandManager demandManager = new DemandManager();
            model.orders = orderManager.GetAllOrderByUserId(userId);
            model.demands = demandManager.GetAllDemandByUserId(userId);
            model.comments = commentManager.GetAllCommentByUserId(userId);
            Assert.IsNotNull(model.comments);
            Assert.IsNotNull(model.orders);
            Assert.IsNotNull(model.demands);
        }
        [TestMethod]
        public void TestMethod5()
        {
            IReplyManager replyManager = new ReplyManager();
            replyManager.Relase(new Domain.DTO.ReplyDTO()
            {
                CommentId = Guid.Parse("d2326cb9-12c5-4236-a496-6f320fcbf1ea"),
                UserId = Guid.Parse("d575d2d9-3a22-4465-9fe3-259ab0391988"),
                Content = "231552",
            });
        }
        [TestMethod]
        public void TestMethod6()
        {
            IFeedBackManager feedBackManager = new FeedBackManager();
            feedBackManager.Relase(new Domain.DTO.FeedBackDTO()
            {
                Content = "(@^0^@)",
                Title = "(T_T)",
                UserId = Guid.Parse("d575d2d9-3a22-4465-9fe3-259ab0391988")
            });
        }
    }
}
