using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace RiotServices
{
    public class RiotApiSettings
    {
        public static string ApiKeyQuery { get { return "api_key=" + ApiKey; } }
        private static readonly string ApiKey = GetApiKey();

        private static string GetApiKey()
        {
            using (var riotDb = new RiotDataContext())
                return riotDb.ApiKeys.First().ApiKey1;
        }
    }

    public class RiotService
    {
        public static DateTime LastCallTime = DateTime.Now;
        public static string BaseAddress;

        public List<int> ApiChallenge(int epochTime)
        {
            BaseAddress = "https://na.api.pvp.net/api/lol/na/v4.1/game/ids";
            var address = String.Format("{0}?beginDate={1}", BaseAddress, epochTime);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<List<int>>(json);
            return resultList;
        }

        public MatchResponse MatchService(long matchId)
        {
            BaseAddress = "https://na.api.pvp.net/api/lol/na/v2.2/match/";
            var address = String.Format("{0}{1}?{2}", BaseAddress, matchId, RiotApiSettings.ApiKeyQuery);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<MatchResponse>(json);
            return resultList;
        }

        public ChampionsResponse ChampionsService()
        {
            BaseAddress = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion?dataById=true";
            var json = Call(BaseAddress);
            var resultList = JsonConvert.DeserializeObject<ChampionsResponse>(json);
            return resultList;
        }

        public ChampionResponse ChampionService(int id)
        {
            BaseAddress = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/";
            var address = String.Format("{0}{1}?dataById=true", BaseAddress, id);
            var json = Call(address);
            var resultList = JsonConvert.DeserializeObject<ChampionResponse>(json);
            return resultList;
        }

        private static string Call(string address)
        {
            var timeSinceLastRun = (DateTime.Now - LastCallTime).TotalSeconds;
            if (timeSinceLastRun < 1.1)
            {
                var timeToSleep = Convert.ToInt32((1.1 - timeSinceLastRun) * 1000);
                System.Threading.Thread.Sleep(timeToSleep);
            }
            
            LastCallTime = DateTime.Now;
            try
            {
                using (var client = new WebClient())
                    return client.DownloadString(String.Format("{0}&{1}", address, RiotApiSettings.ApiKeyQuery));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "";
            }
            
        }
    }
}

