﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.IDAL;
using $safeprojectname$.Model;

namespace $safeprojectname$.DAL
{
    public class DemandService : BaseService<Demand>, IDemandService
    {
        public DemandService() : base(new TransactionContext())
        {
        }
    }
}
