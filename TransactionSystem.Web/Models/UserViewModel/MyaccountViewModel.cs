using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionSystem.Domain.DTO;

namespace $safeprojectname$.Models.UserViewModel
{
    public class MyaccountViewModel
    {
        public List<OrderDTO> orders;
        public List<CommentDTO> comments;
        public List<DemandDTO> demands;
    }
}