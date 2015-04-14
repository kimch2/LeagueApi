using RiotServices;

namespace RiotAPI_GameCollector.Mappers
{
    class PlayerMapper
    {
        public static Player MapPlayer(PlayerResponse playerData)
        {
            return new Player
            {
                MatchHistoryUri = playerData.MatchHistoryUri,
                ProfileIcon = playerData.ProfileIcon,
                SummonerId = playerData.SummonerId,
                SummonerName = playerData.SummonerName
            };
        }
    }
}
