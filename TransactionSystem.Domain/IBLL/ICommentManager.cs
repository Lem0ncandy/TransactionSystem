using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DTO;
using $safeprojectname$.Model;

namespace $safeprojectname$.IBLL
{
    public interface ICommentManager
    {
        void Relase(CommentDTO comment);
        void Edit(CommentDTO comment);
        void Delete(CommentDTO comment);
        List<CommentDTO> GetAllComment(Guid demandId);
        CommentDTO GetComment(Guid commentId);
        List<CommentDTO> GetAllCommentByUserId(Guid userId);
    }
}
