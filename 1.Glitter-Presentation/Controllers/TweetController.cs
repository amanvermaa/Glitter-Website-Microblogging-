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
    public class TweetController : ApiController
    {
        enum Like_Dislike
        {
            Like = 1,
            Dislike = -1
        }
        private TweetServices tweetServices = new TweetServices();
        


        [HttpPost]
        [Route("api/tweet/createTweet")]
        public IHttpActionResult CreateTweet(CreateTweetModel tweet)
        {
            TweetDTO tweetDTO = new TweetDTO();
            tweetDTO.Message = tweet.Message;
            tweetDTO.UserID = tweet.UserID; ;
            tweetDTO.CreatedAt = System.DateTime.Now;
            if(ModelState.IsValid)
            {
                tweetServices.CreateTweet(tweetDTO);
                return Ok();
            }
            else
                return NotFound();
        }
        [HttpDelete]
        [Route("api/tweet/deleteTweet/{id}")]
        public IHttpActionResult DeleteTweet(int id)
        {
            try
            {
                TweetDTO tweetDTO = tweetServices.GetTweetById(id);
            }
            catch
            {
                return NotFound();
            }
            tweetServices.Delete(id);
            return Ok();

        }
        [HttpPut]
        [Route("api/tweet/editTweet")]
        public IHttpActionResult EditTweet(CreateTweetModel tweet)
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateTweetModel, TweetDTO>());
            //var mapper = config.CreateMapper();
            //TweetDTO tweetDTO = mapper.Map<TweetDTO>(tweet);
            TweetDTO tweetDTO = new TweetDTO();
            tweetDTO.TweetID = tweet.TweetID;
            tweetDTO.UserID = tweet.UserID;
            tweetDTO.Message = tweet.Message;
            tweetDTO.CreatedAt = System.DateTime.Now;

            tweetServices.Edit(tweetDTO);
            return Ok();
        }

        [HttpPost]
        [Route("api/tweet/like")]  //Just Remove this model from here, and put id so that it can fetch the id of that tweet and user id from session
        public IHttpActionResult LikeTweet(ActionModel actionModel)
        {
            LikeDislikeDTO likeDislikeDTO = new LikeDislikeDTO();
            likeDislikeDTO.UserID = actionModel.UserID;
            likeDislikeDTO.TweetID = actionModel.TweetID;
            likeDislikeDTO.Action = (int)Like_Dislike.Like;

            tweetServices.Action(likeDislikeDTO);


            return Ok();
        }
        [HttpPost]
        [Route("api/tweet/disLike")]  //Just Remove this model from here, and put id so that it can fetch the id of that tweet and user id from session
        public IHttpActionResult DisLikeTweet(ActionModel actionModel)
        {
            LikeDislikeDTO likeDislikeDTO = new LikeDislikeDTO();
            likeDislikeDTO.UserID = actionModel.UserID; 
            likeDislikeDTO.TweetID = actionModel.TweetID;
            likeDislikeDTO.Action = (int)Like_Dislike.Dislike;


            tweetServices.Action(likeDislikeDTO);
            return Ok();
        }
        [HttpGet]
        [Route("api/tweet/tweetCount/{id}")]
        public IHttpActionResult TweetCount(int id)
        {
            return Ok(tweetServices.MyTweets(id).Count());
        }

        [HttpGet]
        [Route("api/tweet/myTweets/{id}")]
        public IHttpActionResult GetMyTweets(int id)
        {
            List<TweetDTO> tweets = new List<TweetDTO>();
            List<ListTweetModel> list = new List<ListTweetModel>();

            tweets = tweetServices.MyTweets(id);

            foreach(TweetDTO tweetDTO in tweets)
            {
                ListTweetModel listTweetModel = new ListTweetModel();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TweetDTO, ListTweetModel>());
                var mapper = config.CreateMapper();
                listTweetModel = mapper.Map<ListTweetModel>(tweetDTO);

                list.Add(listTweetModel);
            }
            list.OrderByDescending(p => p.CreatedAt);
           
            return Ok(list);
        }


        [HttpGet]
        [Route("api/tweet/getTweet/{id}")]
        public IHttpActionResult GetTweet(int id)
        {
            TweetDTO tweetDTO = new TweetDTO();
            try
            {
                tweetDTO = tweetServices.GetTweetById(id);
            }
            catch
            {
                return NotFound();
            }

            ListTweetModel listTweetModel = new ListTweetModel();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TweetDTO, ListTweetModel>());
            var mapper = config.CreateMapper();
            listTweetModel = mapper.Map<ListTweetModel>(tweetDTO);

            return Ok(listTweetModel);
        }
    }
}
