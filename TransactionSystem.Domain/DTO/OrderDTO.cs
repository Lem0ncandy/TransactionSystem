using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.DTO
{
    public class OrderDTO
    {
        /// <summary>
        /// 需求外键
        /// </summary>
        public Guid DemandId { get; set; }

        /// <summary>
        /// 报价外键
        /// </summary>

        public Guid CommentId { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>

        public Guid UserId { get; set; }


        /// <summary>
        /// 订单状态
        /// </summary>

        public int OrderState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
