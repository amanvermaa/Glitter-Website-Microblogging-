using _2.Glitter_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1.Glitter_Presentation.Controllers
{
    public class AnalyticsController : ApiController
    {

        private AnalyticsService analyticsService = new AnalyticsService();


        [HttpGet]
        [Route("api/analytics/trendingHashtag")]
        public string Trending()
        {
            string hash = analyticsService.TrendingHash();
            return hash;

        }


        [HttpGet]
        [Route("api/analytics/MostLiked")]
        public string MostLiked()
        {
            return null;
        }
    }
}
