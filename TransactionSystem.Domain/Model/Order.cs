using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace $safeprojectname$.Model
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public class Order :BaseEntity
    {
        /// <summary>
        ///需求外键
        /// </summary>
        [ForeignKey(nameof(Demand))]
        public Guid DemandId { get; set; }
        public Demand Demand { get; set; }
        /// <summary>
        /// 报价外键
        /// </summary>
        [ForeignKey(nameof(Comment))]
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [Required]
        public int OrderState { get; set; }
    }
}
