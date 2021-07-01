using _3.Glitter_DAL.Operations;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Glitter_BL
{
    public class UserServices
    {
        private  UserOperations userOperations = new UserOperations();
        public UserDTO Register(UserDTO userDTO)
        {
            if (!userOperations.IsPresent(userDTO.Email))
            {
                userOperations.Register(userDTO);
                return userDTO;
            }
            else
                return null;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            
            return userOperations.Login(userDTO);            
        }
        public UserDTO GetUserById(int id)
        {
            return userOperations.GetUserById(id);
        }
        public void Follow(FollowDTO followDTO)
        {
            userOperations.Follow(followDTO);
        }
        public void Unfollow(FollowDTO followDTO)
        {
            userOperations.Unfollow(followDTO);
        }
        public List<UserDTO> Followers(int id)
        {
            return userOperations.Followers(id);
        }
        public List<UserDTO> Following(int id)
        {
            return userOperations.Following(id);
        }

        
        
    }
}
