using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Controllers;
using RiotServices;

namespace LeagueApi.Models
{
    public class ChampionsViewModel
    {
        public Champions ChampionData { get; set; }
        public List<Match> Matches { get; set; }
        public List<ChampionResponse> AvailableChampions { get; set; }
        public IEnumerable<SelectListItem> ChampionNames
        {
            get
            {
                return AvailableChampions.Select(x => new SelectListItem { Text = x.Name, Value = "" + x.Id });
            }
        }
        public int FirstChampionId { get; set; }
        public int SecondChampionId { get; set; }
    }
}