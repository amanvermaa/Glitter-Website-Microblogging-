using _1.Glitter_Presentation.Models;
using _2.Glitter_BL;
using AutoMapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1.Glitter_Presentation.Controllers
{
    public class PlaygroundController : ApiController
    {
        private PlaygroundServices playgroundServices = new PlaygroundServices();
        private UserServices userServices = new UserServices();
        private TweetServices tweetServices = new TweetServices();


        [HttpGet]
        [Route("api/playground/dashboard/{id}")]
        public IHttpActionResult Dashboard(int id)
        {
            DashboardModel dashboardModel = new DashboardModel();
            
            UserDTO userDTO = userServices.GetUserById(id);
            dashboardModel.Name = userDTO.Name;

            List<TweetDTO> tweetDTOs = tweetServices.GetAllTweetsForUser(id);


            List<DashboardModel> listTweet = new List<DashboardModel>();
            foreach (TweetDTO tweetDTO in tweetDTOs)
            {
                DashboardModel model = new DashboardModel();
                model.TweetID = tweetDTO.TweetID;
                model.UserID = tweetDTO.UserID;
                model.Name = userServices.GetUserById(tweetDTO.UserID).Name;
                model.Message = tweetDTO.Message;
                model.CreatedAt = tweetDTO.CreatedAt;
                //model.Image = userServices.GetUserById(tweetDTO.UserID).Image;
                model.TotalLikes = tweetServices.TotalLikes(tweetDTO.TweetID);
                model.TotalDislikes = tweetServices.TotalDislikes(tweetDTO.TweetID);

                listTweet.Add(model);
            }
            listTweet.OrderByDescending(data => data.CreatedAt);

            return Ok(listTweet);
        }

        [HttpGet]
        [Route("api/playground/searchUser/{text}")]
        public IHttpActionResult SearchUser(string text)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            List<SearchUser> list = new List<SearchUser>();
            try
            {
                userDTOs = playgroundServices.SearchUser(text);
            }
            catch
            {
                NotFound();
            }
            foreach(UserDTO userDTO in userDTOs)
            {
                SearchUser search = new SearchUser();
                search.UserID = userDTO.UserID;
                search.Name = userDTO.Name;
                search.Email = userDTO.Email;

                list.Add(search);               
            }
            return Ok(list);

        }

        [HttpPost]
        [Route("api/playground/searchHashtag")]
        public IHttpActionResult SearchHashtag(string text)
        {
            List<HashtagDTO> hashtagDTOs = playgroundServices.SearchHashtag(text);

            if (hashtagDTOs != null)
                return Ok();
            else
                return NotFound();
        }
    }
}
