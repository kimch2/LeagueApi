using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Models;

namespace LeagueApi.Models
{
    public class MatchesViewModel
    {
        [Display(Name = "Current Match")]
        public int CurrentMatchId { get; set; }

        public IEnumerable<SelectListItem> MatchItems
        {
            get { return new SelectList(Matches); }
        }

        public MatchResponse CurrentMatchData { get; set; }
        public List<int> Matches { get; set; }
        public ChampionsResponse ChampionData { get; set; }

        public PlayerList Team1 { get { return new PlayerList(CurrentMatchData.Participants.Where(p => p.TeamId == 100)); } }
        public PlayerList Team2 { get { return new PlayerList(CurrentMatchData.Participants.Where(p => p.TeamId == 200)); } }
        public TeamList Teams { get { return new TeamList(new List<PlayerList> {Team1, Team2}); } } 
    }

    public class TeamList
    {
        public TeamList(List<PlayerList> teams)
        {
            Teams = teams;
        }
        
        public List<PlayerList> Teams { get; set; }
    }

    public class PlayerList
    {
        public PlayerList(IEnumerable<Player> players)
        {
            Players = players;
        }

        public IEnumerable<Player> Players { get; set; } 
    }
}