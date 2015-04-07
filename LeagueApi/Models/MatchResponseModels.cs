using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueApi.Models
{
    public class MatchResponse
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("matchType")]
        public string MatchType { get; set; }

        [JsonProperty("matchCreation")]
        public long MatchCreation { get; set; }

        [JsonProperty("participants")]
        public List<Player> Participants { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("participantIdentities")]
        public List<PaticipantId> ParticipantIdentities { get; set; }

        [JsonProperty("matchVersion")]
        public string MatchVersion { get; set; }

        [JsonProperty("teams")]
        public List<Team> Teams { get; set; }

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        [JsonProperty("matchId")]
        public int MatchId { get; set; }

        [JsonProperty("matchDuration")]
        public int MatchDuration { get; set; }
    }

    public class Player
    {
        [JsonProperty("masteries")]
        public List<Mastery> Masteries { get; set; }

        [JsonProperty("stats")]
        public Statistics Statistics { get; set; }

        [JsonProperty("runes")]
        public List<Rune> Runes { get; set; }


        //TimeLine TimeLine { get; set; }

        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }

        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("highestAchievedSeasonTier")]
        public string HighestAchievedSeasonTier { get; set; }

        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }
    }

    public class Mastery
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("masteryId")]
        public int Id { get; set; }
    }

    public class Statistics
    {
        [JsonProperty("unrealKills")]
        public int UnrealKills { get; set; }

        [JsonProperty("item0")]
        public int Item0 { get; set; }

        [JsonProperty("item1")]
        public int Item1 { get; set; }

        [JsonProperty("item2")]
        public int Item2 { get; set; }

        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }

        [JsonProperty("pentaKills")]
        public int PentaKills { get; set; }

        [JsonProperty("sightWardsBoughtInGame")]
        public int SightWardsBoughtInGame { get; set; }

        [JsonProperty("winner")]
        public bool Winner { get; set; }

        [JsonProperty("magicDamageDealt")]
        public int MagicDamageDealt { get; set; }

        [JsonProperty("wardsKilled")]
        public int WardsKilled { get; set; }

        [JsonProperty("largestCriticalStrike")]
        public int LargestCriticalStrike { get; set; }

        [JsonProperty("trueDamageDealt")]
        public int TrueDamageDealt { get; set; }

        [JsonProperty("doubleKills")]
        public int DoubleKills { get; set; }

        [JsonProperty("physicalDamageDealt")]
        public int PhysicalDamageDealth { get; set; }

        [JsonProperty("tripleKills")]
        public int TripleKills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        [JsonProperty("magicDamageDealtToChampions")]
        public int MagicDamageDealtToChampions { get; set; }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("visionWardsBoughtInGame")]
        public int VisionWardsBoughtInGame { get; set; }

        [JsonProperty("totalTimeCrowdControlDealt")]
        public int TotalTimeCrowdControlDealt { get; set; }

        [JsonProperty("champLevel")]
        public int ChampLevel { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }

        [JsonProperty("totalDamageDealt")]
        public int TotalDamageDealt { get; set; }

        [JsonProperty("largestKillingSpree")]
        public int LargestKillingSpree { get; set; }

        [JsonProperty("inhibitorKills")]
        public int InhibitorKills { get; set; }

        [JsonProperty("minionsKilled")]
        public int MinionsKilled { get; set; }

        [JsonProperty("towerKills")]
        public int TowerKills { get; set; }

        [JsonProperty("physicalDamageDealtToChampions")]
        public int PhysicalDamageDealtToChampions { get; set; }

        [JsonProperty("quadraKills")]
        public int QuadraKills { get; set; }

        [JsonProperty("goldSpent")]
        public int GoldSpent { get; set; }

        [JsonProperty("totalDamageDealtToChampions")]
        public int TotalDamageDealtToChampions { get; set; }

        [JsonProperty("goldEarned")]
        public int GoldEarned { get; set; }

        [JsonProperty("neutralMinionsKilledTeamJungle")]
        public int NeutralMinionsKilledTeamJungle { get; set; }

        [JsonProperty("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        [JsonProperty("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        [JsonProperty("wardsPlaced")]
        public int WardsPlaced { get; set; }

        [JsonProperty("trueDamageDealtToChampions")]
        public int TrueDamageDealtToChampions { get; set; }

        [JsonProperty("killingSprees")]
        public int KillingSprees { get; set; }

        [JsonProperty("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        [JsonProperty("totalScoreRank")]
        public int TotalScoreRank { get; set; }

        [JsonProperty("totalUnitsHealed")]
        public int TotalUnitsHealed { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }

        [JsonProperty("totalPlayerScore")]
        public int TotalPlayerScore { get; set; }

        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public int NeutralMinionsKilledEnemyJungle { get; set; }

        [JsonProperty("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }

        [JsonProperty("largestMultiKill")]
        public int LargestMultiKill { get; set; }

        [JsonProperty("totalHeal")]
        public int TotalHeal { get; set; }

        [JsonProperty("item4")]
        public int Item4 { get; set; }

        [JsonProperty("item3")]
        public int Item3 { get; set; }

        [JsonProperty("objectivePlayerScore")]
        public int ObjectivePlayerScore { get; set; }

        [JsonProperty("item6")]
        public int Item6 { get; set; }

        [JsonProperty("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        [JsonProperty("item5")]
        public int Item5 { get; set; }

        [JsonProperty("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }

        [JsonProperty("neutralMinionsKilled")]
        public int NeutralMinionsKilled { get; set; }

        [JsonProperty("combatPlayerScore")]
        public int CombatPlayerScore { get; set; }
    }

    public class Rune
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("runeId")]
        public int Id { get; set; }
    }

    public class Team
    {
        [JsonProperty("inhibitorKills")]
        public int InhibitorKills { get; set; }

        [JsonProperty("dominionVictoryScore")]
        public int DominionVictoryScore { get; set; }

        [JsonProperty("bans")]
        public List<Ban> Bans { get; set; }

        [JsonProperty("towerKills")]
        public int TowerKills { get; set; }

        [JsonProperty("firstTower")]
        public bool FirstTower { get; set; }

        [JsonProperty("firstBlood")]
        public bool FirstBlood { get; set; }

        [JsonProperty("firstBaron")]
        public bool FirstBaron { get; set; }

        [JsonProperty("firstInhibitor")]
        public bool FirstInhibitor { get; set; }

        [JsonProperty("firstDragon")]
        public bool FirstDragon { get; set; }

        [JsonProperty("winner")]
        public bool Winner { get; set; }

        [JsonProperty("vilemawKills")]
        public int VilemawKills { get; set; }

        [JsonProperty("baronKills")]
        public int BaronKills { get; set; }

        [JsonProperty("dragonKills")]
        public int DragonKills { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }

    public class Ban
    {
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }
    }

    public class PaticipantId
    {
        [JsonProperty("participantId")]
        public int Id { get; set; }
    }
}