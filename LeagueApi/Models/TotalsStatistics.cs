using System.Collections.Generic;
using System.Linq;
using RiotServices;

namespace LeagueApi.Models
{
    public class TotalsStatistics
    {
        public TotalsStatistics(IEnumerable<List<Participant>> champions)
        {
            Statistics = new List<StatisticsGroup>
            {
                new StatisticsGroup("Game",new List<StatisticItem>
                {
                    new StatisticItem("Wins", new List<long>()),
                    new StatisticItem("Losses", new List<long>())
                }),
                new StatisticsGroup("Basic", new List<StatisticItem>
                {
                    new StatisticItem("Kills", new List<long>()),
                    new StatisticItem("Deaths", new List<long>()),
                    new StatisticItem("Assists", new List<long>())
                }),
                new StatisticsGroup("Farming", new List<StatisticItem>
                {
                    new StatisticItem("Minions Killed", new List<long>()),
                    new StatisticItem("Gold Earned", new List<long>())
                }),
                new StatisticsGroup("Kill", new List<StatisticItem>
                {
                    new StatisticItem("Killing Sprees", new List<long>()),
                    new StatisticItem("Largest Killing Spree", new List<long>()),
                    new StatisticItem("Largest Multi Kill", new List<long>()),
                    new StatisticItem("Double Kills", new List<long>()),
                    new StatisticItem("Triple Kills", new List<long>()),
                    new StatisticItem("Quadra Kills", new List<long>()),
                    new StatisticItem("Penta Kills", new List<long>())
                }),
                new StatisticsGroup("Firsts", new List<StatisticItem>
                {
                    new StatisticItem("First Blood Assist", new List<long>()),
                    new StatisticItem("First Blood Kill", new List<long>()),
                    new StatisticItem("First Inhibitor Assist", new List<long>()),
                    new StatisticItem("First Inhibitor Kill", new List<long>()),
                    new StatisticItem("First Tower Assist", new List<long>()),
                    new StatisticItem("First Tower Kill", new List<long>())
                }),
                new StatisticsGroup("Objective", new List<StatisticItem>
                {
                    new StatisticItem("Inhibitor Kills", new List<long>()),
                    new StatisticItem("Tower Kills", new List<long>())
                }),
                new StatisticsGroup("Damage", new List<StatisticItem>
                {
                    new StatisticItem("Largest Critical Strike", new List<long>()),
                    new StatisticItem("Magic Damage", new List<long>()),
                    new StatisticItem("Magic Damage To Champions", new List<long>()),
                    new StatisticItem("Magic Damage Taken", new List<long>()),
                    new StatisticItem("Physical Damage", new List<long>()),
                    new StatisticItem("Physical Damage To Champions", new List<long>()),
                    new StatisticItem("Physical Damage Taken", new List<long>()),
                    new StatisticItem("Total Damage", new List<long>()),
                    new StatisticItem("Total Damage To Champions", new List<long>()),
                    new StatisticItem("Total Damage Taken", new List<long>()),
                    new StatisticItem("True Damage", new List<long>()),
                    new StatisticItem("True Damage To Champions", new List<long>()),
                    new StatisticItem("True Damage Taken", new List<long>())
                }),
                new StatisticsGroup("Healing", new List<StatisticItem>
                {
                    new StatisticItem("Total Healing", new List<long>()),
                    new StatisticItem("Total Units Healed", new List<long>()),
                    new StatisticItem("Total Time Crowd Control Dealt", new List<long>()),
                }),

                new StatisticsGroup("Jungle", new List<StatisticItem>
                {
                    new StatisticItem("Neutral Minions Killed", new List<long>()),
                    new StatisticItem("Neutral Minions Killed Enemy Jungle", new List<long>()),
                    new StatisticItem("Neutral Minions Killed Team Jungle", new List<long>())
                }),

                new StatisticsGroup("Vision", new List<StatisticItem>
                {
                    new StatisticItem("Sight Wards Bought", new List<long>()),
                    new StatisticItem("Vision Wards Bought", new List<long>()),
                    new StatisticItem("Wards Placed", new List<long>()),
                    new StatisticItem("Wards Killed", new List<long>())
                })
            };

            var gameSection = Statistics.First(x => x.Name == "Game").Values;
            var basicSection = Statistics.First(x => x.Name == "Basic").Values;
            var farmingSection = Statistics.First(x => x.Name == "Farming").Values;
            var killSection = Statistics.First(x => x.Name == "Kill").Values;
            var firstsSection = Statistics.First(x => x.Name == "Firsts").Values;
            var objectiveSection = Statistics.First(x => x.Name == "Objective").Values;
            var damageSection = Statistics.First(x => x.Name == "Damage").Values;
            var healingSection = Statistics.First(x => x.Name == "Healing").Values;
            var jungleSection = Statistics.First(x => x.Name == "Jungle").Values;
            var visionSection = Statistics.First(x => x.Name == "Vision").Values;

            foreach (var participants in champions)
            {
                gameSection.First(x => x.Name == "Wins")
                    .Values.Add(participants.Count(x => x.ParticipantStat.Winner == true));

                gameSection.First(x => x.Name == "Losses")
                    .Values.Add(participants.Count(x => x.ParticipantStat.Winner == false));

                basicSection.First(x => x.Name == "Kills")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.Kills ?? 0));

                basicSection.First(x => x.Name == "Deaths")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.Deaths ?? 0));

                basicSection.First(x => x.Name == "Assists")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.Assists ?? 0));

                farmingSection.First(x => x.Name == "Minions Killed")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.MinionsKilled ?? 0));

                farmingSection.First(x => x.Name == "Gold Earned")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.GoldEarned ?? 0));

                killSection.First(x => x.Name == "Killing Sprees")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.KillingSprees ?? 0));

                killSection.First(x => x.Name == "Largest Killing Spree")
                    .Values.Add(participants.Max(x => x.ParticipantStat.KillingSprees ?? 0));

                killSection.First(x => x.Name == "Largest Multi Kill")
                    .Values.Add(participants.Max(x => x.ParticipantStat.LargestMultiKill ?? 0));

                killSection.First(x => x.Name == "Double Kills")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.DoubleKills ?? 0));

                killSection.First(x => x.Name == "Triple Kills")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TripleKills ?? 0));

                killSection.First(x => x.Name == "Quadra Kills")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.QuadraKills ?? 0));

                killSection.First(x => x.Name == "Penta Kills")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.PentaKills ?? 0));

                firstsSection.First(x => x.Name == "First Blood Assist")
                    .Values.Add(participants.Count(x => x.ParticipantStat.FirstBloodAssist == true));

                firstsSection.First(x => x.Name == "First Blood Kill")
                    .Values.Add(participants.Count(x => x.ParticipantStat.FirstBloodKill == true));

                firstsSection.First(x => x.Name == "First Inhibitor Assist")
                    .Values.Add(participants.Count(x => x.ParticipantStat.FirstInhibitorAssist == true));

                firstsSection.First(x => x.Name == "First Inhibitor Kill")
                    .Values.Add(participants.Count(x => x.ParticipantStat.FirsInhibitorKill == true));

                firstsSection.First(x => x.Name == "First Tower Assist")
                    .Values.Add(participants.Count(x => x.ParticipantStat.FirstTowerAssist == true));

                firstsSection.First(x => x.Name == "First Tower Kill")
                    .Values.Add(participants.Count(x => x.ParticipantStat.FirstTowerKill == true));

                objectiveSection.First(x => x.Name == "Inhibitor Kills")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.InhibitorKills ?? 0));

                objectiveSection.First(x => x.Name == "Tower Kills")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TowerKills ?? 0));

                damageSection.First(x => x.Name == "Largest Critical Strike")
                    .Values.Add(participants.Max(x => x.ParticipantStat.LargestCriticalStrike ?? 0));

                damageSection.First(x => x.Name == "Magic Damage")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.MagicDamageDealt ?? 0));

                damageSection.First(x => x.Name == "Magic Damage To Champions")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.MagicDamageDealtToChampions ?? 0));

                damageSection.First(x => x.Name == "Magic Damage Taken")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.MagicDamageTaken ?? 0));

                damageSection.First(x => x.Name == "Physical Damage")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.PhysicalDamageDealt ?? 0));

                damageSection.First(x => x.Name == "Physical Damage To Champions")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.PhysicalDamageDealtToChampions ?? 0));

                damageSection.First(x => x.Name == "Physical Damage Taken")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.PhysicalDamageTaken ?? 0));

                damageSection.First(x => x.Name == "Total Damage")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TotalDamageDealt ?? 0));

                damageSection.First(x => x.Name == "Total Damage To Champions")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TotalDamageDealtToChampions ?? 0));

                damageSection.First(x => x.Name == "Total Damage Taken")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TotalDamageTaken ?? 0));

                damageSection.First(x => x.Name == "True Damage")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TrueDamageDealt ?? 0));

                damageSection.First(x => x.Name == "True Damage To Champions")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TrueDamageDealtToChampions ?? 0));

                damageSection.First(x => x.Name == "True Damage Taken")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TrueDamageTaken ?? 0));

                healingSection.First(x => x.Name == "Total Healing")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TotalHeal ?? 0));

                healingSection.First(x => x.Name == "Total Units Healed")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TotalUnitsHealed ?? 0));

                healingSection.First(x => x.Name == "Total Time Crowd Control Dealt")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.TotalTimeCrowdControlDealt ?? 0));

                jungleSection.First(x => x.Name == "Neutral Minions Killed")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.NeutralMinionsKilled ?? 0));

                jungleSection.First(x => x.Name == "Neutral Minions Killed Enemy Jungle")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.NeutralMinionsKilledEnemyJungle ?? 0));

                jungleSection.First(x => x.Name == "Neutral Minions Killed Team Jungle")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.NeutralMinionsKilledTeamJungle ?? 0));

                visionSection.First(x => x.Name == "Sight Wards Bought")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.SightWardsBoughtInGame ?? 0));

                visionSection.First(x => x.Name == "Vision Wards Bought")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.VisionWardsBoughtInGame ?? 0));

                visionSection.First(x => x.Name == "Wards Placed")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.WardsPlaced ?? 0));

                visionSection.First(x => x.Name == "Wards Killed")
                    .Values.Add(participants.Sum(x => x.ParticipantStat.WardsKilled ?? 0));
            }
        }

        public List<StatisticsGroup> Statistics { get; set; }
    }

    public class StatisticsGroup
    {
        public StatisticsGroup(string name, List<StatisticItem> values)
        {
            Name = name;
            Values = values;
        }

        public string Name { get; set; }
        public List<StatisticItem> Values { get; set; }
    }

    public class StatisticItem
    {
        public StatisticItem(string name, List<long> values)
        {
            Name = name;
            Values = values;
        }
        public string Name { get; set; }
        public List<long> Values { get; set; }
    }
}