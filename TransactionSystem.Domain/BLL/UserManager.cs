using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.DAL;
using $safeprojectname$.DTO;
using $safeprojectname$.IBLL;
using $safeprojectname$.IDAL;
using $safeprojectname$.Model;

namespace $safeprojectname$.BLL
{
    public class UserManager : IUserManager
    {
        public UserDTO GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> list;
            using (IUserService userSvc = new UserService())
            {
                list = userSvc.GetAll().Where(m => !m.IsRemove).Select(m => new UserDTO()
                {
                    UserId = m.Id,
                    Email = m.Email,
                    Password = m.Password,
                    UserName = m.UserName,
                    TelphoneNumber = m.TelphoneNumber,
                    Address = m.Address,
                    RealName = m.RealName,
                    CompanyName = m.CompanyName,
                    UserType = m.UesrType,
                    CreateTime = m.CreteTime
                }).ToList();
            }
            return list;
        }

        public UserDTO Login(string email, string password)
        {
            using (IUserService userSvc = new UserService())
            {
                return UserToUserDTO(userSvc.GetAll().First(m => m.Email == email && m.Password == password));



                //bool
                //var user = userSvc.GetAll().First(m => m.Email == email && m.Password == password);
                //if (user != null)
                //{
                //    return true;
                //}
                //return false;
            }
        }

        public void Register(string email, string password)
        {
            using (IUserService userSvc = new UserService())
            {
                userSvc.Create(new User()
                {
                    Email = email,
                    Password = password,
                    UserName = "DefaultName",
                    ImagePath = "default.png",
                    UesrType = 100001
                });
            }
        }

        public void Register(UserDTO userDTO)
        {
            using (IUserService userSvc = new UserService())
            {
                userSvc.Create(new User()
                {
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                    UserName = userDTO.UserName,
                    ImagePath = "default.png",
                    TelphoneNumber = userDTO.TelphoneNumber,
                    Address = userDTO.Address,
                    RealName = userDTO.RealName,
                    CompanyName = userDTO.CompanyName,
                    UesrType = 100001
                });
            }
        }

        public void EditUser(UserDTO user)
        {
            using (IUserService userSvc = new UserService())
            {
                userSvc.Edit(UserDTOToUser(user));
            }
        }
        public UserDTO UserToUserDTO(User user)
        {
            return new UserDTO()
            {
                UserId = user.Id,
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName,
                ImagePath = "default.png",
                TelphoneNumber = user.TelphoneNumber,
                Address = user.Address,
                RealName = user.RealName,
                CompanyName = user.CompanyName,
                UserType = 100001,
                CreateTime = user.CreteTime
            };
        }
        public User UserDTOToUser(UserDTO userDTO)
        {
            User user = new User()
            {
                Id = userDTO.UserId,
                Email = userDTO.Email,
                Password = userDTO.Password,
                UserName = userDTO.UserName,
                ImagePath = "default.png",
                TelphoneNumber = userDTO.TelphoneNumber,
                Address = userDTO.Address,
                RealName = userDTO.RealName,
                CompanyName = userDTO.CompanyName,
                UesrType = userDTO.UserType,
            };
            return user;
        }

        public UserDTO GetUser(Guid userID)
        {
            using (IUserService userSvc = new UserService())
            {
                return UserToUserDTO(userSvc.GetOneById(userID));
            }
        }
    }
}
