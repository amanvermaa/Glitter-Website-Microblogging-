using _3.Glitter_DAL.Operations;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Glitter_BL
{
    public class TweetServices
    {
        private TweetOperations tweetOperations = new TweetOperations();
        public void CreateTweet(TweetDTO tweetDTO)
        {
            tweetOperations.CreateTweet(tweetDTO);
        }
        public void Delete(int id)
        {
            tweetOperations.Delete(id);
        }
        public void Edit(TweetDTO tweetDTO)
        {
            tweetOperations.Edit(tweetDTO);
        }
        public TweetDTO GetTweetById(int id)
        {
            return tweetOperations.GetTweetById(id);
        }
        public void Action(LikeDislikeDTO likeDislikeDTO)
        {
            tweetOperations.Action(likeDislikeDTO);
        }
        public int TotalLikes(int id)
        {
            return tweetOperations.TotalLikes(id);
        }
        public int TotalDislikes(int id)
        {
            return tweetOperations.TotalDislikes(id);
        }
        public List<TweetDTO> MyTweets(int id)
        {
            return tweetOperations.GetMyTweets(id);
        }
        public List<TweetDTO> GetFollowingTweets(int id)
        {
            return tweetOperations.GetFollowingTweets(id);
        }
        
        public List<TweetDTO> GetAllTweetsForUser(int id)
        {
            return tweetOperations.GetAllTweetsForUser(id);
        }

        
    }
}
 