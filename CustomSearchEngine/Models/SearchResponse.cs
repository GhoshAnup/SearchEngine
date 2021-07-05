using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.Models
{
    public class SearchResponse
    {
        public SearchResponse(int[] rankingPosition)
        {
            RankingPosition = rankingPosition;
        }
        public int[] RankingPosition { get; }
    }
}
