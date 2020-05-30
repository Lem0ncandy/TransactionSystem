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
    public class CommentManager : ICommentManager
    {
        public void Delete(CommentDTO comment)
        {
            throw new NotImplementedException();

        }

        public void Edit(CommentDTO comment)
        {
            throw new NotImplementedException();
        }

        public void Relase(CommentDTO comment)
        {
            using (ICommentService comeSvc = new CommentService())
            {
                comeSvc.Create(CommentDTOToComment(comment));
            }
        }
        public CommentDTO CommentToCommentDTO(Comment comment)
        {
            return new CommentDTO()
            {
                Content = comment.Content,
                DemandId = comment.DemandId,
                MaxPrice = comment.MaxPrice,
                MinPrice = comment.MinPrice,
                Title = comment.Title,
                UserId = comment.UserId,
                CreateTime = comment.CreteTime,
                CommentId = comment.Id
            };
        }

        public Comment CommentDTOToComment(CommentDTO comment)
        {
            return new Comment()
            {
                Content = comment.Content,
                DemandId = comment.DemandId,
                MaxPrice = comment.MaxPrice,
                MinPrice = comment.MinPrice,
                Title = comment.Title,
                UserId = comment.UserId,
            };
        }

        public List<CommentDTO> GetAllComment(Guid demandId)
        {
            List<CommentDTO> list;
            using (ICommentService comeSvc = new CommentService())
            {
                list = comeSvc.GetAll().Where(m => m.DemandId == demandId).Select(m => new CommentDTO()
                {
                    Content = m.Content,
                    DemandId = m.DemandId,
                    MaxPrice = m.MaxPrice,
                    MinPrice = m.MinPrice,
                    Title = m.Title,
                    UserId = m.UserId,
                    CreateTime = m.CreteTime,
                    CommentId = m.Id

                }).ToList();
            }
            using (IUserService userSvc = new UserService())
            {
                foreach (var item in list)
                {
                    item.CompanyName = userSvc.GetOneById(item.UserId).CompanyName;
                }
            }
            return list;
        }

        public CommentDTO GetComment(Guid CommentId)
        {
            CommentDTO commentDTO;
            using (ICommentService commentSvc = new CommentService())
            {
                commentDTO = CommentToCommentDTO(commentSvc.GetOneById(CommentId));
            }
            return commentDTO;
        }

        public List<CommentDTO> GetAllCommentByUserId(Guid userId)
        {
            List<CommentDTO> list;
            using (ICommentService comeSvc = new CommentService())
            {
                list = comeSvc.GetAll().Where(m => m.UserId == userId).Select(m => new CommentDTO()
                {
                    Content = m.Content,
                    DemandId = m.DemandId,
                    MaxPrice = m.MaxPrice,
                    MinPrice = m.MinPrice,
                    Title = m.Title,
                    UserId = m.UserId,
                    CreateTime = m.CreteTime,
                    CommentId = m.Id
                }).ToList();
            }
            return list;
        }
    }
}
