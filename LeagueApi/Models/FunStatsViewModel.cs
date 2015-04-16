using System.Collections.Generic;
using RiotServices;

namespace LeagueApi.Models
{
    public class FunStatViewModel
    {
        public FunStatViewModel()
        {
            WinData = new List<FunStatsResponse>();
        }
        public int MatchCount { get; set; }
        public List<FunStatsResponse> WinData { get; set; }
    }
}