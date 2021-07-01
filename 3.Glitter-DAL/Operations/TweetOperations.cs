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
    public class TweetOperations
    {
        private GlitterDbContext db = new GlitterDbContext();
        private TweetHelper tweetHelper = new TweetHelper();
        private UserOperations userOperations = new UserOperations();


        public void CreateTweet(TweetDTO tweetDTO)
        {
            Tweet tweet = tweetHelper.TweetDTO2Tweet(tweetDTO);
            FindHashtags(tweet.Message);
            db.Tweets.Add(tweet);
            db.SaveChanges();
        }
        public TweetDTO GetTweetById(int id)
        {
            Tweet tweet = db.Tweets.Single(data => data.TweetID == id);

            TweetDTO tweetDTO = new TweetDTO();
            tweetDTO.TweetID = tweet.TweetID;
            tweetDTO.Message = tweet.Message;
            tweetDTO.UserID = tweet.UserID;
            tweetDTO.CreatedAt = tweet.CreatedAt;

            return tweetDTO;

        }
        public void Delete(int id)
        {
            Tweet tweet = db.Tweets.Find(id);
            List<LikeDislike> likeDislikes = db.LikeDislikes.Where(d => d.TweetID == tweet.TweetID).ToList();

            foreach (LikeDislike likeDislike in likeDislikes)
            {
                db.LikeDislikes.Remove(likeDislike);
                db.SaveChanges();
            }

            db.Tweets.Remove(tweet);
            db.SaveChanges();
        }
        public void Edit(TweetDTO tweetDTO)
        {
            Tweet tweet = new Tweet();
            tweet.TweetID = tweetDTO.TweetID;
            tweet.UserID = tweetDTO.UserID;
            tweet.Message = tweetDTO.Message;
            tweet.CreatedAt = tweetDTO.CreatedAt;

            Tweet tweetMaster = db.Tweets.Single(p => p.TweetID == tweet.TweetID);
            tweetMaster.Message = tweet.Message;
            tweetMaster.CreatedAt = tweet.CreatedAt;
            db.SaveChanges();
        }
        public List<TweetDTO> GetMyTweets(int id)
        {
            List<TweetDTO> tweetDTOs = new List<TweetDTO>();
            List<Tweet> tweets = new List<Tweet>();
            try
            {
                tweets = db.Tweets.Where(data => data.UserID == id).ToList();
            }
            catch
            {
                return tweetDTOs;
            }

            if (tweets == null)
                return tweetDTOs = null;
            else
            {
                foreach (Tweet tweet in tweets)
                {
                    TweetDTO t = new TweetDTO();
                    t.TweetID = tweet.TweetID;
                    t.UserID = tweet.UserID;
                    t.Message = tweet.Message;
                    t.CreatedAt = tweet.CreatedAt;

                    tweetDTOs.Add(t);
                }
                return tweetDTOs;
            }
        }

        public List<TweetDTO> GetFollowingTweets(int id)
        {
            List<TweetDTO> tweetDTOs = new List<TweetDTO>();
            List<UserDTO> usersFollowing = new List<UserDTO>();
            try
            {
                usersFollowing = userOperations.Following(id);
            }
            catch
            {
                return tweetDTOs;
            }
            List<TweetDTO> tweets = new List<TweetDTO>();
            foreach (UserDTO userDTO in usersFollowing)
            {
                try
                {
                    tweets = GetMyTweets(userDTO.UserID);
                }
                catch
                {
                    continue;

                }

                foreach (TweetDTO tweetDTO in tweets)
                {
                    tweetDTOs.Add(tweetDTO);
                }
            
            }
            return tweetDTOs;
        }
    public List<TweetDTO> GetAllTweetsForUser(int id)
    {
        List<TweetDTO> MyTweets = GetMyTweets(id);
        List<TweetDTO> MyFollowingTweets = GetFollowingTweets(id);

        return MyTweets.Concat(MyFollowingTweets).ToList();

    }
    public void Action(LikeDislikeDTO likeDislikeDTO) //Like or Dislike Tweet
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<LikeDislikeDTO, LikeDislike>());
        var mapper = config.CreateMapper();
        LikeDislike likeDislike = mapper.Map<LikeDislike>(likeDislikeDTO);

        try
        {
            var temp = db.LikeDislikes.Single(d => d.UserID == likeDislike.UserID && d.TweetID == likeDislike.TweetID);
            temp.Action = likeDislike.Action;
            db.SaveChanges();
        }
        catch
        {
            db.LikeDislikes.Add(likeDislike);
            db.SaveChanges();
        }

    }

    public int TotalLikes(int id) //1 means like 
    {
        return db.LikeDislikes.Where(data => data.TweetID == id && data.Action == 1).Count();
    }
    public int TotalDislikes(int id) //-1 means Dislike
    {

        return db.LikeDislikes.Where(data => data.TweetID == id && data.Action == -1).Count();
    }




    public void FindHashtags(string text1)
    {
        Hashtag hashtag = new Hashtag();
        string text = text1.Trim();
        String[] content = text.Split(' ');
        foreach (String str in content)
        {
            if (str[0] == '#')
            {
                var temp = db.Hashtags.Any(data => data.HastagText == str);
                if (!temp)
                {
                    hashtag.HastagText = str;
                    hashtag.count = 1;
                    db.Hashtags.Add(hashtag);
                    db.SaveChanges();
                }
                else
                {
                    Hashtag hash = db.Hashtags.Single(data => data.HastagText == str);

                    hash.count += 1;
                    db.SaveChanges();
                }
            }
        }

    }

}
}
