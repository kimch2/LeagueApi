using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Helper;
using LeagueApi.Models;
using RiotServices;
using Participant = RiotServices.Participant;

namespace LeagueApi.Controllers
{
    public class ChampionsController : Controller
    {
        private ChampionsViewModel CurrentChampionsModel
        {
            get { return (ChampionsViewModel)Session["ChampionsVM"]; }
            set { Session["ChampionsVM"] = value; }
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                using (var riotDb = new RiotDataContext())
                {
                    var championData = ChampionsService.CallService();

                    var availableChampionIds = riotDb.Participants
                        .Select(m => m.ChampionId ?? 0).ToList()
                            .Where(m => m != 0).Distinct().ToList();

                    var availableChampions = championData.Champions
                        .Where(x => availableChampionIds.Contains(x.Key))
                            .Select(x => x.Value).OrderBy(x => x.Name).ToList();

                    var ids = new List<int?> {availableChampions[0].Id, availableChampions[1].Id};

                    var championTotals = new TotalsStatistics(new List<List<Participant>>
                    {
                        riotDb.Participants.Where(p => p.ChampionId == ids[0]).ToList(),
                        riotDb.Participants.Where(p => p.ChampionId == ids[1]).ToList()
                    });

                    var model = new ChampionsViewModel
                    {
                        AvailableChampions = availableChampions,
                        ChampionData = championTotals,
                        FirstChampionId = availableChampions[0].Id,
                        SecondChampionId = availableChampions[1].Id,
                        Matches = riotDb.Matches.ToList()
                    };

                    CurrentChampionsModel = model;
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Champions", "Index"));
            }
        }

        [HttpPost]
        public ActionResult Index(int firstChampionId, int secondChampionId)
        {
            try
            {
                var currentModel = CurrentChampionsModel;
                var riotDb = new RiotDataContext();

                var ids = new List<int?> {firstChampionId, secondChampionId};

                var championTotals = new TotalsStatistics(new List<List<Participant>>
                {
                    riotDb.Participants.Where(p => p.ChampionId == ids[0]).ToList(),
                    riotDb.Participants.Where(p => p.ChampionId == ids[1]).ToList()
                });

                currentModel.ChampionData = championTotals;

                CurrentChampionsModel = currentModel;
                return View(currentModel);
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Champions", "Index"));
            }
        }
    }
}