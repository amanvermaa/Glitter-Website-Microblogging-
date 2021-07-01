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
    public class FollowHelper
    {
        public FollowDTO Follow2FollowDTO(Follow follow)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Follow, FollowDTO>());
            var mapper = config.CreateMapper();

            return mapper.Map<FollowDTO>(follow);
        }

        public Follow FollowDTO2Follow(FollowDTO followDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FollowDTO, Follow>());
            var mapper = config.CreateMapper();

            return mapper.Map<Follow>(followDTO);
        }

        public List<FollowDTO> FollowList2FollowDTOList(List<Follow> follows)
        {
            List<FollowDTO> followDTOs = new List<FollowDTO>();
            
            foreach(Follow follow in follows)
            {
                FollowDTO followDTO = Follow2FollowDTO(follow);
                followDTOs.Add(followDTO);
            }

            return followDTOs;
        }
        public List<Follow> FollowDTOList2FollowList(List<FollowDTO> followDTOs)
        {
            List<Follow> follows = new List<Follow>();
            foreach(FollowDTO followDTO in followDTOs)
            {
                Follow follow = FollowDTO2Follow(followDTO);
                follows.Add(follow);
            }
            return follows;
        }
    }

}
