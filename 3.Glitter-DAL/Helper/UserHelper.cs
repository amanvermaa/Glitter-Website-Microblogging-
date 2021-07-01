using _3.Glitter_DAL.Entity;
using AutoMapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL.Helper
{
    public class UserHelper
    {
        public UserDTO User2UserDTO(User user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User,UserDTO>());
            var mapper = config.CreateMapper();
            UserDTO userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
        }
        public User UserDTO2User(UserDTO userDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = config.CreateMapper();
            User user = mapper.Map<User>(userDTO);

            return user;
        }
        public List<UserDTO> UserList2UserDTOList(List<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach(User user in users)
            {
                UserDTO userDTO = User2UserDTO(user);
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }
       
        public List<User> UserDTOList2UserList(List<UserDTO> userDTOs)
        {
            List<User> users = new List<User>();
            foreach(UserDTO userDTO in userDTOs)
            {
                User user = UserDTO2User(userDTO);
                users.Add(user);
            }
            return users;
        }
    }
}
