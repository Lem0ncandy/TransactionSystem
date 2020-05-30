using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DTO;

namespace $safeprojectname$.IBLL
{
    public interface IFeedBackManager
    {
        void Relase(FeedBackDTO feedback);
        void Edit(FeedBackDTO feedback);
        void Delete(FeedBackDTO feedback);
        List<FeedBackDTO> GetAllFeedBack();
        FeedBackDTO GetFeedBack(Guid feedBackId);
    }
}
