using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace $safeprojectname$.Models.CommentViewModel
{
    public class RelaseCommentViewModel
    {

        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
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
    }
}