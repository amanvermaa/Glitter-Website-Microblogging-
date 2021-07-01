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
    public class TweetHelper
    {
        public TweetDTO Tweet2TweetDTO(Tweet tweet)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Tweet, TweetDTO>());
            var mapper = config.CreateMapper();
            TweetDTO tweetDTO = mapper.Map<TweetDTO>(tweet);
            return tweetDTO;
        }
        public Tweet TweetDTO2Tweet(TweetDTO tweetDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TweetDTO, Tweet>());
            var mapper = config.CreateMapper();
            Tweet tweet = mapper.Map<Tweet>(tweetDTO);
            return tweet;
        }

        public List<TweetDTO> TweetList2TweetDTOList(List<Tweet> tweets)
        {
            List<TweetDTO> tweetDTOs = new List<TweetDTO>();
            foreach(Tweet tweet in tweets)
            {
                tweetDTOs.Add(Tweet2TweetDTO(tweet));                
            }
            return tweetDTOs;
        }
        public List<Tweet> TweetDTOList2TweetList(List<TweetDTO> tweetDTOs)
        {
            List<Tweet> tweets = new List<Tweet>();
            foreach(TweetDTO tweetDTO in tweetDTOs)
            {
                tweets.Add(TweetDTO2Tweet(tweetDTO));
            }
            return tweets;
        }
    }
}
