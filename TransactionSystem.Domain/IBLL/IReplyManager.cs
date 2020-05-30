using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DTO;

namespace $safeprojectname$.IBLL
{
    public interface IReplyManager
    {
        void Relase(ReplyDTO reply);
        void Edit(ReplyDTO reply);
        void Delete(ReplyDTO reply);
        ReplyDTO GetReply(Guid commentId);
        List<ReplyDTO> GetAllReplyByDemandId(Guid DemandId);
    }
}
