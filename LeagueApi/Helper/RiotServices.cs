using System;
using System.Collections.Generic;
using System.Net;
using LeagueApi.Models;
using Newtonsoft.Json;

namespace LeagueApi.Helper
{
    public class RiotApiSettings
    {
        public static string ApiKeyQuery { get { return "api_key=" + ApiKey; } }
        private const string ApiKey = "67337c4e-a275-45ab-a6f5-ea809254bb4c";
    }

    public class ApiChallenge : RiotService
    {
        public ApiChallenge()
        {
            BaseAddress = "https://na.api.pvp.net/api/lol/na/v4.1/game/ids";
        }

        public List<int> CallService()
        {
            var now = DateTime.UtcNow;
            var last5MinTime = Convert.ToInt32(Math.Floor((now.AddHours(-1).AddMinutes(-now.Minute).AddSeconds(-now.Second) - new DateTime(1970, 1, 1)).TotalSeconds));
            var address = String.Format("{0}?beginDate={1}&{2}", BaseAddress, last5MinTime, RiotApiSettings.ApiKeyQuery);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<List<int>>(json);
            return resultList;
        }
    }

    public class MatchService : RiotService
    {

        public MatchService()
        {
            BaseAddress = "https://na.api.pvp.net/api/lol/na/v2.2/match/";
        }

        public MatchResponse CallService(int matchId)
        {
            var address = String.Format("{0}{1}?{2}", BaseAddress, matchId, RiotApiSettings.ApiKeyQuery);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<MatchResponse>(json);

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
        public string BaseAddress;

        public static string Call(string address)
        {
            using (var client = new WebClient())
                return client.DownloadString(address);
        }
    }
}

