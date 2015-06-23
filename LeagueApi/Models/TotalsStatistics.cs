using System.Collections.Generic;
using System.Linq;
using RiotServices;

namespace LeagueApi.Models
{
    public class TotalsStatistics
    {
        public TotalsStatistics(IEnumerable<int?> ids, RiotDataContext riotDb)
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

            foreach (var id in ids)
            {
                var champion = riotDb.ChampionStats.First(x => x.ChampionId == id);

                gameSection.First(x => x.Name == "Wins").Values.Add(champion.Wins ?? 0);
                gameSection.First(x => x.Name == "Losses").Values.Add(champion.Losses ?? 0);
                basicSection.First(x => x.Name == "Kills").Values.Add(champion.Kills ?? 0);
                basicSection.First(x => x.Name == "Deaths").Values.Add(champion.Deaths ?? 0);
                basicSection.First(x => x.Name == "Assists").Values.Add(champion.Assists ?? 0);
                farmingSection.First(x => x.Name == "Minions Killed").Values.Add(champion.MinionsKilled ?? 0);
                farmingSection.First(x => x.Name == "Gold Earned").Values.Add(champion.GoldEarned ?? 0);
                killSection.First(x => x.Name == "Killing Sprees").Values.Add(champion.KillingSprees ?? 0);
                killSection.First(x => x.Name == "Largest Killing Spree").Values.Add(champion.LargestKillingSpree ?? 0);
                killSection.First(x => x.Name == "Largest Multi Kill").Values.Add(champion.LargestMultiKill ?? 0);
                killSection.First(x => x.Name == "Double Kills").Values.Add(champion.DoubleKills ?? 0);
                killSection.First(x => x.Name == "Triple Kills").Values.Add(champion.TripleKills ?? 0);
                killSection.First(x => x.Name == "Quadra Kills").Values.Add(champion.QuadraKills ?? 0);
                killSection.First(x => x.Name == "Penta Kills").Values.Add(champion.PentaKills ?? 0);
                firstsSection.First(x => x.Name == "First Blood Assist").Values.Add(champion.FirstBloodAssists ?? 0);
                firstsSection.First(x => x.Name == "First Blood Kill").Values.Add(champion.FirstBloodKill ?? 0);
                firstsSection.First(x => x.Name == "First Inhibitor Assist").Values.Add(champion.FirstInhibitorAssist ?? 0);
                firstsSection.First(x => x.Name == "First Inhibitor Kill").Values.Add(champion.FirsInhibitorKill ?? 0);
                firstsSection.First(x => x.Name == "First Tower Assist").Values.Add(champion.FirstTowerAssist ?? 0);
                firstsSection.First(x => x.Name == "First Tower Kill").Values.Add(champion.FirstTowerKill ?? 0);
                objectiveSection.First(x => x.Name == "Inhibitor Kills").Values.Add(champion.InhibitorKills ?? 0);
                objectiveSection.First(x => x.Name == "Tower Kills").Values.Add(champion.TowerKills ?? 0);
                damageSection.First(x => x.Name == "Largest Critical Strike").Values.Add(champion.LargestCriticalStrike ?? 0);
                damageSection.First(x => x.Name == "Magic Damage").Values.Add(champion.MagicDamageDealt ?? 0);
                damageSection.First(x => x.Name == "Magic Damage To Champions").Values.Add(champion.MagicDamageDealtToChampions ?? 0);
                damageSection.First(x => x.Name == "Magic Damage Taken").Values.Add(champion.MagicDamageTaken ?? 0);
                damageSection.First(x => x.Name == "Physical Damage").Values.Add(champion.PhysicalDamageDealt ?? 0);
                damageSection.First(x => x.Name == "Physical Damage To Champions").Values.Add(champion.PhysicalDamageDealtToChampions ?? 0);
                damageSection.First(x => x.Name == "Physical Damage Taken").Values.Add(champion.PhysicalDamageTaken ?? 0);
                damageSection.First(x => x.Name == "Total Damage").Values.Add(champion.TotalDamageDealt ?? 0);
                damageSection.First(x => x.Name == "Total Damage To Champions").Values.Add(champion.TotalDamageDealtToChampions ?? 0);
                damageSection.First(x => x.Name == "Total Damage Taken").Values.Add(champion.TotalDamageTaken ?? 0);
                damageSection.First(x => x.Name == "True Damage").Values.Add(champion.TrueDamageDealt ?? 0);
                damageSection.First(x => x.Name == "True Damage To Champions").Values.Add(champion.TrueDamageDealtToChampions ?? 0);
                damageSection.First(x => x.Name == "True Damage Taken").Values.Add(champion.TrueDamageTaken ?? 0);
                healingSection.First(x => x.Name == "Total Healing").Values.Add(champion.TotalHealing ?? 0);
                healingSection.First(x => x.Name == "Total Units Healed").Values.Add(champion.TotalUnitsHealed ?? 0);
                healingSection.First(x => x.Name == "Total Time Crowd Control Dealt").Values.Add(champion.TotalTimeCrowdControlDealt ?? 0);
                jungleSection.First(x => x.Name == "Neutral Minions Killed").Values.Add(champion.NeutralMinionsKilled ?? 0);
                jungleSection.First(x => x.Name == "Neutral Minions Killed Enemy Jungle").Values.Add(champion.NeutralMinionsKilledEnemyJungle ?? 0);
                jungleSection.First(x => x.Name == "Neutral Minions Killed Team Jungle").Values.Add(champion.NeutralMinionsKilledTeamJungle ?? 0);
                visionSection.First(x => x.Name == "Sight Wards Bought").Values.Add(champion.SightWardsBoughtInGame ?? 0);
                visionSection.First(x => x.Name == "Vision Wards Bought").Values.Add(champion.VisionWardsBoughtInGame ?? 0);
                visionSection.First(x => x.Name == "Wards Placed").Values.Add(champion.WardsPlaced ?? 0);
                visionSection.First(x => x.Name == "Wards Killed").Values.Add(champion.WardsKilled ?? 0);
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