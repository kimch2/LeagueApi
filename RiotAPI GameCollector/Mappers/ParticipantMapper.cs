using LeagueApi.Models;
using RiotServices;

namespace RiotAPI_GameCollector.Mappers
{
    class ParticipantMapper
    {
        public static Participant MapParticipant(MatchResponse matchData, LeagueApi.Models.Player participant, ParticipantStat stats)
        {
            return new Participant
            {
                MatchId = matchData.MatchId,
                ChampionId = participant.ChampionId,
                HighestAchievedSeasonTier = participant.HighestAchievedSeasonTier,
                ParticipantId = participant.ParticipantId,
                ParticipantStat = stats,
                Spell1Id = participant.Spell1Id,
                Spell2Id = participant.Spell2Id,
                TeamId = participant.TeamId
            };
        }
    }
}
