using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Model;

namespace $safeprojectname$.DTO
{
    public class CommentDTO
    {
        /// <summary>
        /// 报价Id
        /// </summary>
        public Guid CommentId { get; set; }
        /// <summary>
        /// 需求信息外键
        /// </summary>
        public Guid DemandId { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        public string CompanyName { get; set; }
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
        public string Title { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
