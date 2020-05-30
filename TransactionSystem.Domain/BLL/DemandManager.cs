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
    public class DemandManager : IDemandManager
    {
        public void ChangeHidden(DemandDTO demand)
        {
            throw new NotImplementedException();
        }

        public void ChangeHidden(Guid demandId)
        {
            throw new NotImplementedException();
        }

        public void Edit(DemandDTO demand)
        {
            throw new NotImplementedException();
        }

        public void Release(DemandDTO Demand)
        {
            using (IDemandService dmSvc = new DemandService())
            {
                dmSvc.Create(DemandDTOToDemand(Demand));
            }
        }
        public DemandDTO DemandToDemandDTO(Demand Demand)
        {
            return new DemandDTO()
            {
                Id = Demand.Id,
                Content = Demand.Content,
                IsHidden = Demand.IsHidden,
                Introduction = Demand.Introduction,
                Title = Demand.Title,
                UserId = Demand.UserId,
                CreateTime = Demand.CreteTime
                
            };
        }
        public Demand DemandDTOToDemand(DemandDTO Demand)
        {
            return new Demand()
            {
                Content = Demand.Content,
                IsHidden = Demand.IsHidden,
                Introduction = Demand.Introduction,
                Title = Demand.Title,
                UserId = Demand.UserId
            };
        }

        public List<DemandDTO> GetAllDemand()
        {
            List<DemandDTO> list;
            using (IDemandService dmSvc = new DemandService())
            {
                list = dmSvc.GetAll().Select(m => new DemandDTO()
                {
                    Id = m.Id,
                    Content = m.Content,
                    IsHidden = m.IsHidden,
                    Introduction = m.Introduction,
                    Title = m.Title,
                    UserId = m.UserId,
                    CreateTime = m.CreteTime
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

        public DemandDTO GetDemand(Guid id)
        {
            DemandDTO demand;
            using (IDemandService dmSvc = new DemandService())
            {
                demand = DemandToDemandDTO(dmSvc.GetAll().Where(m => m.IsHidden == false).Where(m => m.Id == id).First());
                using (IUserService userSvc = new UserService())
                {
                    demand.CompanyName = userSvc.GetOneById(demand.UserId).CompanyName;
                }
            }
            return demand;
        }

        public List<DemandDTO> GetAllDemandByUserId(Guid userId)
        {
            List<DemandDTO> list;
            using (IDemandService dmSvc = new DemandService())
            {
                list = dmSvc.GetAll().Where(m => m.UserId == userId).Select(m => new DemandDTO()
                {
                    Id = m.Id,
                    Content = m.Content,
                    IsHidden = m.IsHidden,
                    Introduction = m.Introduction,
                    Title = m.Title,
                    UserId = m.UserId,
                    CreateTime = m.CreteTime
                }).ToList();
            }
            return list;
        }

        public void Confirm(Guid id)
        {
            using (IDemandService dmSvc = new DemandService())
            {
                Demand demand = dmSvc.GetOneById(id);
                demand.IsHidden = false;
                dmSvc.Edit(demand);
            }
        }
    }
}
