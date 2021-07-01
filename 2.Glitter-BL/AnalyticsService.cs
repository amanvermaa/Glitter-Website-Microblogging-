using _3.Glitter_DAL.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Glitter_BL
{
    public class AnalyticsService
    {
        private AnalyticsOperations analyticsOperations = new AnalyticsOperations();


        public string TrendingHash()
        {
            return analyticsOperations.TrendingHash();
        }
    }
}
