using _1.Glitter_Presentation.Models;
using _2.Glitter_BL;
using AutoMapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _1.Glitter_Presentation.Controllers
{
    public class UserController : ApiController
    {
      
        private UserServices userServices = new UserServices();
        
        [HttpPost]
        [Route("api/user/register")]
        public IHttpActionResult Register(UserRegisterModel user)
        {
            
                
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegisterModel,UserDTO>());
            var mapper = config.CreateMapper();
            UserDTO userDTO = mapper.Map<UserDTO>(user);

            try
            {
                UserDTO temp = userServices.Register(userDTO);
            }
            catch
            {
                return NotFound();
            }
            return Ok();
 
        }
        [HttpPost]
        [Route("api/user/login")]
        public IHttpActionResult Login(UserLoginModel user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserLoginModel, UserDTO>());
            var mapper = config.CreateMapper();
            UserDTO userDTO = mapper.Map<UserDTO>(user);
            try
            {
                UserDTO temp = userServices.Login(userDTO);
                //var config = new MapperConfiguration(cfg=>cfg.CreateMap<UserDTO,User>)
                return Ok(temp);
            }
            catch
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        [Route("api/user/follow")]
        public IHttpActionResult Follow(FollowModel followModel)
        {
            FollowDTO followDTO = new FollowDTO();

            followDTO.UserID = followModel.UserID;
            followDTO.FollowingIDs = followModel.FollowingIDs;

            userServices.Follow(followDTO);

            return Ok();
        }
        [HttpPost]
        [Route("api/user/unfollow")]
        public IHttpActionResult UnFollow(FollowModel followModel)
        {
            FollowDTO followDTO = new FollowDTO();

            followDTO.UserID = followModel.UserID;
            followDTO.FollowingIDs = followModel.FollowingIDs;

            userServices.Unfollow(followDTO);

            return Ok();
        }

        [HttpGet]
        [Route("api/user/allFollowers/{id}")]
        public IHttpActionResult Followers(int id)
        {
            
            List<UserDTO> userDTOs = userServices.Followers(id);

            List<ListUserModel> listUserModels = new List<ListUserModel>();

            foreach (UserDTO userDTO in userDTOs)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, ListUserModel>());
                var mapper = config.CreateMapper();
                ListUserModel listUserModel = mapper.Map<ListUserModel>(userDTO);

                listUserModels.Add(listUserModel);
            }
            return Ok(listUserModels);
        }


        [HttpGet]
        [Route("api/user/allFollowing/{id}")]
        public IHttpActionResult Following(int id)
        {
            
            List<UserDTO> userDTOs = userServices.Following(id);

            List<ListUserModel> listUserModels = new List<ListUserModel>();
            foreach (UserDTO userDTO in userDTOs)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, ListUserModel>());
                var mapper = config.CreateMapper();
                ListUserModel listUserModel = mapper.Map<ListUserModel>(userDTO);

                listUserModels.Add(listUserModel);
            }

            return Ok(listUserModels);
        }

        [HttpGet]
        [Route("api/user/followerCount/{id}")]
        public int FollowerCount(int id)
        {
            try
            {
                List<UserDTO> userDTOs = userServices.Followers(id);
                return userDTOs.Count();
            }
            catch
            {
                return 0;
            }
        }


        [HttpGet]
        [Route("api/user/followingCount/{id}")]
        public int FollowingCount(int id)
        {
            try
            {
                List<UserDTO> userDTOs = userServices.Following(id);
                return userDTOs.Count();
            }
            catch
            {
                return 0;
            }
        }


        



    }
}
