using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueApi.Models
{
    public class ChampionsResponse
    {

        [JsonProperty("data")]
        public Dictionary<int, ChampionResponse> Champions { get; set; }
    }

    public class ChampionResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}