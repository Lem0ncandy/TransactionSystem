using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DTO;

namespace $safeprojectname$.IBLL
{
    public interface IDemandManager
    {
        void Release(DemandDTO demand);
        void Edit(DemandDTO demand);
        void ChangeHidden(DemandDTO demand);
        void ChangeHidden(Guid demandId);
        DemandDTO GetDemand(Guid demandId);
        List<DemandDTO> GetAllDemand();
        List<DemandDTO> GetAllDemandByUserId(Guid userId);
        void Confirm(Guid id);
    }
}
