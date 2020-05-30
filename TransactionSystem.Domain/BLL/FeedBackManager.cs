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
    public class FeedBackManager : IFeedBackManager
    {
        public void Delete(FeedBackDTO feedback)
        {
            throw new NotImplementedException();
        }

        public void Edit(FeedBackDTO feedback)
        {
            throw new NotImplementedException();
        }

        public List<FeedBackDTO> GetAllFeedBack()
        {
            List<FeedBackDTO> list;
            using (IFeedBackService feedBackSvc = new FeedBackService())
            {
                list = feedBackSvc.GetAll().Select(m => new FeedBackDTO()
                {
                    Content = m.Content,
                    CreateTime = m.CreteTime,
                    FeedBackId = m.Id,
                    Title = m.Title,
                    UserId = m.UserId
                }).ToList();
            }
            foreach (var item in list)
            {
                using (IUserService userSvc = new UserService())
                {
                    item.CompanyName = userSvc.GetOneById(item.UserId).CompanyName;
                }
            }
            return list;
        }

        public void Relase(FeedBackDTO feedBack)
        {
            using (IFeedBackService feedBackService = new FeedBackService() )
            {
                feedBackService.Create(FeedBackDTOToFeedBack(feedBack));
            }
        }
        public FeedBackDTO FeedBackToFeedBackDTO(FeedBack feedBack)
        {
            return new FeedBackDTO()
            {
                Content = feedBack.Content,
                CreateTime = feedBack.CreteTime,
                FeedBackId = feedBack.Id,
                Title = feedBack.Title,
                UserId =feedBack.UserId
            };
        }

        public FeedBack FeedBackDTOToFeedBack(FeedBackDTO feedBack)
        {
            return new FeedBack()
            {
                Content = feedBack.Content,
                Title = feedBack.Title,
                UserId = feedBack.UserId
            };
        }

        public FeedBackDTO GetFeedBack(Guid feedBackId)
        {
            using (IFeedBackService feedBackSvc = new FeedBackService())
            {
                return FeedBackToFeedBackDTO(feedBackSvc.GetOneById(feedBackId));
            }
        }
    }
}
