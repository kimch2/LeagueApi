using System;
using System.Collections.Generic;
using System.Net;
using LeagueApi.Models;
using Newtonsoft.Json;

namespace RiotServices
{
    public class RiotApiSettings
    {
        public static string ApiKeyQuery { get { return "api_key=" + ApiKey; } }
        private const string ApiKey = "67337c4e-a275-45ab-a6f5-ea809254bb4c";
    }

    public class ApiChallengeService : RiotService
    {
        public static List<int> CallService(int last5MinTime)
        {
            BaseAddress = "https://na.api.pvp.net/api/lol/na/v4.1/game/ids";
            var address = String.Format("{0}?beginDate={1}&{2}", BaseAddress, last5MinTime, RiotApiSettings.ApiKeyQuery);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<List<int>>(json);
            return resultList;
        }
    }

    public class MatchService : RiotService
    {
        public static MatchResponse CallService(long matchId)
        {
            BaseAddress = "https://na.api.pvp.net/api/lol/na/v2.2/match/";
            var address = String.Format("{0}{1}?{2}", BaseAddress, matchId, RiotApiSettings.ApiKeyQuery);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<MatchResponse>(json);
            return resultList;
        }
    }

    public class ChampionsService : RiotService
    {
        private const string DataById = "dataById=true";

        public static ChampionsResponse CallService()
        {
            BaseAddress = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion";
            var address = String.Format("{0}?{1}&{2}", BaseAddress, DataById, RiotApiSettings.ApiKeyQuery);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<ChampionsResponse>(json);
            return resultList;
        }
    }

    public class ChampionService : RiotService
    {
        public ChampionService(int id)
        {
            BaseAddress = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/" + id;
        }

        private const string DataById = "dataById=true";

        public ChampionResponse CallService()
        {
            var address = String.Format("{0}?{1}&{2}", BaseAddress, DataById, RiotApiSettings.ApiKeyQuery);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<ChampionResponse>(json);
            return resultList;
        }
    }

    public abstract class RiotService
    {
        public static string BaseAddress;

        public static string Call(string address)
        {
            using (var client = new WebClient())
                return client.DownloadString(address);
        }
    }
}

