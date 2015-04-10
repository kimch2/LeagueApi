using RiotServices;

namespace RiotAPI_GameCollector.Mappers
{
    public class TeamMapper
    {
        public static Team MapTeam(LeagueApi.Models.Team team)
        {
            return new Team
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
            };
        }
    }
}
