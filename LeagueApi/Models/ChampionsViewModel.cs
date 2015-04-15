using System;
using System.Collections.Generic;
using System.Linq;
using RiotServices;

namespace LeagueApi.Models
{
    public class ChampionsViewModel
    {
        public TotalsStatistics ChampionTotals { get; set; }
        public List<ChampionResponse> AvailableChampions { get; set; }
        public List<int?> ChampionIds { get; set; }
        public int ChampionCount { get; set; }

        public Dictionary<string, int> ChampionNames
        {
            get
            {
                return AvailableChampions.Select(x => new Tuple<string, int>(x.Name, x.Id))
                    .ToDictionary(x => x.Item1, x => x.Item2);
            }
        }
    }
}