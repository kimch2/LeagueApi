using LeagueApi.Models;
using RiotServices;

namespace RiotAPI_GameCollector.Mappers
{
    public class StatisticsMapper
    {
        public static ParticipantStat MapParticipantStat(Statistics statistics)
        {
            return new ParticipantStat
            {
                Assists = statistics.Assists,
                ChampLevel = statistics.ChampLevel,
                CombatPlayerScore = statistics.CombatPlayerScore,
                Deaths = statistics.Deaths,
                DoubleKills = statistics.DoubleKills,
                FirsInhibitorKill = statistics.FirstInhibitorKill,
                FirstBloodAssist = statistics.FirstInhibitorAssist,
                FirstBloodKill = statistics.FirstBloodKill,
                FirstInhibitorAssist = statistics.FirstInhibitorAssist,
                FirstTowerAssist = statistics.FirstTowerAssist,
                FirstTowerKill = statistics.FirstTowerKill,
                GoldEarned = statistics.GoldEarned,
                GoldSpent = statistics.GoldSpent,
                InhibitorKills = statistics.InhibitorKills,
                Item0 = statistics.Item0,
                Item1 = statistics.Item1,
                Item2 = statistics.Item2,
                Item3 = statistics.Item3,
                Item4 = statistics.Item4,
                Item5 = statistics.Item5,
                Item6 = statistics.Item6,
                KillingSprees = statistics.KillingSprees,
                Kills = statistics.Kills,
                LargestCriticalStrike = statistics.LargestCriticalStrike,
                LargestKillingSpree = statistics.LargestKillingSpree,
                LargestMultiKill = statistics.LargestMultiKill,
                MagicDamageDealt = statistics.MagicDamageDealt,
                MagicDamageDealtToChampions = statistics.MagicDamageDealtToChampions,
                MagicDamageTaken = statistics.MagicDamageTaken,
                MinionsKilled = statistics.MinionsKilled,
                NeutralMinionsKilled = statistics.NeutralMinionsKilled,
                NeutralMinionsKilledEnemyJungle = statistics.NeutralMinionsKilledEnemyJungle,
                NeutralMinionsKilledTeamJungle = statistics.NeutralMinionsKilledTeamJungle,
                ObjectivePlayerScore = statistics.ObjectivePlayerScore,
                PentaKills = statistics.PentaKills,
                PhysicalDamageDealt = statistics.PhysicalDamageDealt,
                PhysicalDamageDealtToChampions = statistics.PhysicalDamageDealtToChampions,
                PhysicalDamageTaken = statistics.PhysicalDamageTaken,
                QuadraKills = statistics.QuadraKills,
                SightWardsBoughtInGame = statistics.SightWardsBoughtInGame,
                TotalDamageDealt = statistics.TotalDamageDealt,
                TotalDamageDealtToChampions = statistics.TotalDamageDealtToChampions,
                TotalDamageTaken = statistics.TotalDamageTaken,
                TotalHeal = statistics.TotalHeal,
                TotalPlayerScore = statistics.TotalPlayerScore,
                TotalScoreRank = statistics.TotalScoreRank,
                TotalTimeCrowdControlDealt = statistics.TotalTimeCrowdControlDealt,
                TotalUnitsHealed = statistics.TotalUnitsHealed,
                TowerKills = statistics.TowerKills,
                TripleKills = statistics.TripleKills,
                TrueDamageDealt = statistics.TrueDamageDealt,
                TrueDamageDealtToChampions = statistics.TrueDamageDealtToChampions,
                TrueDamageTaken = statistics.TrueDamageTaken,
                VisionWardsBoughtInGame = statistics.VisionWardsBoughtInGame,
                WardsPlaced = statistics.WardsPlaced,
                WardsKilled = statistics.WardsKilled,
                Winner = statistics.Winner
            };
        }
    }
}
