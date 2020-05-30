using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.IDAL;
using $safeprojectname$.Model;

namespace $safeprojectname$.DAL
{
    class FeedBackService : BaseService<FeedBack>, IFeedBackService
    {
        public FeedBackService() : base(new TransactionContext())
        {
        }
    }
}
