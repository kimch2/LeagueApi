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
        static DateTime StartDate { get; set; }
        static int RunTimes { get; set; }
        static int Offset { get; set; }
        static int Action { get; set; }

        static void Main()
        {
            Console.WriteLine("Hint: Pressing enter will use default values.");

            try
            {
                Console.WriteLine("1) Collect More games.");
                Console.WriteLine("2) Update Games Missing Data");
                Action = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read action. Collecting more games.");
                Action = 1;
            }

            if (Action == 1)
            {
                try
                {
                    Console.WriteLine("How many buckets should be gather?");
                    RunTimes = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to read run count. Using default of 288 (24 hours)");
                    RunTimes = 100;
                }

                try
                {
                    Console.WriteLine("What date should we start at?");
                    DateTime startDate;
                    DateTime.TryParse(Console.ReadLine(), out startDate);
                    StartDate = startDate;
                    if (StartDate < new DateTime(2015, 4, 1))
                        throw new Exception("Invalid start date");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to read StartDate. Using default of 4/1/2015");
                    StartDate = new DateTime(2015, 4, 1);
                }

                try
                {
                    Console.WriteLine("How far from the start date should we offset? i*5min");
                    Offset = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to read offset. Using default of 0");
                    Offset = 0;
                }

                while (RunTimes >= 0)
                {
                    Console.WriteLine("Runs remaining " + RunTimes);
                    var bucketTime = BucketTime;
                    Console.WriteLine("Time " + bucketTime);
                    MatchIds = RiotService.ApiChallenge(bucketTime);
                    if (MatchIds != null && MatchIds.Count > 0)
                    {
                        AddMatchIds(bucketTime);
                        using (var riotDb = new RiotDataContext())
                        {
                            var matches = riotDb.Matches.Where(m => m.MapId == null).ToList();
                            UpdateMatches(matches, riotDb, RiotService);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches found");
                    }
                    RunTimes--;
                }
            }
            else
            {
                using (var riotDb = new RiotDataContext())
                {
                    var matches = riotDb.Matches.Where(m => m.MapId == null).ToList();
                    UpdateMatches(matches, riotDb, RiotService);
                }
            }
        }

        private static void UpdateMatches(List<Match> matches, RiotDataContext riotDb, RiotService riotServices)
        {
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
        
        static DateTime BucketDateTime
        {
            get
            {
                var start = StartDate;
                return start.AddMinutes(-start.Minute + (Offset += 5)).AddSeconds(-start.Second);
                
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
