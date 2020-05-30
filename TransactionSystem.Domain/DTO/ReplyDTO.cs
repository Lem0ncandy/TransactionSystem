using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.DTO
{
    public class ReplyDTO
    {
        /// <summary>
        /// 回复Id
        /// </summary>
        public Guid ReplyId { get; set; }
        /// <summary>
        /// 报价Id
        /// </summary>
        public Guid CommentId { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 空的
        /// </summary>
        public bool IsNull { get; set; } = false;
    }
}
