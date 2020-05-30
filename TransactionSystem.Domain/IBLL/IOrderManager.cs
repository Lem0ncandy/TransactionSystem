using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DTO;

namespace $safeprojectname$.IBLL
{
    public interface IOrderManager
    {
        void Relase(OrderDTO order);
        List<OrderDTO> GetAllOrder();
        OrderDTO GetOrder(Guid orderid);
        void Edit(OrderDTO order);
        List<OrderDTO> GetAllOrderByUserId(Guid userId);
    }
}
