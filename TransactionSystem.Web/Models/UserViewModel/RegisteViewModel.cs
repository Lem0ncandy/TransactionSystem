using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TransactionSystem.Domain.DTO;

namespace $safeprojectname$.Models.UserViewModel
{
    public class RegisteViewModel
    {
        /// <summary>
        /// 登录邮箱
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Display(Name = "用户昵称")]
        public string UserName { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        [Display(Name = "电话号码")]
        public string TelphoneNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Address { get; set; }
        /// <summary>
        /// 真名
        /// </summary>
        [Display(Name = "真实名字")]
        public string RealName { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        [Display(Name = "公司名称")]
        public string CompanyName { get; set; }

        public UserDTO ToDTO()
        {
            UserDTO dto = new UserDTO();
            dto.Email =Email;
            dto.Password = Password;
            dto.Address = Address;
            dto.CompanyName = CompanyName;
            dto.RealName = RealName;
            dto.TelphoneNumber = TelphoneNumber;
            dto.UserName = UserName;
            return dto;
        }
    }
}