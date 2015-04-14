using RiotServices;

namespace RiotAPI_GameCollector.Mappers
{
    public static class MatchMapper
    {
        public static void AddMatchData(this Match currentMatch, MatchResponse matchData)
        {
            currentMatch.MapId = matchData.MapId;
            currentMatch.MatchCreation = matchData.MatchCreation;
            currentMatch.MatchDuration = matchData.MatchDuration;
            currentMatch.MatchMode = matchData.MatchMode;
            currentMatch.MatchType = matchData.MatchType;
            currentMatch.MatchVersion = matchData.MatchVersion;
            currentMatch.PlatformId = matchData.PlatformId;
            currentMatch.QueueType = matchData.QueueType;
            currentMatch.Region = matchData.Region;
            currentMatch.Season = matchData.Season;
        }
    }
}
