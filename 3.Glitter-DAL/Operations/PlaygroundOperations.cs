using _3.Glitter_DAL.Entity;
using AutoMapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL.Operations
{
    public class PlaygroundOperations
    {
        private GlitterDbContext db = new GlitterDbContext();


        public List<HashtagDTO> SearchHashtag(string text)
        {
            List<Hashtag> hashtags =  db.Hashtags.Where(x => x.HastagText.StartsWith(text)||text==null).ToList();
            List<HashtagDTO> hashtagDTOs = new List<HashtagDTO>();
            foreach (Hashtag hash in hashtags)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Hashtag, HashtagDTO>());
                var mapper = config.CreateMapper();
                HashtagDTO hashtagDTO = mapper.Map<HashtagDTO>(hash);
                hashtagDTOs.Add(hashtagDTO);
            }
            return hashtagDTOs;

        }

       

    }


}
