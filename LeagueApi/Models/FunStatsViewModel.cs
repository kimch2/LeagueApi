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
        public int GamesWithNoBarons { get; set; }
        public ChampionsResponse ChampionData { get; set; }
        public List<PlayedChampionData> MostPlayedChampions { get; set; }
        public List<PlayedChampionData> LeastPlayedChampions { get; set; }
        public int GamesWithNoDragons { get; set; }
        public List<WinRateChampionData> WinRateChampionData { get; set; }
    }

    public class PlayedChampionData
    {
        public int ChampionId { get; set; }
        public int PlayCount { get; set; }
    }

    public class WinRateChampionData
    {
        public int ChampionId { get; set; }
        public int WinCount { get; set; }
        public int LossCount { get; set; }

        public double WinRate
        {
            get { return (((double) WinCount)/(WinCount + LossCount))*100; }
        }
    }
}