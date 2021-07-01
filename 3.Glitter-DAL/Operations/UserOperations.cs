using _3.Glitter_DAL.Entity;
using _3.Glitter_DAL.Helper;
using AutoMapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL.Operations
{
    public class UserOperations
    {
        private GlitterDbContext db = new GlitterDbContext();
        private UserHelper helper = new UserHelper();
        private FollowHelper followHelper = new FollowHelper();
        public void Register(UserDTO userDTO)
        {
            User user =  helper.UserDTO2User(userDTO);

            db.Users.Add(user);
            db.SaveChanges();
        }
        public UserDTO Login(UserDTO userDTO)
        {

            User user = helper.UserDTO2User(userDTO);
            User temp = db.Users.Single(data => data.Email == user.Email && data.Password == user.Password);
            if (temp == null)
                return null;
            else
                return helper.User2UserDTO(temp);
        }
        public bool IsPresent(string email)
        {
            return db.Users.Any(user => user.Email == email);
        }
        public UserDTO GetUserById(int id)
        {
            User user = db.Users.Single(data => data.UserID == id);
            return helper.User2UserDTO(user);
        }
        public void Follow(FollowDTO followDTO)
        {
            Follow follow = followHelper.FollowDTO2Follow(followDTO);

            try
            { 

                var temp = db.Follows.Single(data => data.UserID == follow.UserID && data.FollowID == follow.FollowID);
                db.Follows.Add(follow);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Already Followed");
            }

        }
        public void Unfollow(FollowDTO followDTO)
        {
            Follow follow = followHelper.FollowDTO2Follow(followDTO);

            Follow temp = db.Follows.Single(data => data.UserID == follow.UserID && data.FollowingIDs == follow.FollowingIDs);

            if(temp!=null)
            {
                db.Follows.Remove(temp);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Already Unfollowed");
            }

        }
        public List<UserDTO> Followers(int id)
        {
            
            List<Follow> follows = db.Follows.Where(Data => Data.FollowingIDs == id).ToList();

            List<int> followerList = new List<int>();

            foreach (Follow foll in follows)
            {
                followerList.Add(foll.UserID);
            }
            List<UserDTO> userDTOs = new List<UserDTO>();
            User user = new User();
            foreach (int follower in followerList)
            {
               
                try
                {
                    user = db.Users.Single(data => data.UserID == follower);
                }
                catch
                {
                    continue;
                }
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
                var mapper = config.CreateMapper();
                UserDTO userDTO = mapper.Map<UserDTO>(user);
                userDTOs.Add(userDTO);
            }
            return userDTOs;

        }

        public List<UserDTO> Following(int id)
        {
            
            List<Follow> follows = db.Follows.Where(data => data.UserID == id).ToList();
            List<int> followingList = new List<int>();
            foreach (Follow foll in follows)
            {
                followingList.Add(foll.FollowingIDs);
            }

            List<UserDTO> userDTOs = new List<UserDTO>();
            User user = new User();


            foreach (int following in followingList)
            {
                try
                {
                    user = db.Users.Where(data => data.UserID == following).FirstOrDefault();
                }
                catch
                {
                    continue;
                }
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
                var mapper = config.CreateMapper();
                UserDTO userDTO = mapper.Map<UserDTO>(user);

                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }

        public List<UserDTO> SearchUser(string text)
        {
            List<User> users  = db.Users.Where(x => x.Name.StartsWith(text) || text == null).ToList();
            return helper.UserList2UserDTOList(users);
        }

    }
        
}
