using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace $safeprojectname$.Models.DemandViewModel
{
    public class RelaseDemandViewModel
    {
        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        [Required]
        [Display(Name = "简介")]
        public string Introduction { get; set; }
    }
}