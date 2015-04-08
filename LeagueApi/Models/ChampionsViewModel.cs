using System.Collections.Generic;

namespace LeagueApi.Models
{
    public class ChampionsViewModel
    {
        public ChampionsViewModel()
        {
            MatchData = new List<MatchResponse>();
        }

        public ChampionsResponse ChampionData { get; set; }
        public IEnumerable<int> Matches { get; set; }
        public List<MatchResponse> MatchData { get; set; }
    }
}