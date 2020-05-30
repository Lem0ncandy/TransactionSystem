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
    /// 报价信息
    /// </summary>
    public class Comment :BaseEntity
    {
        /// <summary>
        /// 需求信息外键
        /// </summary>
        [ForeignKey(nameof(Demand))]
        public Guid DemandId { get; set; }
        public Demand Demand { get; set; }

        /// <summary>
        /// 用户外键
        /// </summary>
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }


        /// <summary>
        /// 最小报价
        /// </summary>
        public float MinPrice { get; set; }
        /// <summary>
        /// 最大报价
        /// </summary>
        public float MaxPrice { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required, StringLength(80), Column(TypeName = "varchar")]
        public string Title { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        [Required, StringLength(800), Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
