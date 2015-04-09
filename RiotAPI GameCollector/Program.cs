using System;
using System.Collections.Generic;
using System.Linq;
using RiotServices;

namespace RiotAPI_GameCollector
{
    class Program
    {
        static List<int> MatchIds { get; set; }

        static void Main(string[] args)
        {
            //var arg = args.First().ToLower();
            
            MatchIds = ApiChallengeService.CallService(BucketTime);

            using (var riotDb = new RiotDataContext())
            {
                foreach (var matchId in MatchIds)
                    if (!riotDb.Matches.Any(m => m.MatchId == matchId))
                        riotDb.Matches.InsertOnSubmit(new Match { MatchId = matchId });

                riotDb.SubmitChanges();
            }

            using (var riotDb = new RiotDataContext())
            {
                var matches = riotDb.Matches;//.Where(m => m.MapId == null);

                foreach (var match in matches)
                {
                    var matchData = MatchService.CallService(match.MatchId);

                    var currentMatch = riotDb.Matches.First(m => m.MatchId == match.MatchId);
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


                    foreach (var participant in matchData.Participants)
                    {
                        var stats = new ParticipantStat
                        {
                            Assists = participant.Statistics.Assists,
                            ChampLevel = participant.Statistics.ChampLevel,
                            CombatPlayerScore = participant.Statistics.CombatPlayerScore,
                            Deaths = participant.Statistics.Deaths,
                            DoubleKills = participant.Statistics.DoubleKills,
                            FirsInhibitorKill = participant.Statistics.FirstInhibitorKill,
                            FirstBloodAssist = participant.Statistics.FirstInhibitorAssist,
                            FirstBloodKill = participant.Statistics.FirstBloodKill,
                            FirstInhibitorAssist = participant.Statistics.FirstInhibitorAssist,
                            FirstTowerAssist = participant.Statistics.FirstTowerAssist,
                            FirstTowerKill = participant.Statistics.FirstTowerKill,
                            GoldEarned = participant.Statistics.GoldEarned,
                            GoldSpent = participant.Statistics.GoldSpent,
                            InhibitorKills = participant.Statistics.InhibitorKills,
                            Item0 = participant.Statistics.Item0,
                            Item1 = participant.Statistics.Item1,
                            Item2 = participant.Statistics.Item2,
                            Item3 = participant.Statistics.Item3,
                            Item4 = participant.Statistics.Item4,
                            Item5 = participant.Statistics.Item5,
                            Item6 = participant.Statistics.Item6,
                            KillingSprees = participant.Statistics.KillingSprees,
                            Kills = participant.Statistics.Kills,
                            LargestCriticalStrike = participant.Statistics.LargestCriticalStrike,
                            LargestKillingSpree = participant.Statistics.LargestKillingSpree,
                            LargestMultiKill = participant.Statistics.LargestMultiKill,
                            MagicDamageDealt = participant.Statistics.MagicDamageDealt,
                            MagicDamageDealtToChampions = participant.Statistics.MagicDamageDealtToChampions,
                            MagicDamageTaken = participant.Statistics.MagicDamageTaken,
                            MinionsKilled = participant.Statistics.MinionsKilled,
                            NeutralMinionsKilled = participant.Statistics.NeutralMinionsKilled,
                            NeutralMinionsKilledEnemyJungle = participant.Statistics.NeutralMinionsKilledEnemyJungle,
                            NeutralMinionsKilledTeamJungle = participant.Statistics.NeutralMinionsKilledTeamJungle,
                            ObjectivePlayerScore = participant.Statistics.ObjectivePlayerScore,
                            PentaKills = participant.Statistics.PentaKills,
                            PhysicalDamageDealt = participant.Statistics.PhysicalDamageDealt,
                            PhysicalDamageDealtToChampions = participant.Statistics.PhysicalDamageDealtToChampions,
                            PhysicalDamageTaken = participant.Statistics.PhysicalDamageTaken,
                            QuadraKills = participant.Statistics.QuadraKills,
                            SightWardsBoughtInGame = participant.Statistics.SightWardsBoughtInGame,
                            TotalDamageDealt = participant.Statistics.TotalDamageDealt,
                            TotalDamageDealtToChampions = participant.Statistics.TotalDamageDealtToChampions,
                            TotalDamageTaken = participant.Statistics.TotalDamageTaken,
                            TotalHeal = participant.Statistics.TotalHeal,
                            TotalPlayerScore = participant.Statistics.TotalPlayerScore,
                            TotalScoreRank = participant.Statistics.TotalScoreRank,
                            TotalTimeCrowdControlDealt = participant.Statistics.TotalTimeCrowdControlDealt,
                            TotalUnitsHealed = participant.Statistics.TotalUnitsHealed,
                            TowerKills = participant.Statistics.TowerKills,
                            TripleKills = participant.Statistics.TripleKills,
                            TrueDamageDealt = participant.Statistics.TrueDamageDealt,
                            TrueDamageDealtToChampions = participant.Statistics.TrueDamageDealtToChampions,
                            TrueDamageTaken = participant.Statistics.TrueDamageTaken,
                            VisionWardsBoughtInGame = participant.Statistics.VisionWardsBoughtInGame,
                            WardsKilled = participant.Statistics.WardsPlaced,
                            Winner = participant.Statistics.Winner
                        };

                        currentMatch.Participants.Add(new Participant
                        {
                            MatchId = matchData.MatchId,
                            ChampionId = participant.ChampionId,
                            HighestAchievedSeasonTier = participant.HighestAchievedSeasonTier,
                            ParticipantId = participant.ParticipantId,
                            ParticipantStat = stats,
                            Spell1Id = participant.Spell1Id,
                            Spell2Id = participant.Spell2Id,
                            TeamId = participant.TeamId
                        });

                    }

                    foreach (var team in matchData.Teams)
                    {
                        currentMatch.Teams.Add(new Team
                        {
                            BaronKills = team.BaronKills,
                            DominionVictoryScore = team.DominionVictoryScore,
                            DragonKills = team.DragonKills,
                            FirstBaron = team.FirstBaron,
                            FirstBlood = team.FirstBlood,
                            FirstDragon = team.FirstDragon,
                            InhibitorKills = team.InhibitorKills,
                            TeamId = team.TeamId,
                            TowerKills = team.TowerKills,
                            VilemaxKills = team.VilemawKills,
                            Winner = team.Winner
                        });
                    }
                    riotDb.SubmitChanges();
                }
            }
        }

        static DateTime BucketDateTime
        {
            get
            {
                var now = DateTime.UtcNow;
                return now.AddHours(-1).AddMinutes(-now.Minute).AddSeconds(-now.Second);
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
