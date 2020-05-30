using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.IDAL;
using $safeprojectname$.Model;

namespace $safeprojectname$.DAL
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService() : base(new TransactionContext())
        {
        }
    }
}
