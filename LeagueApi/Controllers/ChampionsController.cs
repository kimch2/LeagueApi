using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeagueApi.Helper;
using LeagueApi.Models;
using RiotServices;

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

                    var ids = new List<int?> { availableChampions[0].Id, availableChampions[1].Id, availableChampions[2].Id };

                    var championTotals = GetChampionTotals(ids, riotDb);
                    
                    var model = new ChampionsViewModel
                    {
                        AvailableChampions = availableChampions,
                        ChampionCount =  ids.Count,
                        ChampionTotals = championTotals,
                        ChampionIds = ids
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
        public ActionResult Index(int championCount, List<int?> ids)
        {
            try
            {
                var currentModel = CurrentChampionsModel;


                while (championCount > ids.Count)
                {
                    ids.Add(currentModel.AvailableChampions[ids.Count].Id);
                }
            
                if (championCount < ids.Count)
                    ids = ids.Take(championCount).ToList();

                using (var riotDb = new RiotDataContext())
                {
                    var championTotals = GetChampionTotals(ids, riotDb);
                    currentModel.ChampionIds = ids;
                    currentModel.ChampionCount = ids.Count;
                    currentModel.ChampionTotals = championTotals;
                    CurrentChampionsModel = currentModel;
                    return View(currentModel);
                }
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "Champions", "Index"));
            }
        }

        private static TotalsStatistics GetChampionTotals(IEnumerable<int?> ids, RiotDataContext riotDb)
        {
            var champions = ids.Select(id => riotDb.Participants.Where(p => p.ChampionId == id).ToList()).ToList();
            return new TotalsStatistics(champions);
        }
    }
}