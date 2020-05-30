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
    public class OrderManager : IOrderManager
    {
        public void Edit(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> GetAllOrder()
        {
            List<OrderDTO> list;
            using (IOrderService orderSvc = new OrderService())
            {
                list = orderSvc.GetAll().Select(m => new OrderDTO()
                {
                    CommentId = m.CommentId,
                    DemandId = m.DemandId,
                    OrderState = m.OrderState,
                    UserId = m.UserId
                }).ToList();
            }
            return list;
        }

        public OrderDTO GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Relase(OrderDTO order)
        {
            using (IOrderService orderSvc = new OrderService())
            {
                orderSvc.Create(OrderDTOToOrder(order));
            }
        }

        public Order OrderDTOToOrder(OrderDTO order)
        {
            return new Order()
            {
                CommentId = order.CommentId,
                DemandId = order.DemandId,
                OrderState = order.OrderState,
                UserId = order.UserId
            };
        }
        public OrderDTO OrderToOrderDTO(OrderDTO order)
        {
            return new OrderDTO()
            {
                CommentId = order.CommentId,
                DemandId = order.DemandId,
                OrderState = order.OrderState,
                UserId = order.UserId,
                CreateTime = order.CreateTime
            };
        }

        public List<OrderDTO> GetAllOrderByUserId(Guid userId)
        {
            List<OrderDTO> list;
            using (IOrderService orderSvc = new OrderService())
            {
                list = orderSvc.GetAll().Where(m => m.UserId == userId).Select(m => new OrderDTO()
                {
                    CommentId = m.CommentId,
                    DemandId = m.DemandId,
                    OrderState = m.OrderState,
                    UserId = m.UserId,
                    CreateTime = m.CreteTime
                }).ToList();
            }
            return list;
        }
    }
}
