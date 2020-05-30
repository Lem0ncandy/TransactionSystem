using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DTO;
using $safeprojectname$.Model;

namespace $safeprojectname$.IBLL
{
    public interface IUserManager
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        void Register(string email, string password);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        void Register(UserDTO userinfo);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserDTO Login(string email, string password);

        //void ChangeUserInformation()
        UserDTO GetUserByEmail(string email);
        UserDTO GetUser(Guid userID);
        UserDTO UserToUserDTO(User user);
        List<UserDTO> GetAllUser();
        void EditUser(UserDTO user);
    }
}
