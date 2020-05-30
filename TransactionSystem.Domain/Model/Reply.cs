using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Model
{
    public class Reply : BaseEntity
    {
        /// <summary>
        /// 报价信息外键
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
        /// 文章
        /// </summary>
        [Required, StringLength(800), Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
    
}
