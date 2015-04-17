using System;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Helper;
using LeagueApi.Models;
using RiotServices;

namespace LeagueApi.Controllers
{
    public class FunStatsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = new FunStatViewModel();

                using (var riotDb = new RiotDataContext())
                {
                    model.ChampionData = ChampionsService.CallService();

                    model.MatchCount = riotDb.Matches.Count();
                    var funStats = riotDb.FunStats().ToList();

                    var wonMatches = riotDb.Teams.Where(x => x.Winner == true);
                    var lostMatches = riotDb.Teams.Where(x => x.Winner == false);
                    
                    var matchData = wonMatches.Join(lostMatches, a => a.MatchId, b => b.MatchId,
                        (a, b) => new MatchData(a, b))
                        .ToList();

                    model.WinData.Add(new FunStatsResponse
                    {
                        Name = "Baron Kills",
                        Won = matchData.Count(x => x.WinningTeam.BaronKills > x.LosingTeam.BaronKills),
                        Lost = matchData.Count(x => x.WinningTeam.BaronKills < x.LosingTeam.BaronKills),
                        Tied = matchData.Count(x => x.WinningTeam.BaronKills == x.LosingTeam.BaronKills)
                    });

                    model.WinData.Add(new FunStatsResponse
                    {
                        Name = "Dragon Kills",
                        Won = matchData.Count(x => x.WinningTeam.DragonKills > x.LosingTeam.DragonKills),
                        Lost = matchData.Count(x => x.WinningTeam.DragonKills < x.LosingTeam.DragonKills),
                        Tied = matchData.Count(x => x.WinningTeam.DragonKills == x.LosingTeam.DragonKills)
                    });
                    
                    model.WinData.Add(funStats.First(x => x.Name == "Minion Kills"));
                    model.WinData.Add(funStats.First(x => x.Name == "Kills"));
                    model.WinData.Add(funStats.First(x => x.Name == "Wards"));

                    model.GamesWithNoDragons = matchData.Count(x => x.WinningTeam.DragonKills == 0 && x.LosingTeam.DragonKills == 0);
                    model.GamesWithNoBarons = matchData.Count(x => x.WinningTeam.BaronKills == 0 && x.LosingTeam.BaronKills == 0);

                    var playedChamps = riotDb.Participants.GroupBy(x => x.ChampionId)
                        .Select(g => new PlayedChampionData {ChampionId = g.Key ?? 0, PlayCount = g.Count()})
                        .OrderByDescending(x => x.PlayCount);
                    
                    model.MostPlayedChampions = playedChamps.Take(5).ToList();
                    model.LeastPlayedChampions =
                        playedChamps.OrderBy(x => x.PlayCount).Take(5).OrderByDescending(x => x.PlayCount).ToList();

                    var participantsAndStats = riotDb.Participants.Join(riotDb.ParticipantStats, p => p.Id, s => s.Id,
                        (p, s) => new { Participant = p, ParticipantStats = s });

                    var participantsAndStatsWinners = participantsAndStats.Where(x => x.ParticipantStats.Winner == true).GroupBy(x => x.Participant.ChampionId).Select(x => new WinRateChampionData{ ChampionId = x.Key ?? 0, WinCount = x.Count()});
                    var participantsAndStatsLosers = participantsAndStats.Where(x => x.ParticipantStats.Winner == false).GroupBy(x => x.Participant.ChampionId).Select(x => new WinRateChampionData{ ChampionId = x.Key ?? 0, LossCount = x.Count()});

                    model.WinRateChampionData =
                        participantsAndStatsWinners.Join(participantsAndStatsLosers,
                            w => w.ChampionId,
                            l => l.ChampionId,
                            (w, l) => new WinRateChampionData
                            {
                                ChampionId = w.ChampionId,
                                WinCount = w.WinCount,
                                LossCount = l.LossCount
                            })
                            .ToList()
                            .OrderByDescending(x => x.WinRate)
                            .Take(5)
                            .ToList();


                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));
            }
        }
    }

    public class MatchData
    {
        public MatchData(Team winningTeam, Team losingTeam)
        {
            WinningTeam = winningTeam;
            LosingTeam = losingTeam;
        }

        public Team WinningTeam { get; set; }
        public Team LosingTeam { get; set; }
    }
}