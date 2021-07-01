using _3.Glitter_DAL.Operations;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Glitter_BL
{
    public class PlaygroundServices
    {
        private UserOperations userOperations = new UserOperations();
        private TweetOperations tweetOperations = new TweetOperations();
        private PlaygroundOperations playgroundOperations = new PlaygroundOperations();

        public List<UserDTO> SearchUser(string text)
        {
            return userOperations.SearchUser(text);

        }
        public List<HashtagDTO> SearchHashtag(string text)
        {
            return playgroundOperations.SearchHashtag(text);

        }
        
    }
}
