using System;
using System.Collections.Generic;
using System.Linq;
using RiotAPI_GameCollector.Mappers;
using RiotServices;

namespace RiotAPI_GameCollector
{
    class Program
    {
        static List<int> MatchIds { get; set; }
        static readonly RiotService RiotService = new RiotService();

        static void Main(string[] args)
        {
            var runTimes = 100;

            while (runTimes >= 0) { 
                Console.WriteLine("Runs remaining " + runTimes);
                var bucketTime = BucketTime;
                MatchIds = RiotService.ApiChallenge(bucketTime);
                if (MatchIds != null && MatchIds.Count > 0)
                {
                    AddMatchIds(bucketTime);
                    UpdateMatches(RiotService);
                }
                runTimes--;
            }
        }

        private static void UpdateMatches(RiotService riotServices)
        {
            using (var riotDb = new RiotDataContext())
            {
                var matches = riotDb.Matches.Where(m => m.MapId == null);
                Console.WriteLine("Updating {0} matches.", matches.Count());

                foreach (var match in matches)
                {
                    var matchData = riotServices.MatchService(match.MatchId);
                    var currentMatch = riotDb.Matches.First(m => m.MatchId == match.MatchId);
                    currentMatch.AddMatchData(matchData);

                    foreach (var participant in matchData.Participants)
                    {
                        var stats = StatisticsMapper.MapParticipantStat(participant.Statistics);
                        currentMatch.Participants.Add(ParticipantMapper.MapParticipant(matchData, participant, stats));
                    }

                    foreach (var team in matchData.Teams)
                        currentMatch.Teams.Add(TeamMapper.MapTeam(team));
                    
                    riotDb.SubmitChanges();
                }
            }
        }

       private static void AddMatchIds(int bucketTime)
        {
            using (var riotDb = new RiotDataContext())
            {
                foreach (var matchId in MatchIds)
                    if (!riotDb.Matches.Any(m => m.MatchId == matchId))
                        riotDb.Matches.InsertOnSubmit(new Match {BucketTime = bucketTime, MatchId = matchId});

                riotDb.SubmitChanges();
            }
        }

        private static int _offset;
        static DateTime BucketDateTime
        {
            get
            {
                var now = DateTime.UtcNow;
                return now.AddHours(-24).AddMinutes(-now.Minute - (_offset -= 5)).AddSeconds(-now.Second);
                
            }
        }

        static int BucketTime
        {
            get
            {
                return Convert.ToInt32(Math.Floor((BucketDateTime - new DateTime(1970, 1, 1)).TotalSeconds));
            }
        }

    }
}
