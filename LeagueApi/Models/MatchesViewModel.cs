using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using RiotServices;

namespace LeagueApi.Models
{
    public class MatchesViewModel
    {
        [Display(Name = "Current Match")]
        public long CurrentMatchId { get; set; }

        public IEnumerable<SelectListItem> MatchItems
        {
            get { return new SelectList(Matches); }
        }

        public MatchResponse CurrentMatchData { get; set; }
        public List<long> Matches { get; set; }
        public ChampionsResponse ChampionData { get; set; }

        public PlayerList Team1 { get { return new PlayerList(CurrentMatchData.Participants.Where(p => p.TeamId == 100)); } }
        public PlayerList Team2 { get { return new PlayerList(CurrentMatchData.Participants.Where(p => p.TeamId == 200)); } }
        public TeamList Teams { get { return new TeamList(new List<PlayerList> {Team1, Team2}); } }
        public DateTime BucketDateTime { get; set; }
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
        public PlayerList(IEnumerable<ParticipantResponse> players)
        {
            Players = players;
        }

        public IEnumerable<ParticipantResponse> Players { get; set; }

        public ParticipantResponse Totals
        {
            get
            {
                var totals = new ParticipantResponse {Statistics = new Statistics()};

                foreach (var player in Players)
                {
                    totals.Statistics.Kills += player.Statistics.Kills;
                    totals.Statistics.Deaths += player.Statistics.Deaths;
                    totals.Statistics.Assists += player.Statistics.Assists;
                    totals.Statistics.MinionsKilled += player.Statistics.MinionsKilled;
                    totals.Statistics.TotalDamageDealt += player.Statistics.TotalDamageDealt;
                    totals.Statistics.TotalDamageDealtToChampions += player.Statistics.TotalDamageDealtToChampions;
                    totals.Statistics.GoldEarned += player.Statistics.GoldEarned;
                }

                return totals;
            }
        }
    }
}