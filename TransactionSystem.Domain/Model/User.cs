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
    /// 用户信息
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// 登录邮箱
        /// </summary>
        [Required, StringLength(30), Column(TypeName = "varchar")]
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required, StringLength(20), Column(TypeName = "varchar")]
        public string Password { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(16), Column(TypeName = "varchar")]
        public string UserName { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        [StringLength(300), Column(TypeName = "varchar")]
        public string ImagePath { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        [Required]
        public int UesrType { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [StringLength(11), Column(TypeName = "varchar")]
        public string TelphoneNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Column(TypeName = "varchar")]
        public string Address { get; set; }
        /// <summary>
        /// 真名
        /// </summary>
        [StringLength(10), Column(TypeName = "varchar")]
        public string RealName { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        [StringLength(50), Column(TypeName = "varchar")]
        public string CompanyName { get; set; }


    }
}
