using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DAL;
using $safeprojectname$.DTO;
using $safeprojectname$.IBLL;
using $safeprojectname$.IDAL;
using $safeprojectname$.Model;

namespace $safeprojectname$.BLL
{
    public class ReplyManager : IReplyManager
    {
        public void Delete(ReplyDTO reply)
        {
            throw new NotImplementedException();
        }

        public void Edit(ReplyDTO reply)
        {
            throw new NotImplementedException();
        }

        public List<ReplyDTO> GetAllReplyByDemandId(Guid DemandId)
        {
            throw new NotImplementedException();
        }

        public ReplyDTO GetReply(Guid commentId)
        {
            using (IReplyService replySvc = new ReplyService())
            {
                ReplyDTO replyDTO = new ReplyDTO();
                replyDTO.IsNull = true;
                Reply reply = replySvc.GetAll().Where(m => m.CommentId == commentId).FirstOrDefault();
                if (reply != null)
                {
                    replyDTO = ReplyToReplyDTO(reply);
                    using (IUserService userSvc = new UserService())
                    {
                        replyDTO.CompanyName = userSvc.GetOneById(replyDTO.UserId).CompanyName;
                    }
                    replyDTO.IsNull = false;
                }
                return replyDTO;
            }
        }

        public void Relase(ReplyDTO reply)
        {
            using (IReplyService replySvc = new ReplyService())
            {
                replySvc.Create(ReplyDTOToReply(reply));
            }
        }
        public Reply ReplyDTOToReply(ReplyDTO reply)
        {
            return new Reply()
            {
                Content = reply.Content,
                CommentId = reply.CommentId,
                UserId = reply.UserId
            };
        }
        public ReplyDTO ReplyToReplyDTO(Reply reply)
        {
            return new ReplyDTO()
            {
                Content = reply.Content,
                CommentId = reply.CommentId,
                UserId = reply.UserId,
                ReplyId = reply.Id,
                CreateTime= reply.CreteTime

            };
        }
    }
}
