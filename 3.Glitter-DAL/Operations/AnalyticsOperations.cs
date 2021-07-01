using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Glitter_DAL.Operations
{
    public class AnalyticsOperations
    {
        private GlitterDbContext db = new GlitterDbContext();
        public string TrendingHash()
        {
            var hashtagCount = db.Hashtags.Max(p => p.count);
            var record = db.Hashtags.Where(data => data.count == hashtagCount).SingleOrDefault();
            return record.HastagText;
        }

    }
}
